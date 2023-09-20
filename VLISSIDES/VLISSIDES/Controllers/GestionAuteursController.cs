using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VLISSIDES.Data;
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
            var auteurs = await _context.Auteurs.Include(a => a.Livres).Select(a =>
               new AfficherVM
               {
                   Id = a.Id,
                   Nom = a.Nom,
                   ListLivre = _context.Livres.Where(l => l.AuteurId == a.Id).ToList(),
                   _context.Auteurs.Where(a => a.Id == l.AuteurId).ToList()

               }).OrderBy(auteur => auteur.Nom).ToListAsync();
            return View(auteurs);
        }

        public async Task<IActionResult> AfficherLivre(string id)
        {
            var livres = await _context.Livres.Where(l => l.AuteurId == id).ToListAsync();
            return Json(PartialView(@"~/Views/Shared/PartialViews/Auteurs/_AfficherAuteurLivresPartial.cshtml", livres));
        }
    }
}
