using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;
using System.Security.Claims;
using Stripe;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Paiement;
using VLISSIDES.ViewModels.Profile;

namespace VLISSIDES.Controllers
{
    public class PaiementController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ApplicationUser> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PaiementController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            RoleManager<IdentityRole> roleManager,
            ILogger<ApplicationUser> logger,
            ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor,
            IWebHostEnvironment webHostEnvironment,
            IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
            _roleManager = roleManager;
            _logger = logger;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
        }
        public IActionResult Index()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var adresse = _context.Adresses
                .Where(a => a.UtilisateurPrincipalId == currentUserId || a.UtilisateurLivraisonId == currentUserId)
                .Select(a => new AdresseVM
                {
                    AdresseId = a.Id,
                    NoCivique = a.NoCivique,
                    Rue = a.Rue,
                    NoApartement = a.NoApartement,
                    Ville = a.Ville,
                    Province = a.Province,
                    Pays = a.Pays,
                    CodePostal = a.CodePostal,
                })
                .ToList(); // Ajout de ToList pour exécuter la requête

            var adresseLivraisonVM = new StripePaiementVM
            {
                PaiementAdresseVM = new PaiementAdresseVM
                {
                    AdressesExistantes = adresse,
                    NouvelleAdresse = new AdresseVM() // Initialisation de NouvelleAdresse
                }
            };

            return View(adresseLivraisonVM);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "Panier");
        }
        [Route("Paiement/Success")]
        public IActionResult Success()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCheckoutSession([FromBody]StripePaiementVM model)
        {

            // Récupère l'identifiant de l'utilisateur connecté
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var StripeCustomerId = _context.Membres.Where(m => m.Id == userId).FirstOrDefault().StripeCustomerId;

            // Récupere les données de LivrePanier basées sur l'identifiant de l'utilisateur
            var panierItems = _context.LivrePanier
                .Where(lp => lp.UserId == userId)
                .Include(lp => lp.Livre).ThenInclude(livre => livre.LivreTypeLivres)
                .ToList();



            var lineItems = panierItems.Select(item =>
            {
                // Récupére l'URL de l'image du livre
                var imgLivreUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{item.Livre.Couverture}";
                var encodedImgLivreUrl = Uri.EscapeUriString(imgLivreUrl); // Encodez l'URL de l'image du livre pour qu'elle soit utilisable dans Stripe

                ViewBag.encodedImgLivreUrl = encodedImgLivreUrl;


                // Crée et retourne un SessionLineItemOptions pour chaque livre dans le panier
                return new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Livre.LivreTypeLivres.FirstOrDefault().Prix) * 100,
                        Currency = "cad",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Livre.Titre,
                            Images = new List<string> { encodedImgLivreUrl },
                        },

                    },
                    Quantity = item.Quantite,

                };
            }).ToList();
//Recuperation de l'adresse de la nouvelle adresse de livraison

        // Détermine si vous utilisez une nouvelle adresse ou une adresse existante
        string adresseId = string.IsNullOrEmpty(_context.Adresses.FirstOrDefault(a => a.Id == model.AdresseId).Id) ? Request.Form["adresseId"] : model.AdresseId;
        // Récupére l'adresse sélectionnée
        var selectedAddress = _context.Adresses.FirstOrDefault(a => a.Id == adresseId);

        // Crée un dictionnaire de métadonnées pour stocker les informations sur l'adresse sélectionnée
        var metadata = new Dictionary<string, string>
        {
            { "type", "livre" },
            { "adresseId", selectedAddress.Id },
            { "noCivique", selectedAddress.NoCivique },
            { "rue", selectedAddress.Rue },
            { "noApartement", selectedAddress.NoApartement },
            { "ville", selectedAddress.Ville },
            { "province", selectedAddress.Province },
            { "pays", selectedAddress.Pays },
            { "codePostal", selectedAddress.CodePostal },
        };

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",
                Customer = StripeCustomerId,
                AllowPromotionCodes = true,

                BillingAddressCollection = "required",// Demande à Stripe de collecter l'adresse de facturation du client
                // ShippingAddressCollection = new SessionShippingAddressCollectionOptions
                // {
                //     AllowedCountries = new List<string> { "CA", "US" }, // Limite les adresses de livraison aux États-Unis et au Canada
                //
                // },
                CustomerUpdate = new SessionCustomerUpdateOptions
                {
                    Address = "auto", // Met à jour l'adresse du client lorsqu'il passe une commande
                    Name = "auto", // Met à jour le nom du client lorsqu'il passe une commande
                    Shipping = "auto", // Met à jour les informations d'expédition du client lorsqu'il passe une commande

                },
                Metadata = metadata,
                InvoiceCreation = new SessionInvoiceCreationOptions
                {
                    Enabled = true,// Créez une facture pour chaque session de paiement
                },
                AutomaticTax = new SessionAutomaticTaxOptions
                {
                    Enabled = false, // Activez le calcul automatique des taxes
                },

                SuccessUrl = Url.Action("Success", "Paiement", null, Request.Scheme),
                CancelUrl = Url.Action("Cancel", "Paiement", null, Request.Scheme),
            };




            var service = new SessionService();
            Session session = service.Create(options);

            return Json(new { id = session.Id });
        }

        [HttpGet]
        public Adresse AdresseSelection(string id)
        {
            var adresse = _context.Adresses.FirstOrDefault(a => a.Id == id);

            return adresse;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnregistrerAdresse(PaiementAdresseVM paiementAdresseVM)
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);

            // Assurez-vous que le ViewModel contient les informations nécessaires
            if (paiementAdresseVM == null || paiementAdresseVM.NouvelleAdresse == null)
            {
                return Json(new { success = false, message = "Données d'adresse manquantes." });
            }

            if (ModelState.IsValid)
            {
                var nouvelleAdresse = paiementAdresseVM.NouvelleAdresse;

                var adresse = new Adresse
                {
                    UtilisateurLivraisonId = currentUserId,
                    UtilisateurPrincipalId = null,
                    NoApartement = nouvelleAdresse.NoApartement,
                    NoCivique = nouvelleAdresse.NoCivique,
                    Rue = nouvelleAdresse.Rue,
                    Ville = nouvelleAdresse.Ville,
                    Province = nouvelleAdresse.Province,
                    Pays = nouvelleAdresse.Pays,
                    CodePostal = nouvelleAdresse.CodePostal,
                    Id = Guid.NewGuid().ToString()


                };

                _context.Adresses.Add(adresse);
                await _context.SaveChangesAsync(); // Utilise la version asynchrone pour sauvegarder les changements
                return Json(
                    new { success = true, message = "Adresse enregistrée avec succès.", adresseId = adresse.Id });
            }

            // Si le modèle n'est pas valide, renvoye les erreurs de validation
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, message = "Erreur de validation.", errors = errors });
        }


    }
}
