using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using Stripe.Checkout;
using System.Text;
using VLISSIDES.Data;
using VLISSIDES.Interfaces;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionCommandes;

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
                        var customer =
                            await _context.Membres.FirstOrDefaultAsync(c => c.StripeCustomerId == session.CustomerId);
                        var panierItems = _context.LivrePanier
                            .Where(lp => lp.UserId == customer.Id)
                            .Include(lp => lp.Livre).ThenInclude(livre => livre.LivreTypeLivres)
                            .ToList();


                        var nouvelleCommande = new CommandesVM();
                        nouvelleCommande.DateCommande = DateTime.Now;
                        nouvelleCommande.PrixTotal = session.AmountTotal.Value / 100m;
                        nouvelleCommande.MembreUserName = customer.UserName;
                        nouvelleCommande.AdresseId = customer?.AdressePrincipaleId;
                        nouvelleCommande.StatutId = "2";
                        nouvelleCommande.LivreCommandes = panierItems.Select(lc => new LivreCommandeVM
                        {
                            Livre = lc.Livre,
                            CommandeId = nouvelleCommande.Id,
                            Quantite = (int)lc.Quantite
                        }).ToList();

                        var nbCommandes = _context.Commandes.Count().ToString();
                        var commande = new Commande
                        {
                            Id = "Commande-" + nbCommandes + "-" + DateTime.Now.ToString("yyyyMMddHH"),
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
                        var logoUrl =
                            Url.Content(
                                "http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");
                        // Envoi du mail de confirmation de commande
                        await SendConfirmationEmail(customer, nouvelleCommande, logoUrl, session.Id);

                        //Suppression du panier actuel de la bd
                        _context.LivrePanier.RemoveRange(panierItems);
                        await _context.SaveChangesAsync();
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

        private async Task SendConfirmationEmail(Membre customer, CommandesVM nouvelleCommande, string logoUrl,
            string sessionId)
        {
            var subject = "Confirmation de commande";

            // Récupérer la facture de Stripe
            // var invoice = await GetInvoiceFromStripe(sessionId);

            // Construire le corps du courriel
            var body = BuildEmailBody(customer, nouvelleCommande, logoUrl);

            // Envoyer le courriel avec la facture en pièce jointe
            await _sendGridEmail.SendEmailAsync(customer.Email, subject, body);
        }


        private string BuildEmailBody(Membre customer, CommandesVM nouvelleCommande, string logoUrl)
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