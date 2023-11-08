﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;
using System.Security.Claims;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Paiement;

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
            return View();
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
        public ActionResult CreateCheckoutSession(StripePaiementVM model)
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


            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",
                Customer = StripeCustomerId,
                AllowPromotionCodes = true,

                BillingAddressCollection = "required",// Demande à Stripe de collecter l'adresse de facturation du client
                ShippingAddressCollection = new SessionShippingAddressCollectionOptions
                {
                    AllowedCountries = new List<string> { "CA", "US" }, // Limite les adresses de livraison aux États-Unis et au Canada

                },
                CustomerUpdate = new SessionCustomerUpdateOptions
                {
                    Address = "auto", // Met à jour l'adresse du client lorsqu'il passe une commande
                    Name = "auto", // Met à jour le nom du client lorsqu'il passe une commande
                    Shipping = "auto", // Met à jour les informations d'expédition du client lorsqu'il passe une commande

                },
                Metadata = new Dictionary<string, string>
                {
                    { "type", "livre" }, // Ici, vous indiquez que le type d'achat est "livre"

                },
                InvoiceCreation = new SessionInvoiceCreationOptions
                {
                    Enabled = true,// Créez une facture pour chaque session de paiement
                },
                AutomaticTax = new SessionAutomaticTaxOptions
                {
                    Enabled = true, // Activez le calcul automatique des taxes
                },

                SuccessUrl = Url.Action("Success", "Paiement", null, Request.Scheme),
                CancelUrl = Url.Action("Cancel", "Paiement", null, Request.Scheme),
            };




            var service = new SessionService();
            Session session = service.Create(options);

            return Json(new { id = session.Id });
        }
    }
}
