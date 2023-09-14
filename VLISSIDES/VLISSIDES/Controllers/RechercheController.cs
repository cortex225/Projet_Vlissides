using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;
using VLISSIDES.Data;
using VLISSIDES.Models;
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
        [Route("/Recherche/Index")]
        public ActionResult Index(string motCle, string? critere)
        {
            List<Livre> TousLesLivres = _context.Livres.ToList();

            //Variables pour le regex
            string matchLivre = ".*" + motCle + ".*";

            List<Livre> livresRecherches;

            livresRecherches = _context.Livres
                    .Include(l => l.Auteur)
                    .Include(l => l.Categories)
                    .ToList();

            switch (critere) {
                default:
                    livresRecherches = TousLesLivres
                    .Where(livre => Regex.IsMatch(livre.Titre, matchLivre))
                    .ToList();
                break;
                case "titre":
                    livresRecherches = TousLesLivres
                    .Where(livre => Regex.IsMatch(livre.Titre, matchLivre))
                    .ToList();
                break;
                case "auteur":
                    livresRecherches = livresRecherches
                    .Where(livre => livre.Auteur.Any(auteur => Regex.IsMatch(auteur.NomComplet, matchLivre)))
                    .ToList();
                break;
                case "categorie":
                    livresRecherches = TousLesLivres
                    .Where(livre => livre.Categories.Any(categorie => Regex.IsMatch(categorie.Nom, matchLivre)))
                    .ToList();
                break;
            }

            IndexRechercheVM vm = new IndexRechercheVM
            {
                ResultatRecherche = livresRecherches,
                MotRecherche = motCle
            };

            return View(vm);
        }
    }
}
