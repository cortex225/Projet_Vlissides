using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Paiement;
using VLISSIDES.ViewModels.Panier;
using VLISSIDES.ViewModels.Profile;

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

        // [HttpPost]
        // public async Task<IActionResult> SetPaymentInfo(string userId, string cardNumber, string expiryDate, string cvc)
        // {
        //     var user = await _context.Users.FindAsync(userId);
        //
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var paymentInfo = new PaymentInfo
        //     {
        //         CardNumber = cardNumber,
        //         ExpiryDate = expiryDate,
        //         CVC = cvc,
        //     };
        //     user.PaymentInfo = paymentInfo;
        //     await _context.SaveChangesAsync();
        //
        //     return Ok();
        // }

        [HttpPost("CompleteOrder")]
        public async Task<IActionResult> CompleteOrder(string userId, string stripeToken)
        {
            var user = await GetUserWithAddress(userId);
            if (user == null)
            {
                return NotFound();
            }

            var cartItems = await GetCartItems(userId);
            var stripePaiement = CreateStripePaymentVM(user, cartItems);

            PaymentMethod paymentMethod;
            try
            {
                paymentMethod = await CreatePaymentMethod();
            }
            catch (StripeException ex)
            {
                return BadRequest(ex.Message);
            }

            PaymentIntent paymentIntent;
            try
            {
                paymentIntent = await CreatePaymentIntent(stripePaiement, paymentMethod, stripeToken);
            }
            catch (StripeException ex)
            {
                return BadRequest(ex.Message);
            }

            if (paymentIntent.Status != "succeeded")
            {
                return BadRequest("Le paiement a échoué");
            }

            await UpdateInventory(cartItems);
            await CreateOrder(paymentIntent.Id, cartItems, user.AdressesLivraison.FirstOrDefault());

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

        private StripePaiementVM CreateStripePaymentVM(Membre user, List<LivrePanier> cartItems)
        {
            return new StripePaiementVM();
        }
//Creation de la methode de paiement avec une carte fictive
        private async Task<PaymentMethod> CreatePaymentMethod()
        {
            var paymentMethodOptions = new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Number = "4242424242424242",
                    ExpMonth = 12,
                    ExpYear = 2024,
                    Cvc = "123"
                },
            };

            var paymentMethodService = new PaymentMethodService();
            return await paymentMethodService.CreateAsync(paymentMethodOptions);
        }

        private async Task<PaymentIntent> CreatePaymentIntent(StripePaiementVM stripePaiement,
            PaymentMethod paymentMethod,
            string stripeToken)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = Convert.ToInt64(stripePaiement.PrixTotal * 100),
                Currency = "cad",
                PaymentMethod = stripeToken, // Utilisez le token au lieu de l'ID de la méthode de paiement
                Confirm = true,
            };
            var service = new PaymentIntentService();
            return await service.CreateAsync(options);
        }

        private async Task UpdateInventory(List<LivrePanier> cartItems)
        {
            // Implémenter la logique pour mettre à jour l'inventaire
            await Task.CompletedTask;
        }

        private async Task CreateOrder(string paymentIntentId, List<LivrePanier> cartItems, Adresse deliveryAddress)
        {
            // Implémenter la logique pour créer un enregistrement de commande
            await Task.CompletedTask;
        }
    }
}