using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Paiement;
using VLISSIDES.ViewModels.Panier;
using VLISSIDES.ViewModels.Profile;
using Stripe.Checkout;

namespace VLISSIDES.API.Stripe
{
    [ApiController]
    [Route("api/[controller]")]
    public class StripeController : Controller
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

        public StripeController(
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
        // [HttpPost]
        public async Task<IActionResult> SetDeliveryAddress(string userId, string addressId)
        {
            var user = await _context.Users.FindAsync(userId);
            var address = await _context.Adresses.FindAsync(addressId);

            if (user == null || address == null)
            {
                return NotFound();
            }

            user.AdressesLivraison.FirstOrDefault().Id = addressId;
            await _context.SaveChangesAsync();

            return Ok();

             }

        [HttpPost("CompleteOrder")]
        public async Task<IActionResult> CompleteOrder([FromBody] StripePaiementVM paymentData)
        {
            // var stripeCustomerId = paymentData.StripeCustomerId;
            var stripeCustomerId = "cus_Os2AwQNQdo2umB";

            string userId = paymentData.UserId;

            // Appeler GetUserWithAddress pour obtenir des informations sur l'utilisateur
            var user = await GetUserWithAddress(userId);
            if (user == null)
            {
                return NotFound("L'utilisateur n'a pas été trouvé.");
            }

            // Appeler GetCartItems pour obtenir les articles dans le panier
            var cartItems = await GetCartItems(userId);
            if (cartItems == null || !cartItems.Any())
            {
                return BadRequest("Aucun article trouvé dans le panier.");
            }

            // Appeler CreateStripePaymentVM pour créer une instance de StripePaiementVM
            var stripePaymentVM = await CreateStripePaymentVM(user, cartItems);
            if (stripePaymentVM == null)
            {
                return BadRequest("Impossible de créer StripePaiementVM.");
            }

            PaymentIntent paymentIntent;
            try
            {
                paymentIntent = new PaymentIntent();

            }
            catch (StripeException ex)
            {
                return BadRequest(ex.Message);
            }


            if (paymentData == null)
            {
                return BadRequest("Les données requises sont manquantes ou invalides.");
            }



            if (paymentIntent.Status != "succeeded")
            {
                return BadRequest("Le paiement a échoué");
            }

            await UpdateInventory(paymentData.Livres);
            await CreateOrder(paymentIntent.Id, paymentData.Livres,
                paymentData.Adresse);

            return Ok();
        }


        private async Task<Membre> GetUserWithAddress(string userId)
        {
            return await _context.Membres
                .Include(x => x.AdressesLivraison).FirstOrDefaultAsync(u => u.Id == userId);
        }

        private async Task<List<LivrePanier>> GetCartItems(string userId)
        {
            return await _context.LivrePanier
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Livre)
                .Include(ci => ci.TypeLivre)
                .ToListAsync();
        }

        private async Task<StripePaiementVM> CreateStripePaymentVM(ApplicationUser user, List<LivrePanier> cartItems)
        {
            var memberId = user.Id;
            var member = await _context.Membres.FindAsync(memberId);
            var stripeCustomerId = member.StripeCustomerId;



            var paymentVM = new StripePaiementVM
            {
                StripeCustomerId = stripeCustomerId,
                UserId = memberId,
            };

            return paymentVM;
        }

        private async Task<PaymentIntent> CreatePaymentIntent(StripePaiementVM stripePaiement, string stripeToken)
        {
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = 2000,
                            Currency = "cad",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "T-shirt"
                            },
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",

                AutomaticTax = new SessionAutomaticTaxOptions { Enabled = true },
            };
            var service = new SessionService();
            Session session = service.Create(options);
            Response.Headers.Add("Location", session.Url);
            return await Task.FromResult(new PaymentIntent());
        }







        private async Task UpdateInventory(List<AfficherPanierVM>? cartItems)
        {
            // Implémenter la logique pour mettre à jour l'inventaire
            await Task.CompletedTask;
        }

        private async Task CreateOrder(string paymentIntentId, List<AfficherPanierVM>? cartItems, ProfileModifierAdressesVM deliveryAddress)
        {
            // Implémenter la logique pour créer un enregistrement de commande
            await Task.CompletedTask;
        }
    }
}