using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using VLISSIDES.Data;
using VLISSIDES.Models;

namespace VLISSIDES.API.Stripe
{
    [Route("webhooks/stripe")]
    [ApiController]
    public class StripeController : Controller
    {
        private const string WebhookSecretCreate = "whsec_CxXnEwcssnyUXXXXXXXXXXXX";
        private const string WebhookSecretPayement = "whsec_YqEE9Jvju6XXXXXXXXXXXXX";
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
            ILogger<ApplicationUser> logger,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            IUserStore<ApplicationUser> userStore,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config,
            IHttpContextAccessor httpContextAccessor,
            IWebHostEnvironment webHostEnvironment
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            _userStore = userStore;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], WebhookSecretCreate);

                // Handle the event
                if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {
                    var paymentIntent = (PaymentIntent)stripeEvent.Data.Object;
                    _logger.LogInformation($"PaymentIntent was successful: {paymentIntent.Id}");
                    // TODO: Add your business logic here
                }
                // Other event types can be handled here

                return Ok();
            }
            catch (StripeException e)
            {
                _logger.LogError($"Stripe webhook failed: {e.Message}");
                return BadRequest();
            }
        }

    }
}