using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Panier;
using VLISSIDES.ViewModels.Livres;

namespace VLISSIDES.Controllers
{
    public class PanierController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PanierController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, 
            IConfiguration config, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Panier/AjouterPanier")]
        //[Route("{controller}/{action}")]
        public async Task<IActionResult> AjouterPanier([FromBody]AjouterPanierVM vm)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser? user = _userManager.FindByIdAsync(userId).Result;

            TypeLivre? type = _context.TypeLivres.Find(vm.typeId);

            return RedirectToAction("Recherche/Details?id=" + vm.livreAjouteId);
        }
    }
}
