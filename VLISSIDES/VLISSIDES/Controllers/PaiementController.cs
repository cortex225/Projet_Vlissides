using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using Stripe;
using Stripe.Checkout;
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

        [HttpPost]
        public ActionResult CreateCheckoutSession(StripePaiementVM model)
        {

            // Récupérez l'identifiant de l'utilisateur connecté
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var StripeCustomerId = _context.Membres.Where(m => m.Id == userId).FirstOrDefault().StripeCustomerId;

            // Récupérez les données de LivrePanier basées sur l'identifiant de l'utilisateur
            var panierItems = _context.LivrePanier
                .Where(lp => lp.UserId == userId)
                .Include(lp => lp.Livre).ThenInclude(livre => livre.LivreTypeLivres)
                .ToList();

            // Créez les articles de la session de paiement Stripe
            var lineItems = panierItems.Select(item => new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(item.Livre.LivreTypeLivres.FirstOrDefault().Prix)*100,
                    Currency = "cad",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = item.Livre.Titre,
                        Images = new List<string> { "https://sqlinfocg.cegepgranby.qc.ca/2167594/img/jean-luc.png" }
                    },

                },
                Quantity = item.Quantite,
            }).ToList();

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",
                CustomerEmail = _context.Users.Find(userId).Email,
                AllowPromotionCodes = true,
                BillingAddressCollection = "required",
                ShippingAddressCollection = new SessionShippingAddressCollectionOptions
                {
                    AllowedCountries = new List<string> { "CA", "US" },
                },
                AutomaticTax = new SessionAutomaticTaxOptions
                {
                    Enabled = true,
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
