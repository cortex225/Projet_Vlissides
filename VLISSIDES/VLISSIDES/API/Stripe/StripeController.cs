using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;
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
        private const string WebhookSecretApi = "whsec_duqdVrYBhqWnDL9kgYnoFE4rzByAE3Rk";
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

        [HttpPost("confirmation-paiement")]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent =
                    EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], WebhookSecretApi,throwOnApiVersionMismatch:false);

                var session=stripeEvent.Data.Object as Session;
                // Handle the event

                if (stripeEvent.Type == Events.CheckoutSessionAsyncPaymentFailed)
                {
                }
                else if (stripeEvent.Type == Events.CheckoutSessionAsyncPaymentSucceeded)
                {
                }
                else if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {

                    var customer =
                        await _context.Membres.FirstOrDefaultAsync(c => c.StripeCustomerId == session.CustomerId);
                    var panier = await _context.Paniers.FirstOrDefaultAsync(p => p.Id == customer.Id);
                    var panierItems = await _context.Paniers.Where(pi => pi.Id == panier.Id).ToListAsync();
                    var user = await _userManager.FindByIdAsync(customer.StripeCustomerId);
                    var userClaims = await _userManager.GetClaimsAsync(user);
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var userClaimsList = new List<string>();
                    var userRolesList = new List<string>();
                    foreach (var claim in userClaims)
                    {
                        userClaimsList.Add(claim.Value);
                    }

                    foreach (var role in userRoles)
                    {
                        userRolesList.Add(role);
                    }

                }
                else if (stripeEvent.Type == Events.CheckoutSessionExpired)
                {
                }
                else if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {
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
    }
}