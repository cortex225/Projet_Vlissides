using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using Stripe.Checkout;
using VLISSIDES.Data;
using VLISSIDES.Interfaces;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionCommandes;
using VLISSIDES.ViewModels.Reservations;

namespace VLISSIDES.API.Stripe;

[ApiController]
[Route("[controller]/[action]")]
public class StripeController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<ApplicationUser> _logger;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ISendGridEmail _sendGridEmail;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserStore<ApplicationUser> _userStore;

    // Variable pour stocker le webhook secret de Stripe
    private readonly string _webhookSecretApi;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public StripeController(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        IUserStore<ApplicationUser> userStore,
        RoleManager<IdentityRole> roleManager,
        ILogger<ApplicationUser> logger,
        ApplicationDbContext context,
        IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment webHostEnvironment,
        ISendGridEmail sendGridEmail,
        IConfiguration configuration // Une seule instance de IConfiguration
    )
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _userStore = userStore;
        _roleManager = roleManager;
        _logger = logger;
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _webHostEnvironment = webHostEnvironment;
        _sendGridEmail = sendGridEmail;
        _configuration = configuration;

        // Récupérer le webhook secret de Stripe depuis la configuration
        _webhookSecretApi = _configuration["WebhookSecretApi"];
    }


    [HttpPost]
    public async Task<IActionResult> ConfirmationPaiement()
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

        try
        {
            var stripeEvent =
                EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], _webhookSecretApi,
                    throwOnApiVersionMismatch: false);

            var session = stripeEvent.Data.Object as Session;
            // Handle the event

            if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                try
                {
                    // Déterminer si la session concerne un livre ou un évènement
                    if (EstUnAchatDeLivre(session))
                        // Traiter comme un achat de livre
                        await TraiterAchatLivre(session);
                    else if (EstUnAchatEvenement(session))
                        // Traiter comme une réservation d'évènement
                        await TraiterReservationEvenement(session);
                    else
                        Console.WriteLine("Type de session inconnu");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            else
                // Unexpected event type
                Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);

            return Ok();
        }
        catch (StripeException e)
        {
            return BadRequest();
        }
    }


    private bool EstUnAchatDeLivre(Session session)
    {
        // Vérifie si la session est pour un livre
        return session.Metadata.ContainsKey("type") && session.Metadata["type"] == "livre";
    }

    private bool EstUnAchatEvenement(Session session)
    {
        // Vérifie si la session est pour un évènement
        return session.Metadata.ContainsKey("type") && session.Metadata["type"] == "evenement";
    }

    private async Task TraiterAchatLivre(Session session)
    {
        var customer =
            await _context.Membres.FirstOrDefaultAsync(c => c.StripeCustomerId == session.CustomerId);


        await GetStripeSessionDetails(session.Id);


        // Récupérer les items du panier de l'utilisateur
        var panierItems = await _context.LivrePanier
            .Where(lp => lp.UserId == customer.Id)
            .Include(lp => lp.Livre).ThenInclude(livre => livre.LivreTypeLivres)
            .Include(lp=>lp.Promotion)
            .ToListAsync();


            var nouvelleCommande = new CommandesVM
        {
            Id = _context.Commandes.Count().ToString(),
            DateCommande = DateTime.Now,
            PrixTotal = session.AmountTotal.Value / 100m,
            MembreUserName = customer.UserName,
            AdresseId = customer?.AdressePrincipaleId,
            StatutId = "1",
            PromotionId = session.Metadata["promotionId"]
        };


        nouvelleCommande.LivreCommandes = panierItems.Select(lc => new LivreCommandeVM
        {
            Livre = lc.Livre,
            CommandeId = nouvelleCommande.Id,
            Quantite = (int)lc.Quantite,
            PrixAchat = (double)(panierItems.FirstOrDefault(p => p.LivreId == lc.LivreId)?.PrixApresPromotion ?? lc.PrixOriginal)!
        }).ToList();

        // Créer la commande

        var nbCommandes = _context.Commandes.Count().ToString();
        var commande = new Commande
        {
            Id = nbCommandes,
            DateCommande = nouvelleCommande.DateCommande,
            PrixTotal = nouvelleCommande.PrixTotal,
            MembreId = customer.Id,
            AdresseId = customer.AdressePrincipaleId,
            StatutCommandeId = nouvelleCommande.StatutId,
            PaymentIntentId = session.PaymentIntentId, //Récupérer le paiement intent id de la session
            EnDemandeAnnulation = false,
            PromotionId = nouvelleCommande.PromotionId

        };

        _context.Commandes.Add(commande);
        await _context.SaveChangesAsync();

        foreach (var item in nouvelleCommande.LivreCommandes)
        {
            var livreCommande = new LivreCommande
            {
                CommandeId = commande.Id,
                LivreId = item.Livre.Id,
                Quantite = item.Quantite,
                PrixAchat = item.PrixAchat
            };
            _context.LivreCommandes.Add(livreCommande);
        }

        // Récupérer l'URL complète du logo à partir de l'application
        var logoUrl = Url.Content("http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");
        // Envoi du mail de confirmation de commande
        await SendConfirmationEmailLivre(customer, nouvelleCommande, logoUrl, session.Id);

        //Suppression du panier actuel de la bd
        _context.LivrePanier.RemoveRange(panierItems);
        await _context.SaveChangesAsync();

        //Mise à jour des stocks des livres
        foreach (var item in nouvelleCommande.LivreCommandes)
        {
            // Récupérez le livre correspondant de manière asynchrone.
            var livre = await _context.Livres
                .Include(l => l.LivreTypeLivres)
                .ThenInclude(lt => lt.TypeLivre)
                .SingleOrDefaultAsync(l => l.Id == item.Livre.Id);

            // Vérifiez si le livre est de type papier.
            if (livre != null && livre.LivreTypeLivres.Any(lt => lt.TypeLivre.Nom == "Papier"))
            {
                // Déduisez la quantité pour les livres papier.
                livre.NbExemplaires -= item.Quantite;
                _context.Livres.Update(livre);
            }
        }

        var promotion = nouvelleCommande.PromotionId != null
            ? _context.Promotions.FirstOrDefault(p => p.Id == nouvelleCommande.PromotionId)
            : null;

        // Mettre à jour la dernière utilisation pour la promotion d'anniversaire
        if( promotion!.CodePromo == "BIRTHDAY")
        {
            customer.DerniereUtilisationPromoAnniversaire = DateTime.Now;
            _context.Membres.Update(customer);
        }
        await _context.SaveChangesAsync();
    }

    private async Task GetStripeSessionDetails(string sessionId)
    {
        // Initialiser le service de session Stripe
        var sessionService = new SessionService();

        // Récupérer les détails de la session
        var stripeSession = await sessionService.GetAsync(sessionId);

        // Vérifier si la session contient des informations sur les articles
        if (stripeSession != null && stripeSession.LineItems != null && stripeSession.LineItems.Data != null)
            foreach (var lineItem in stripeSession.LineItems.Data)
            {
                // Récupérer le prix unitaire de chaque article
                var unitPrice = lineItem.Price.UnitAmount;

                // Vous pouvez ici traiter ou afficher le prix comme nécessaire
                // Par exemple, afficher le prix
                Console.WriteLine($"Prix de l'article : {unitPrice}");
            }
        else
            Console.WriteLine("Aucun article trouvé dans la session Stripe.");
    }

    private async Task TraiterReservationEvenement(Session session)
    {
        var customer =
            await _context.Membres.FirstOrDefaultAsync(c => c.StripeCustomerId == session.CustomerId);

        //Recuperer l'evenement de la session
        var evenement = _context.Evenements.FirstOrDefault(e => e.Id == session.Metadata["evenementId"]);

        // Créer la réservation
        var nbReservations = _context.Reservations.Count().ToString();
        var reservation = new Reservation
        {
            Id = nbReservations,
            DateReservation = DateTime.Now,
            Membre = customer,
            Evenement = evenement,
            Description = evenement.Description,
            PaymentIntentId = session.PaymentIntentId,
            prixAchat = evenement.Prix,
            EnDemandeAnnuler = false,
            Quantite = Convert.ToInt32(session.Metadata["quantite"])
        };
        // Ajouter la réservation au contexte
        _context.Reservations.Add(reservation);

        // Sauvegarder les changements dans la base de données
        await _context.SaveChangesAsync();

        // Préparer l'envoi de l'email de confirmation
        var reservationVM = new ReservationVM
        {
            Id = reservation.Id,
            EvenementNom = evenement.Nom,
            Description = evenement.Description,
            DateDebut = evenement.DateDebut,
            DateFin = evenement.DateFin,
            Lieu = evenement.Lieu,
            NombreDePlaces = evenement.NbPlaces,
            Quantite = reservation.Quantite,
            PrixTotal = session.AmountTotal.Value /
                        100m // Ajuste la division si vous n'utilisez pas les centimes dans Stripe
        };
        // Construire l'URL du logo
        var logoUrl = Url.Content("http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");

        // Envoye l'email de confirmation
        await SendConfirmationEmailReservation(customer, reservationVM, logoUrl, session.Id);


        var nbPlacesReservees = _context.Reservations.Count(r => r.EvenementId == evenement.Id);
        evenement.NbPlacesReservees = nbPlacesReservees + reservation.Quantite;
        _context.Evenements.Update(evenement);
        await _context.SaveChangesAsync();
    }

    private async Task SendConfirmationEmailReservation(Membre customer, ReservationVM reservationVM,
        string logoUrl, string sessionId)
    {
        var subject = "Confirmation de commande";

        // Récupérer la facture de Stripe
        // var invoice = await GetInvoiceFromStripe(sessionId);

        // Construire le corps du courriel
        var body = BuildReservationEmailBody(customer, reservationVM, logoUrl);

        // Envoyer le courriel avec la facture en pièce jointe
        await _sendGridEmail.SendEmailAsync(customer.Email, subject, body);
    }

    private async Task SendConfirmationEmailLivre(Membre customer, CommandesVM nouvelleCommande, string logoUrl,
        string sessionId)
    {
        var subject = "Confirmation de commande";

        // Récupérer la facture de Stripe
        // var invoice = await GetInvoiceFromStripe(sessionId);

        // Construire le corps du courriel
        var body = BuildEmailBodyCommande(customer, nouvelleCommande, logoUrl);

        // Envoyer le courriel avec la facture en pièce jointe
        await _sendGridEmail.SendEmailAsync(customer.Email, subject, body);
    }

    private string BuildReservationEmailBody(Membre customer, ReservationVM reservationVM, string logoUrl)
    {
        var body = new StringBuilder();

        body.Append(
            "<div style='font-family: \"Helvetica Neue\", Helvetica, Arial, sans-serif; max-width: 680px; margin: 20px auto; padding: 40px; border-radius: 8px; background-color: #ffffff; box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);'>");
        body.Append(
            $"<img src='{logoUrl}' alt='Logo' style='max-width: 200px; display: block; margin: 0 auto 20px;'>");
        body.Append(
            "<h1 style='color: #146ec3; text-align: center; font-size: 28px; margin-bottom: 10px;'>Confirmation de Réservation</h1>");
        body.Append(
            $"<h2 style='color: #333; text-align: center; margin-top: 0;'>Bonjour {customer.UserName},</h2>");
        body.Append(
            "<p style='color: #555; font-size: 16px; text-align: center;'>Votre réservation a été effectuée avec succès. Voici les détails :</p>");
        body.Append(
            "<hr style='border: 0; height: 1px; background-image: linear-gradient(to right, #146ec3, #146ec3, #fff); margin: 20px 0;'>");
        body.Append("<table style='width: 100%; margin-top: 30px; border-collapse: collapse;'>");
        body.Append("<thead>");
        body.Append("<tr style='background-color: #146ec3; color: #ffffff;'>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Événement</th>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Date</th>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Lieu</th>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Prix</th>");
        body.Append("</tr>");
        body.Append("</thead>");
        body.Append("<tbody>");
        body.Append("<tr>");
        body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{reservationVM.EvenementNom}</td>");
        body.Append(
            $"<td style='padding: 15px; border: 1px solid #ddd;'>Du {reservationVM.DateDebut:U} au {reservationVM.DateFin:U}</td>");
        body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{reservationVM.Lieu}</td>");
        body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{reservationVM.PrixTotal:C}</td>");
        body.Append("</tr>");
        body.Append("</tbody>");
        body.Append("</table>");
        body.Append(
            $"<p style='color: #555; font-size: 16px;'><strong>Numéro de réservation :</strong> {reservationVM.Id}</p>");
        body.Append(
            $"<p style='color: #555; font-size: 16px;'><strong>Description :</strong> {reservationVM.Description}</p>");
        body.Append(
            $"<p style='color: #555; font-size: 16px;'><strong>Nombre de places réservée(s):</strong> {reservationVM.Quantite}</p>");
        body.Append(
            $"<p style='color: #555; font-size: 16px;'><strong>Total payé :</strong> {reservationVM.PrixTotal:C}</p>");
        body.Append(
            "<p style='color: #555; font-size: 16px;'>Si vous avez des questions ou si vous avez besoin d'informations supplémentaires, veuillez ne pas hésiter à nous contacter.</p>");
        body.Append(
            "<p style='text-align: center; margin-top: 40px;'><a href='https://sqlinfocg.cegepgranby.qc.ca/2147186' style='font-size: 18px; color: #146ec3; text-decoration: none;'><strong>Visitez notre site</strong></a></p>");
        body.Append("<footer style='text-align: center; color: #888; margin-top: 40px; font-size: 14px;'>");
        body.Append("<p>Merci de faire confiance à La Fourmi Aillée.</p>");
        body.Append("<p style='color: #146ec3;'>La Fourmi Aillée, 235 Rue Saint-Jacques, Granby, QC J2G 3N1</p>");
        body.Append("</footer>");
        body.Append("</div>");

        return body.ToString();
    }

    private string BuildEmailBodyCommande(Membre customer, CommandesVM nouvelleCommande, string logoUrl)
    {
        var body = new StringBuilder();

        // Calculer le sous-total avant taxe
        var sousTotal = nouvelleCommande.PrixTotal / 1.05m;
        var taxe = nouvelleCommande.PrixTotal - sousTotal;
        var promotion = nouvelleCommande.PromotionId != null ? _context.Promotions.FirstOrDefault(p => p.Id == nouvelleCommande.PromotionId) : null;

        body.Append(
            "<div style='font-family: \"Helvetica Neue\", Helvetica, Arial, sans-serif; max-width: 680px; margin: 20px auto; padding: 40px; border-radius: 8px; background-color: #ffffff; box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);'>");
        body.Append(
            $"<img src='{logoUrl}' alt='Logo' style='max-width: 200px; display: block; margin: 0 auto 20px;'>");
        body.Append(
            "<h1 style='color: #146ec3; text-align: center; font-size: 28px; margin-bottom: 10px;'>Confirmation de Commande</h1>");
        body.Append(
            $"<h2 style='color: #333; text-align: center; margin-top: 0;'>Cher(e) {customer.UserName},</h2>");
        body.Append(
            "<p style='color: #555; font-size: 16px; text-align: center;'>Merci pour votre commande ! Voici le récapitulatif :</p>");
        body.Append(
            "<hr style='border: 0; height: 1px; background-image: linear-gradient(to right, #146ec3, #146ec3, #fff); margin: 20px 0;'>");
        body.Append("<table style='width: 100%; margin-top: 30px; border-collapse: collapse;'>");
        body.Append("<thead>");
        body.Append("<tr style='background-color: #146ec3; color: #ffffff;'>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Produit</th>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Quantité</th>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Prix</th>");
        body.Append("</tr>");
        body.Append("</thead>");
        body.Append("<tbody>");

        foreach (var item in nouvelleCommande.LivreCommandes)
        {
            body.Append("<tr>");
            body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{item.Livre.Titre}</td>");
            body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{item.Quantite}</td>");
            body.Append(
                $"<td style='padding: 15px; border: 1px solid #ddd;'>{item.PrixAchat:C}</td>");
            body.Append("</tr>");
        }

        body.Append("</tbody>");
        body.Append("</table>");
        if(promotion != null)
            body.Append(
                $"<p style='color: #555; font-size: 16px;'><strong>Code promotionnel appliqué :</strong> {promotion.Nom} de {promotion.PourcentageRabais}%</p>");
        body.Append($"<p style='color: #555; font-size: 15px;'>Sous-total : {sousTotal:C}</p>");
        body.Append($"<p style='color: #555; font-size: 15px;'>Taxe (5%) : {taxe:C}</p>");
        body.Append(
            $"<p style='color: #555; font-size: 16px;'><strong>Prix Total:</strong> {nouvelleCommande.PrixTotal:C}</p>");
        body.Append(
            "<p style='color: #555; font-size: 16px;'>Votre commande sera traitée rapidement et vous recevrez une notification dès qu'elle sera expédiée.</p>");
        body.Append(
            "<p style='text-align: center; margin-top: 40px;'><a href='https://sqlinfocg.cegepgranby.qc.ca/2147186' style='font-size: 18px; color: #146ec3; text-decoration: none;'><strong>Visitez notre site</strong></a></p>");
        body.Append("<footer style='text-align: center; color: #888; margin-top: 40px; font-size: 14px;'>");
        body.Append("<p>Merci de faire confiance à La Fourmie Aillée.</p>");
        body.Append("<p>La Fourmie Aillée, 235 Rue Saint-Jacques, Granby, QC J2G 3N1</p>");
        body.Append("</footer>");
        body.Append("</div>");

        return body.ToString();
    }
}