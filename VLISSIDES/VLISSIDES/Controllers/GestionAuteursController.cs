using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionAuteurs;

namespace VLISSIDES.Controllers
{
    public class GestionAuteursController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GestionAuteursController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
            IConfiguration config)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new AuteursIndexVM();
            List<Auteur> liste = _context.Auteurs.Include(a => a.Livres).ToList();
            vm.ListeAuteurs = liste;
            return View(vm);
        }

        public async Task<IActionResult> AfficherLivre(List<Livre> listLivre)
        {

            return Json(listLivre);
        }
    }
}
