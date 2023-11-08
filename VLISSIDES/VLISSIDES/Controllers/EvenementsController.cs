using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;
using System.Security.Claims;
using System.Text;
using VLISSIDES.Data;
using VLISSIDES.Interfaces;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Evenements;
using VLISSIDES.ViewModels.GestionCommandes;

namespace VLISSIDES.Controllers
{
    public class EvenementsController : Controller
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
        private readonly ISendGridEmail _sendGridEmail;


        public EvenementsController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            RoleManager<IdentityRole> roleManager,
            ILogger<ApplicationUser> logger,
            ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor,
            IWebHostEnvironment webHostEnvironment,
            IConfiguration config,
            ISendGridEmail sendGridEmail)
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
            _sendGridEmail = sendGridEmail;
        }
        public IActionResult Index()
        {
            EvenementsIndexVM vm = new EvenementsIndexVM();
            /*
            if (User.Identity.IsAuthenticated)
            {
                //Pour trouver les reservations du membres
                var userId = _userManager.GetUserId(HttpContext.User);
                var reservations = _context.Reservations.Where(r => r.MembreId == userId).ToList();
                //Transformer les evenements réservé en vm
                List<EvenementsVM> mesEvenements = new List<EvenementsVM>();
                foreach (var reservation in reservations)
                {
                    mesEvenements.Add(new EvenementsVM()
                    {
                        Id = reservation.Evenement.Id,
                        Nom = reservation.Evenement.Nom,
                        Description = reservation.Evenement.Description,
                        DateDebut = reservation.Evenement.DateDebut,
                        DateFin = reservation.Evenement.DateFin,
                        Image = reservation.Evenement.Image,
                        Lieu = reservation.Evenement.Lieu,
                        NbPlaces = reservation.Evenement.Reservations == null ? reservation.Evenement.NbPlaces.ToString() + "/" + reservation.Evenement.NbPlaces.ToString() : (reservation.Evenement.NbPlaces - reservation.Evenement.Reservations.Count).ToString() + "/" + reservation.Evenement.NbPlaces.ToString(),
                        NbPlacesMembre = reservation.Evenement.Reservations == null ? reservation.Evenement.NbPlacesMembre.ToString() + "/" + reservation.Evenement.NbPlacesMembre.ToString() : (reservation.Evenement.NbPlacesMembre - reservation.Evenement.Reservations.Count()).ToString() + "/" + reservation.Evenement.NbPlacesMembre.ToString(),
                        Prix = reservation.Evenement.Prix,
                    });
                }
                vm.MesEvenements = mesEvenements;

                //Evenements non reservés
                vm.Evenements = _context.Evenements.Include(e => e.Reservations)
                    .Where(e => e.Reservations.Where(r => r.MembreId == userId) == null)
                    .Select(e => new EvenementsVM
                    {
                        Id = e.Id,
                        Nom = e.Nom,
                        Description = e.Description,
                        DateDebut = e.DateDebut,
                        DateFin = e.DateFin,
                        Image = e.Image,
                        Lieu = e.Lieu,
                        NbPlaces = e.Reservations == null ? e.NbPlaces.ToString() + "/" + e.NbPlaces.ToString() : (e.NbPlaces - e.Reservations.Count).ToString() + "/" + e.NbPlaces.ToString(),
                        NbPlacesMembre = e.Reservations == null ? e.NbPlacesMembre.ToString() + "/" + e.NbPlacesMembre.ToString() : (e.NbPlacesMembre - e.Reservations.Count()).ToString() + "/" + e.NbPlacesMembre.ToString(),
                        Prix = e.Prix,
                    }).ToList();

            }
            else
            {*/
            vm.Evenements = _context.Evenements.Include(e => e.Reservations).Select(e => new EvenementsVM
            {
                Id = e.Id,
                Nom = e.Nom,
                Description = e.Description,
                DateDebut = e.DateDebut,
                DateFin = e.DateFin,
                Image = e.Image,
                Lieu = e.Lieu,
                NbPlaces = e.Reservations == null ? e.NbPlaces.ToString() + "/" + e.NbPlaces.ToString() : (e.NbPlaces - e.Reservations.Count).ToString() + "/" + e.NbPlaces.ToString(),
                NbPlacesMembre = e.Reservations == null ? e.NbPlacesMembre.ToString() + "/" + e.NbPlacesMembre.ToString() : (e.NbPlacesMembre - e.Reservations.Count()).ToString() + "/" + e.NbPlacesMembre.ToString(),
                Prix = e.Prix,
            }).ToList();
            //}

            return View(vm);
        }
        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "Evenements");
        }
        [Route("Evenements/Success")]
        public IActionResult Success()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCheckoutSessionEvenement(string id)
        {
            // Récupère l'identifiant de l'utilisateur connecté
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var StripeCustomerId = _context.Membres.Where(m => m.Id == userId).FirstOrDefault().StripeCustomerId;

            // Récupère l'événement l'utilisateur veut s'inscrire pour
            var evenement = _context.Evenements.FirstOrDefault(e => e.Id == id);
            if (evenement == null) { return NotFound(); }
            //Récupère l'URL pour l'image de l'événement
            var imgEvenementUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{evenement.Image}";
            var encodedImgEvenementUrl = Uri.EscapeUriString(imgEvenementUrl); // Encodez l'URL de l'image du livre pour qu'elle soit utilisable dans Stripe

            ViewBag.encodedImgEvenementUrl = encodedImgEvenementUrl;
            //Créer l'item du paiement
            var lineItem = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = (evenement.Prix) * 100,
                    Currency = "cad",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = evenement.Nom,
                        Images = new List<string> { encodedImgEvenementUrl },
                    }

                },
                Quantity = 1,
            };
            //Les options pour ouvrir la session
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions> { lineItem },
                Mode = "payment",
                Customer = StripeCustomerId,
                AllowPromotionCodes = true,

                BillingAddressCollection = "required",
                ShippingAddressCollection = new SessionShippingAddressCollectionOptions
                {
                    AllowedCountries = new List<string> { "CA", "US" },

                },
                CustomerUpdate = new SessionCustomerUpdateOptions
                {
                    Address = "auto",
                    Name = "auto",
                    Shipping = "auto",

                },
                InvoiceCreation = new SessionInvoiceCreationOptions
                {
                    Enabled = true,
                },
                AutomaticTax = new SessionAutomaticTaxOptions
                {
                    Enabled = true,
                },

                SuccessUrl = Url.Action("Success", "Evenements", null, Request.Scheme),
                CancelUrl = Url.Action("Cancel", "Evenements", null, Request.Scheme),
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return Json(new { id = session.Id });
        }



    }
}
