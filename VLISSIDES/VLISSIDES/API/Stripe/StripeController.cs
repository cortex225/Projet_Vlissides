using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;
using Stripe;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Paiement;
using VLISSIDES.ViewModels.Panier;
using VLISSIDES.ViewModels.Profile;
using Stripe.Checkout;
using VLISSIDES.Interfaces;
using VLISSIDES.ViewModels.GestionCommandes;
using VLISSIDES.ViewModels.Reservations;

namespace VLISSIDES.API.Stripe
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StripeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ApplicationUser> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ISendGridEmail _sendGridEmail;

        // Variable pour stocker le webhook secret de Stripe
        private readonly string _webhookSecretApi;

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

                if (stripeEvent.Type == Events.CheckoutSessionAsyncPaymentFailed)
                {
                }
                else if (stripeEvent.Type == Events.CheckoutSessionAsyncPaymentSucceeded)
                {
                }
                else if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    try
                    {
                        // Déterminer si la session concerne un livre ou un évènement
                        if (EstUnAchatDeLivre(session))
                        {
                            // Traiter comme un achat de livre
                            await TraiterAchatLivre(session);
                        }
                        else if (EstUnAchatEvenement(session))
                        {
                            // Traiter comme une réservation d'évènement
                            await TraiterReservationEvenement(session);
                        }
                        else
                        {
                            Console.WriteLine("Type de session inconnu");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }

                else
                {
                    // Unexpected event type
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }

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

            // Récupérer les items du panier de l'utilisateur
            var panierItems = await _context.LivrePanier
                .Where(lp => lp.UserId == customer.Id)
                .Include(lp => lp.Livre).ThenInclude(livre => livre.LivreTypeLivres)
                .ToListAsync();


            var nouvelleCommande = new CommandesVM
            {
                DateCommande = DateTime.Now,
                PrixTotal = session.AmountTotal.Value / 100m,
                MembreUserName = customer.UserName,
                AdresseId = customer?.AdressePrincipaleId,
                StatutId = "2"
            };
            nouvelleCommande.LivreCommandes = panierItems.Select(lc => new LivreCommandeVM
            {
                Livre = lc.Livre,
                CommandeId = nouvelleCommande.Id,
                Quantite = (int)lc.Quantite
            }).ToList();

            var nbCommandes = _context.Commandes.Count().ToString();
            var commande = new Commande
            {
                Id = "Commande-#" + nbCommandes + "-" + DateTime.Now.ToString("yyyyMMddHH"),
                DateCommande = nouvelleCommande.DateCommande,
                PrixTotal = nouvelleCommande.PrixTotal,
                MembreId = customer.Id,
                AdresseId = customer.AdressePrincipaleId,
                StatutCommandeId = nouvelleCommande.StatutId,
                LivreCommandes = nouvelleCommande.LivreCommandes.Select(lc => new LivreCommande
                {
                    LivreId = lc.Livre.Id,
                    CommandeId = nouvelleCommande.Id,
                    Quantite = lc.Quantite
                }).ToList()
            };

            _context.Commandes.Add(commande);
            await _context.SaveChangesAsync();

            // Récupérer l'URL complète du logo à partir de l'application
            var logoUrl = Url.Content("http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");
            // Envoi du mail de confirmation de commande
            await SendConfirmationEmailLivre(customer, nouvelleCommande, logoUrl, session.Id);

            //Suppression du panier actuel de la bd
            _context.LivrePanier.RemoveRange(panierItems);
            await _context.SaveChangesAsync();
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
                Id = "R_" + evenement.Nom + "#"+ nbReservations + "-" + DateTime.Now.ToString("yyyyMMddHH"),
                DateReservation = DateTime.Now,
                Membre = customer,
                Evenement = evenement,
                Description = evenement.Description
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
                NombreDePlaces = 1, // Supposons 1 place réservée, ajustez selon la logique de votre application
                PrixTotal = session.AmountTotal.Value /
                            100m // Ajuste la division si vous n'utilisez pas les centimes dans Stripe
            };
            // Construire l'URL du logo
            var logoUrl = Url.Content("http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");

            // Envoyer l'email de confirmation
            await SendConfirmationEmailReservation(customer, reservationVM, logoUrl, session.Id);
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

            body.Append("<div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>");
            body.Append(
                $"<img src='{logoUrl}' alt='Logo' style='width:250px;height:auto; display: block; margin: 0 auto;'>");
            body.Append($"<h2 style='color: #444;'>Bonjour {customer.UserName},</h2>");
            body.Append("<p>Nous confirmons votre réservation pour l'événement suivant :</p>");
            body.Append("<table style='width: 100%; border-collapse: collapse;'>");
            body.Append("<thead>");
            body.Append("<tr style='background-color: #f2f2f2;'>");
            body.Append("<th style='padding: 8px; border: 1px solid #ddd;'>Événement</th>");
            body.Append("<th style='padding: 8px; border: 1px solid #ddd;'>Date</th>");
            body.Append("<th style='padding: 8px; border: 1px solid #ddd;'>Lieu</th>");
            body.Append("<th style='padding: 8px; border: 1px solid #ddd;'>Prix</th>");
            body.Append("</tr>");
            body.Append("</thead>");
            body.Append("<tbody>");
            body.Append("<tr>");
            body.Append($"<td style='padding: 8px; border: 1px solid #ddd;'>{reservationVM.EvenementNom}</td>");
            body.Append(
                $"<td style='padding: 8px; border: 1px solid #ddd;'>{reservationVM.DateDebut:dd/MM/yyyy} - {reservationVM.DateFin:dd/MM/yyyy}</td>");
            body.Append($"<td style='padding: 8px; border: 1px solid #ddd;'>{reservationVM.Lieu}</td>");
            body.Append($"<td style='padding: 8px; border: 1px solid #ddd;'>{reservationVM.PrixTotal:C}</td>");
            body.Append("</tr>");
            body.Append("</tbody>");
            body.Append("</table>");
            body.Append("<p>Voici les détails de votre réservation :</p>");
            body.Append($"<p style='font-size:1.5em;'><strong>Numéro de réservation :</strong> {reservationVM.Id}</p>");
            body.Append($"<p><strong>Description :</strong> {reservationVM.Description}</p>");
            body.Append($"<p><strong>Nombre de places :</strong> {reservationVM.NombreDePlaces}</p>");
            body.Append($"<p><strong>Total payé :</strong> {reservationVM.PrixTotal:C}</p>");

            body.Append(
                "<p>Nous vous remercions pour votre réservation et avons hâte de vous accueillir à l'événement.</p>");
            body.Append("<p>Si vous avez des questions, n'hésitez pas à nous contacter.</p>");
            body.Append("<p>Cordialement,</p>");
            body.Append("<p>L'équipe de La Fourmi Aillée</p>");
            body.Append("</div>");

            return body.ToString();
        }

        private string BuildEmailBodyCommande(Membre customer, CommandesVM nouvelleCommande, string logoUrl)
        {
            StringBuilder body = new StringBuilder();

            body.Append("<div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>");
            body.Append(
                $"<img src='{logoUrl}' alt='Logo Fourmie Aillée' style='width:250px;height:auto; display: block; margin: 0 auto;'>");
            body.Append($"<h2 style='color: #444;'>Cher(e) {customer.UserName},</h2>");
            body.Append("<p>Merci pour votre commande ! Voici le récapitulatif :</p>");
            body.Append("<table style='width: 100%; border-collapse: collapse;'>");
            body.Append("<thead>");
            body.Append("<tr style='background-color: #f2f2f2;'>");
            body.Append("<th style='padding: 8px; border: 1px solid #ddd;'>Produit</th>");
            body.Append("<th style='padding: 8px; border: 1px solid #ddd;'>Quantité</th>");
            body.Append("<th style='padding: 8px; border: 1px solid #ddd;'>Prix</th>");
            body.Append("</tr>");
            body.Append("</thead>");
            body.Append("<tbody>");

            foreach (var item in nouvelleCommande.LivreCommandes)
            {
                body.Append("<tr>");
                body.Append($"<td style='padding: 8px; border: 1px solid #ddd;'>{item.Livre.Titre}</td>");
                body.Append($"<td style='padding: 8px; border: 1px solid #ddd;'>{item.Quantite}</td>");
                body.Append(
                    $"<td style='padding: 8px; border: 1px solid #ddd;'>{item.Livre.LivreTypeLivres.FirstOrDefault().Prix}$</td>");
                body.Append("</tr>");
            }

            body.Append("</tbody>");
            body.Append("</table>");
            body.Append($"<p><strong>Total : {nouvelleCommande.PrixTotal.ToString("C")}</strong></p>");
            body.Append(
                "<p>Votre commande sera traitée rapidement et vous recevrez une notification dès qu'elle sera expédiée.</p>");
            body.Append("<p>Merci de faire confiance à La Fourmie Aillée !</p>");
            body.Append("</div>");

            return body.ToString();
        }
    }
}