using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Data;
using VLISSIDES.ViewModels.Recherche;

namespace VLISSIDES.Controllers
{
    public class RechercheController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _config;

        public RechercheController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, IConfiguration config)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
        }

        // GET: RechercheController
        public ActionResult Index()
        {
            IndexRechercheVM vm = new IndexRechercheVM
            {
                ResultatRecherche = _context.Livres.Take(99).ToList(),
                MotRecherche = "Patate"
            };

            return View(vm);
        }
    }
}
