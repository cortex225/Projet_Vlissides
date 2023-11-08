using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Security.Claims;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionCommandes;
using VLISSIDES.ViewModels.HistoriqueCommandes;

namespace VLISSIDES.Controllers
{
    public class HistoriqueCommandes : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HistoriqueCommandes(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
            IConfiguration config, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
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
                PrixAchat = lc.PrixAchat
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
                PrixAchat = lc.PrixAchat
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

        [HttpPost]
        public ActionResult RefundCreateCheckoutSession(string commandeId, string livreId)
        {

            // Récupère l'identifiant de l'utilisateur connecté
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var StripeCustomerId = _context.Membres.Where(m => m.Id == userId).FirstOrDefault().StripeCustomerId;

            var vm = _context.LivreCommandes.FirstOrDefault(lc => lc.CommandeId == commandeId && lc.LivreId == livreId);

            var model = new StripeRefundVM
            {
                Prix = vm.PrixAchat,
                Quantite = vm.Quantite
            };
            // Récupere les données de LivrePanier basées sur l'identifiant de l'utilisateur
            //var panierItems = _context.LivrePanier
            //    .Where(lp => lp.UserId == userId)
            //    .Include(lp => lp.Livre).ThenInclude(livre => livre.LivreTypeLivres)
            //    .ToList();



            //var lineItems = panierItems.Select(item =>
            //{
            //    // Récupére l'URL de l'image du livre
            //    var imgLivreUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{item.Livre.Couverture}";
            //    var encodedImgLivreUrl = Uri.EscapeUriString(imgLivreUrl); // Encodez l'URL de l'image du livre pour qu'elle soit utilisable dans Stripe

            //    ViewBag.encodedImgLivreUrl = encodedImgLivreUrl;


            //    // Crée et retourne un SessionLineItemOptions pour chaque livre dans le panier
            //    return new SessionLineItemOptions
            //    {
            //        PriceData = new SessionLineItemPriceDataOptions
            //        {
            //            UnitAmount = (long)(item.Livre.LivreTypeLivres.FirstOrDefault().Prix) * 100,
            //            Currency = "cad",
            //            ProductData = new SessionLineItemPriceDataProductDataOptions
            //            {
            //                Name = item.Livre.Titre,
            //                Images = new List<string> { encodedImgLivreUrl },
            //            },
            //        },
            //        Quantity = item.Quantite,
            //    };
            //}).ToList();

            StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";

            var options = new RefundCreateOptions
            {
                //Charge = "ch_3OADrI2eZvKYlo2C0W9LzCya",
                Amount = (long?)(model.Quantite * (double)model.Prix),
                Currency = "cad"
            };

            //var options = new SessionCreateOptions
            //{
            //    PaymentMethodTypes = new List<string> { "card" },
            //    LineItems = lineItems,
            //    Mode = "payment",
            //    Customer = StripeCustomerId,
            //    AllowPromotionCodes = true,

            //    BillingAddressCollection = "required",
            //    ShippingAddressCollection = new SessionShippingAddressCollectionOptions
            //    {
            //        AllowedCountries = new List<string> { "CA", "US" },

            //    },
            //    CustomerUpdate = new SessionCustomerUpdateOptions
            //    {
            //        Address = "auto",
            //        Name = "auto",
            //        Shipping = "auto",

            //    },
            //    InvoiceCreation = new SessionInvoiceCreationOptions
            //    {
            //        Enabled = true,
            //    },
            //    AutomaticTax = new SessionAutomaticTaxOptions
            //    {
            //        Enabled = true,
            //    },

            //    SuccessUrl = Url.Action("Success", "Paiement", null, Request.Scheme),
            //    CancelUrl = Url.Action("Cancel", "Paiement", null, Request.Scheme),
            //};


            var service = new RefundService();
            service.Create(options);

            //var service = new SessionService();
            //Session session = service.Create(options);

            return Ok(); /*Json(new { id = session.Id });*/
        }
    }
}
