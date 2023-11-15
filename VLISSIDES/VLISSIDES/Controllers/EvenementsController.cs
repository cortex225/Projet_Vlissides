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

            if (User.Identity.IsAuthenticated)
            {
                //Pour trouver les reservations du membres
                var userId = _userManager.GetUserId(HttpContext.User);
                var reservations = _context.Reservations.Include(r => r.Evenement).Where(r => r.MembreId == userId).ToList();
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
                        EstEnDemandeAnnuler = (bool)reservation.EnDemandeAnnuler
                    });
                }
                vm.MesEvenements = mesEvenements;

                //Evenements non reservés
                var evenements = _context.Evenements.Include(e => e.Reservations).ThenInclude(r => r.Membre).ToList();

                var nonReserve = evenements.Where(e => e.Reservations.Where(r => r.MembreId == userId) == null).ToList();

                vm.Evenements = _context.Evenements.Include(e => e.Reservations).ThenInclude(r => r.Membre).ToList()
                    .Where(e => e.Reservations.Where(r => r.MembreId == userId) != null)
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
                        EstEnDemandeAnnuler = false
                    }).ToList();

            }
            else
            {
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
            }

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
        public IActionResult SuccessAnnuler()
        {
            return View();
        }
        public IActionResult SuccessDemandeAnnuler()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AnnulerEvenement(string id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var reservation = _context.Reservations.Include(r => r.Evenement).FirstOrDefault(r => r.EvenementId == id && r.MembreId == userId);

            if (reservation != null)
            {
                if (reservation.Evenement.Prix == (decimal?)0.00)
                {
                    _context.Remove(reservation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("SuccessAnnuler", "Evenements");
                }
                else
                {
                    reservation.EnDemandeAnnuler = true;
                    await _context.SaveChangesAsync();
                    //Logo fourmi ailé
                    var logoUrl = Url.Content("http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");
                    //Nom de l'utilisateur
                    var username = _context.Users.FirstOrDefault(u => u.Id == userId).UserName;
                    await SendConfirmationEmailAdminAnnuler(username, reservation, logoUrl);
                    return RedirectToAction("SuccessDemandeAnnuler", "Evenements");
                }
            }
            return NotFound();
        }
        private async Task SendConfirmationEmailAdminAnnuler(string? username, Reservation reservation, string logoUrl)
        {
            var subject = "Confirmation de commande";

            // Construire le corps du courriel
            var body = BuildEmailAdminAnnulerBody(username, reservation, logoUrl);
            var emailAddress = _context.Users.FirstOrDefault(u => u.Id == "0").Email;
            // Envoyer le courriel avec la facture en pièce jointe
            await _sendGridEmail.SendEmailAsync(emailAddress, subject, body);
        }
        private string BuildEmailAdminAnnulerBody(string username, Reservation reservation, string logoUrl)
        {
            var body = new StringBuilder();
            body.Append("<div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>");
            body.Append(
                $"<img src='{logoUrl}' alt='Logo Fourmie Aillée' style='width:250px;height:auto; display: block; margin: 0 auto;'>");
            body.Append($"<h2 style='color: #444;'>Demande de remboursement de : {username}</h2>");
            body.Append($"<h2 style='color: #444;'>Numéro de la réservation : {reservation.Id}</h2>");
            body.Append("<p>Voici le récapitulatif :</p>");
            body.Append("<table style='width: 100%; border-collapse: collapse;'>");
            body.Append("<thead>");
            body.Append("<tr style='background-color: #f2f2f2;'>");
            body.Append("<th style='padding: 8px; border: 1px solid #ddd;'>Évenement</th>");

            body.Append("<th style='padding: 8px; border: 1px solid #ddd;'>Prix</th>");
            body.Append("</tr>");
            body.Append("</thead>");
            body.Append("<tbody>");

            body.Append("<tr>");
            body.Append($"<td style='padding: 8px; border: 1px solid #ddd;'>{reservation.Evenement.Nom}</td>");

            body.Append(
                $"<td style='padding: 8px; border: 1px solid #ddd;'>{reservation.Evenement.Prix.ToString()}$</td>");
            body.Append("</tr>");
            body.Append("</tbody>");
            body.Append("</table>");
            body.Append($"<p><strong>Total : {reservation.Evenement.Prix.ToString()}</strong></p>");
            body.Append($"<p><strong>Remboursement Stripe : </strong></p>");
            body.Append(
                "<a href=" + "https://dashboard.stripe.com/test/payments?status[0]=refunded&status[1]=refund_pending&status[2]=partially_refunded" + ">Aller sur stripe pour confirmer le remboursement</a>");
            body.Append($"<p><strong>Gestion des commandes : </strong></p>");
            body.Append("<a href=" + "https://sqlinfocg.cegepgranby.qc.ca/2147186" + ">Aller à la page de gestion de réservations</a>");
            body.Append("</div>");
            return body.ToString();
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
                Metadata = new Dictionary<string, string>
                {
                    { "type", "evenement" }, // Ici, vous indiquez que le type d'achat est "evenement"
                    { "evenementId", evenement.Id }, // Vous pouvez également ajouter d'autres informations utiles, comme l'ID de l'événement

                },
                InvoiceCreation = new SessionInvoiceCreationOptions
                {
                    Enabled = true,
                },
                AutomaticTax = new SessionAutomaticTaxOptions
                {
                    Enabled = false,
                },

                SuccessUrl = Url.Action("Success", "Evenements", null, Request.Scheme),
                CancelUrl = Url.Action("Cancel", "Evenements", null, Request.Scheme),
            };

            var service = new SessionService();
            Session session = service.Create(options);
            //var pi_options = new PaymentIntentCreateOptions()
            //{
            //    Amount = (long?)evenement.Prix * 100,
            //    Currency = "cad",
            //    PaymentMethodTypes = new List<string> { "card" },
            //};
            //var pi_service = new PaymentIntentService();
            //pi_service.Create(pi_options);
            return Json(new { id = session.Id });
        }

        //public IActionResult ShowRetournerConfirmation(string id)
        //{
        //    var userId = _userManager.GetUserId(HttpContext.User);

        //}
        //[HttpPost]
        //public async Task<StatusCodeResult> RefundStripe(string evenementId)
        //{
        //    var userId = _userManager.GetUserId(HttpContext.User);
        //    var StripeCustomerId = _context.Membres.FirstOrDefault(m => m.Id == userId).StripeCustomerId;

        //    var reservation = _context.Reservations.Include(r => r.Evenement).FirstOrDefault(r => r.EvenementId == evenementId && r.MembreId == userId);

        //    //Récupérer le paiement intent grâce au PaymentIntentId
        //    PaymentIntentService servicePaymentIntent = new PaymentIntentService();
        //    var paymentIntent = servicePaymentIntent.Get(reservation.PaymentIntentId);

        //    StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";

        //    var options = new RefundCreateOptions
        //    {
        //        PaymentIntent = paymentIntent.Id,
        //        Amount = (long?)(reservation.Evenement.Prix),
        //        Currency = "cad"
        //    };

        //    var service = new RefundService();
        //    service.Create(options);

        //    return Ok();
        //}

    }
}
