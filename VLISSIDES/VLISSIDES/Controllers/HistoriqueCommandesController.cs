using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Security.Claims;
using System.Text;
using VLISSIDES.Data;
using VLISSIDES.Interfaces;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionCommandes;
using VLISSIDES.ViewModels.HistoriqueCommandes;

namespace VLISSIDES.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HistoriqueCommandes : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISendGridEmail _sendGridEmail;
        private readonly IConfiguration _configuration;


        // Variable pour stocker le webhook secret de Stripe
        private readonly string _webhookSecretApi;
        public HistoriqueCommandes(ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment,
            IConfiguration config,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            ISendGridEmail sendGridEmail,
            IConfiguration configuration // Une seule instance de IConfiguration
        )
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _sendGridEmail = sendGridEmail;

            // Récupérer le webhook secret de Stripe depuis la configuration
            _webhookSecretApi = _configuration["WebhookSecretApi"];
        }
        public IActionResult Index(string? motCles, string? criteres)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var commandes = _context.Commandes
                .Include(c => c.StatutCommande)
                .Include(c => c.Membre);
            var livreCommandes = _context.LivreCommandes;

            var livreCommandeVM = livreCommandes.Select(lc => new LivreCommandeVM
            {
                Livre = lc.Livre,
                CommandeId = lc.CommandeId,
                Quantite = lc.Quantite,
                PrixAchat = lc.PrixAchat,
                EnDemandeRetourner = lc.EnDemandeRetourner
            }).ToList();

            var listeCommandeVM = commandes.Where(c => c.MembreId == userId).AsEnumerable().Select(c => new CommandesVM
            {
                Id = c.Id.ToString(),
                DateCommande = c.DateCommande,
                PrixTotal = c.PrixTotal,
                MembreUserName = c.Membre.UserName,
                AdresseId = c.AdresseId,
                LivreCommandes = livreCommandeVM.Where(lc => lc.CommandeId == c.Id).ToList(),
                StatutId = c.StatutCommande.Id,
                StatutNom = c.StatutCommande.Nom
            }).OrderBy(c => c.DateCommande).ToList();

            var affichageCommandes = new AffichageCommandeVM
            {
                ListCommandes = listeCommandeVM
            };

            affichageCommandes.SelectListStatut = _context.StatutCommandes.Select(s => new SelectListItem
            {
                Text = s.Nom,
                Value = s.Id
            }).ToList();

            return View(affichageCommandes);
        }

        public IActionResult AfficherCommandes(string? motCles, string? criteres)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var listCriteresValue = new List<string>();
            if (motCles != null) listCriteresValue = motCles.Split('|').ToList();

            var listCriteres = new List<string>();
            if (criteres != null) listCriteres = criteres.Split('|').ToList();

            //var currentUserId = _userManager.GetUserId(HttpContext.User);
            var commandes = _context.Commandes
                .Include(c => c.StatutCommande)
                .Include(c => c.Membre);
            var livreCommandes = _context.LivreCommandes;

            var livreCommandeVM = livreCommandes.Select(lc => new LivreCommandeVM
            {
                Livre = lc.Livre,
                CommandeId = lc.CommandeId,
                Quantite = lc.Quantite,
                PrixAchat = lc.PrixAchat,
                EnDemandeRetourner = lc.EnDemandeRetourner
            }).ToList();

            var listeCommandeVM = commandes.Where(c => c.MembreId == userId).AsEnumerable().Select(c => new CommandesVM
            {
                Id = c.Id.ToString(),
                DateCommande = c.DateCommande,
                PrixTotal = c.PrixTotal,
                MembreUserName = c.Membre.UserName,
                AdresseId = c.AdresseId,
                LivreCommandes = livreCommandeVM.Where(lc => lc.CommandeId == c.Id).ToList(),
                StatutId = c.StatutCommande.Id,
                StatutNom = c.StatutCommande.Nom
            }).OrderByDescending(c => c.DateCommande).ToList();

            if (listCriteres.Any(c => c == "rechercherCommande"))
            {
                if (listCriteresValue[2] != "")
                    listeCommandeVM = listeCommandeVM.Where(c => c.Id == listCriteresValue[2]).ToList();
            }

            if (listCriteres.Any(c => c == "trierDate"))
            {
                if (listCriteresValue[0] == "2")
                {
                    listeCommandeVM = listeCommandeVM.OrderBy(c => c.DateCommande).ToList();
                }
                else
                {
                    listeCommandeVM = listeCommandeVM.OrderByDescending(c => c.DateCommande).ToList();
                }
            }

            if (listCriteres.Any(c => c == "filtrerStatut"))
            {
                if (listCriteresValue[1] != "0")
                {
                    listeCommandeVM = listeCommandeVM.Where(c => c.StatutId == listCriteresValue[1].ToString()).ToList();
                }
            }

            var affichageCommandes = new AffichageCommandeVM
            {
                ListCommandes = listeCommandeVM
            };

            affichageCommandes.SelectListStatut = _context.StatutCommandes.Select(s => new SelectListItem
            {
                Text = s.Nom,
                Value = s.Id
            }).ToList();

            return PartialView("PartialViews/GestionCommandes/_ListeCommandesPartial", affichageCommandes);
        }

        public async Task<IActionResult> ShowRetournerConfirmation(string commandeId, string livreId)
        {
            var livreCommande = await _context.LivreCommandes.Include(lc => lc.Livre).Include(lc => lc.Commande).FirstOrDefaultAsync(lc => lc.CommandeId == commandeId && lc.LivreId == livreId);

            var vm = new StripeRefundVM
            {
                Commande = livreCommande.Commande,
                Livre = livreCommande.Livre,
                Prix = livreCommande.PrixAchat,
                Quantite = 0 //Valeur non nécessaire(À voir si on l'utilise ou pas)
            };

            return PartialView("PartialViews/Modals/HistoriqueCommandesModals/_ConfirmerRetournerPartial", vm);
        }
        [HttpPost]
        public async Task<StatusCodeResult> RefundStripe(string commandeId, string livreId, int quantite)
        {

            // Récupère l'identifiant de l'utilisateur connecté
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var StripeCustomerId = _context.Membres.Where(m => m.Id == userId).FirstOrDefault().StripeCustomerId;

            var lc = _context.LivreCommandes.Include(lc => lc.Livre).FirstOrDefault(lc => lc.CommandeId == commandeId && lc.LivreId == livreId);
            if (lc == null) return BadRequest();

            var model = new LivreCommandeVM
            {
                Livre = lc.Livre,
                CommandeId = lc.CommandeId,
                PrixAchat = lc.PrixAchat,
                Quantite = quantite
            };

            StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";

            var options = new RefundCreateOptions
            {
                //Charge = "ch_3OADrI2eZvKYlo2C0W9LzCya",
                //PaymentIntent
                Amount = (long?)(model.Quantite * (double)model.PrixAchat),
                Currency = "cad"
            };

            var service = new RefundService();
            //service.Create(options);


            //Send email
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var customer =
                    await _context.Membres.FirstOrDefaultAsync(m => m.Id == userId);
                var panierItems = _context.LivrePanier
                    .Where(lp => lp.UserId == customer.Id)
                    .Include(lp => lp.Livre).ThenInclude(livre => livre.LivreTypeLivres)
                    .ToList();

                // Récupérer l'URL complète du logo à partir de l'application
                var logoUrl =
                    Url.Content(
                        "http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");
                // Envoi du mail de confirmation de commande
                await SendConfirmationEmail(customer, model, logoUrl);

                //Suppression du panier actuel de la bd
                _context.LivrePanier.RemoveRange(panierItems);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            lc.EnDemandeRetourner = true;
            await _context.SaveChangesAsync();

            return Ok();
        }

        private async Task SendConfirmationEmail(Membre customer, LivreCommandeVM livreCommande, string logoUrl)
        {
            var subject = "Retour de livres";

            // Construire le corps du courriel
            var body = BuildEmailBody(customer, livreCommande, logoUrl);


            var admin = _context.Users.FirstOrDefault(u => u.Id == "0");

            // Envoyer le courriel avec la facture en pièce jointe
            await _sendGridEmail.SendEmailAsync(admin.Email, subject, body);

            //Pouvoir envoyer un courriel à tous les employés
            //var employes = _context.Employes.ToList();
            //foreach (var employe in employes)
            //{
            //    await _sendGridEmail.SendEmailAsync(employe.Email, subject, body);
            //}
        }

        private string BuildEmailBody(Membre customer, LivreCommandeVM livreCommande, string logoUrl)
        {
            string myURL = _httpContextAccessor.HttpContext.Request.Host.Value;//_httpContextAccessor.Request.Host.Value;
            string BASE_URL_RAZOR = Url.Content("~");

            StringBuilder body = new StringBuilder();

            body.Append("<div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>");
            body.Append(
                $"<img src='{logoUrl}' alt='Logo Fourmie Aillée' style='width:250px;height:auto; display: block; margin: 0 auto;'>");
            body.Append($"<h2 style='color: #444;'>Demande de remboursement de : {customer.UserName}</h2>");
            body.Append($"<h2 style='color: #444;'>Numéro de la commande : {livreCommande.CommandeId}</h2>");
            body.Append("<p>Voici le récapitulatif :</p>");
            body.Append("<table style='width: 100%; border-collapse: collapse;'>");
            body.Append("<thead>");
            body.Append("<tr style='background-color: #f2f2f2;'>");
            body.Append("<th style='padding: 8px; border: 1px solid #ddd;'>Produit</th>");
            body.Append("<th style='padding: 8px; border: 1px solid #ddd;'>Quantité</th>");
            body.Append("<th style='padding: 8px; border: 1px solid #ddd;'>Prix</th>");
            body.Append("</tr>");
            body.Append("</thead>");
            body.Append("<tbody>");

            body.Append("<tr>");
            body.Append($"<td style='padding: 8px; border: 1px solid #ddd;'>{livreCommande.Livre.Titre}</td>");
            body.Append($"<td style='padding: 8px; border: 1px solid #ddd;'>{livreCommande.Quantite}</td>");
            body.Append(
                $"<td style='padding: 8px; border: 1px solid #ddd;'>{livreCommande.PrixAchat}$</td>");
            body.Append("</tr>");
            body.Append("</tbody>");
            body.Append("</table>");
            body.Append($"<p><strong>Total : {(livreCommande.PrixAchat * livreCommande.Quantite).ToString("C")}</strong></p>");
            body.Append($"<p><strong>Remboursement Stripe : </strong></p>");
            body.Append(
                "<a href=" + "https://dashboard.stripe.com/test/payments?status[0]=refunded&status[1]=refund_pending&status[2]=partially_refunded" + ">Aller sur stripe pour confirmer le remboursement</a>");
            body.Append($"<p><strong>Gestion des commandes : </strong></p>");
            body.Append("<a href=" + (BASE_URL_RAZOR + "/GestionCommandes").ToString() + ">Aller à la page de gestion des commandes</a>");
            body.Append("</div>");

            return body.ToString();
        }
    }
}
