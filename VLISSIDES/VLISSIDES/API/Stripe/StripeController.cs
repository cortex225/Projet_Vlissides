using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Data;
using VLISSIDES.Models;

namespace VLISSIDES.API.Stripe
{
    [Route("webhooks/stripe")]
    [ApiController]
    public class StripeController : Controller
    {
        private const string WebhookSecretCreate = "whsec_CxXnEwcssnyUUPPm3JHXuGKarGmWIF6Y";
        private const string WebhookSecretPayement = "whsec_YqEE9Jvju6lSOC2yslwPzunmCVKZKW5n";
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
