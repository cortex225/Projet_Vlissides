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
        public ActionResult Index(List<string>? motCles, List<string>? criteres)
        {
            List<Livre> TousLesLivres = _context.Livres.ToList();

            //Variables pour le regex
            //string matchLivre = ".*" + motCles + ".*";

            List<Livre> livresRecherches;

            livresRecherches = _context.Livres
                    .Include(l => l.Auteur)
                    .Include(l => l.Categories)
                    .Include(l => l.Langues)
                    .Include(l => l.Evaluations)
                    .Include(l => l.MaisonEdition)
                    .ToList();
            if (motCles == null)
            {
                livresRecherches = new List<Livre>(); //Donne une liste vide car au cun
            }
            else if (criteres == null) //Lorsqu'il n'y a pas de criteres spécifiques
            {
                for (int i = 0; i <= motCles.Count(); ++i)
                {
                    livresRecherches = livresRecherches
                    .Where(livre => Regex.IsMatch(livre.Titre, ".*" + motCles[i] + ".*"))
                    .ToList();
                }
            }
            else if (criteres.Count > 0)
            {
                for (int i = 0; i < motCles.Count(); ++i)
                {
                    switch (criteres[i])
                    {
                        default:
                            livresRecherches = livresRecherches
                            .Where(livre => Regex.IsMatch(livre.Titre, ".*" + motCles[i] + ".*"))
                            .ToList();
                            break;
                        case "titre":
                            livresRecherches = livresRecherches
                            .Where(livre => Regex.IsMatch(livre.Titre, ".*" + motCles[i] + ".*"))
                            .ToList();
                            break;
                        case "auteur":
                            livresRecherches = livresRecherches
                            .Where(livre => livre.Auteur.Any(auteur => Regex.IsMatch(auteur.NomComplet, ".*" + motCles[i] + ".*")))
                            .ToList();
                            break;
                        case "categorie":
                            livresRecherches = livresRecherches
                            .Where(livre => livre.Categories.Any(categorie => Regex.IsMatch(categorie.Nom, ".*" + motCles[i] + ".*")))
                            .ToList();
                            break;
                        case "maisonEdition":
                            livresRecherches = livresRecherches
                            .Where(livre =>
                                livre.MaisonEdition != null &&
                                Regex.IsMatch(livre.MaisonEdition.Nom, ".*" + motCles[i] + ".*"))
                            .ToList();
                            break;
                        case "prix":
                            livresRecherches = livresRecherches
                            .Where(livre => livre.Categories.Any(categorie => Regex.IsMatch(categorie.Nom, ".*" + motCles[i] + ".*")))
                            .ToList();
                            break;
                        case "langue":
                            livresRecherches = livresRecherches
                            .Where(livre => livre.Langues.Any(langue => Regex.IsMatch(langue.Nom, ".*" + motCles[i] + ".*")))
                            .ToList();
                            break;
                    }
                }
            }
            else
            {
                livresRecherches = livresRecherches
                    .Where(livre => Regex.IsMatch(livre.Titre, ".*" + motCles[0] + ".*"))
                    .ToList();
            }

            IndexRechercheVM vm = new IndexRechercheVM
            {
                ResultatRecherche = livresRecherches,
                MotRecherche = motCles[0]
            };

            return View(vm);
        }
    }
}
