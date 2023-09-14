using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Index(string motCle)
        {
            List<Livre> TousLesLivres = _context.Livres.ToList();

            //Variables pour le regex
            string matchLivre = ".*" + motCle + ".*";
            List<Livre> livresRecherches = TousLesLivres
            .Where(livre => Regex.IsMatch(livre.Titre, matchLivre))
            .ToList();

            IndexRechercheVM vm = new IndexRechercheVM
            {
                ResultatRecherche = livresRecherches,
                MotRecherche = motCle
            };

            return View(vm);
        }
    }
}
