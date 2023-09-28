﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult> Index(string? motCles, string? criteres, int page = 1)
        {
            var itemsPerPage = 10;
            var totalItems = await _context.Livres.CountAsync();
            
            List<string> listMotCles = new List<string>();
            if (motCles != null)
            {
                listMotCles = motCles.Split('|').ToList();
            }

            List<string> listCriteres = new List<string>();
            if (criteres != null)
            {
                listCriteres = criteres.Split('|').ToList();
            }

            List<Livre> TousLesLivres = _context.Livres.ToList();

            List<Categorie> listCategories = _context.Categories.ToList();
            List<Langue> listLangues = _context.Langues.ToList();
            List<TypeLivre> listTypeLivres = _context.TypeLivres.ToList();

            List<Livre> livresRecherches;

            livresRecherches = _context.Livres
                    .Include(l => l.Auteur)
                    .Include(l => l.Categorie)
                    .Include(l => l.Langues)
                    .Include(l => l.Evaluations)
                    .Include(l => l.MaisonEdition)
                    .Include(l => l.LivreTypeLivres)
                    .Skip((page - 1) * itemsPerPage) // Dépend de la page en cours
                    .Take(itemsPerPage) // Nombre d'items par page
                    .ToList();

            if (criteres == null) //Lorsqu'il n'y a pas de criteres spécifiques
            {
                for (int i = 0; i <= listMotCles.Count(); ++i)
                {
                    livresRecherches = livresRecherches
                    .Where(livre => Regex.IsMatch(livre.Titre, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase))
                    .ToList();
                }
            }
            else if (listCriteres.Count > 0)
            {
                for (int i = 0; i < listMotCles.Count(); ++i)
                {
                    switch (listCriteres[i])
                    {
                        default:
                            livresRecherches = livresRecherches
                            .Where(livre => Regex.IsMatch(livre.Titre, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase))
                            .ToList();
                            break;
                        case "titre":
                            livresRecherches = livresRecherches
                            .Where(livre => Regex.IsMatch(livre.Titre, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase))
                            .ToList();
                            break;
                        case "auteur":
                            livresRecherches = livresRecherches
                            .Where(livre => Regex.IsMatch(livre.Auteur.NomAuteur, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase))
                            .ToList();
                            break;
                        case "categorie":
                            livresRecherches = livresRecherches
                            .Where(livre => Regex.IsMatch(livre.Categorie.Nom, listMotCles[i], RegexOptions.IgnoreCase))
                            .ToList();
                            break;
                        case "maisonEdition":
                            livresRecherches = livresRecherches
                            .Where(livre =>
                                livre.MaisonEdition != null &&
                                Regex.IsMatch(livre.MaisonEdition.Nom, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase))
                            .ToList();
                            break;
                        case "langue":
                            livresRecherches = livresRecherches
                            .Where(livre => livre.Langues.Any(langue => Regex.IsMatch(langue.Nom, listMotCles[i], RegexOptions.IgnoreCase)))
                            .ToList();
                            break;
                        case "typeLivre":
                            livresRecherches = livresRecherches
                            .Where(livre => livre.LivreTypeLivres.Any(type => Regex.IsMatch(type.TypeLivre.Nom, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase)))
                            .ToList();
                            break;
                        case "prixMin":
                            decimal prixMinD;
                            if (decimal.TryParse(listMotCles[i], out prixMinD))
                            {
                                livresRecherches = livresRecherches
                                    .Where(objet => objet.LivreTypeLivres.FirstOrDefault().Prix >= prixMinD)
                                    .ToList();
                            }
                            break;

                        case "prixMax":
                            decimal prixMaxD;
                            if (decimal.TryParse(listMotCles[i], out prixMaxD))
                            {
                                livresRecherches = livresRecherches
                                    .Where(objet => objet.LivreTypeLivres.FirstOrDefault().Prix <= prixMaxD)
                                    .ToList();
                            }
                            break;
                    }
                }
            }
            else
            {
                
                
                livresRecherches = livresRecherches
                    .Where(livre => Regex.IsMatch(livre.Titre, ".*" + listMotCles[0] + ".*", RegexOptions.IgnoreCase))
                    .ToList();
                
               
            }
            IndexRechercheVM vm;
            if (motCles == null)
            {
                vm = new IndexRechercheVM
                {
                    ResultatRecherche = livresRecherches,
                    MotRecherche = "",
                    ListeCategories = listCategories,
                    ListeLangues = listLangues,
                    ListeTypeLivres = listTypeLivres
                };
            }
            else
            {
                vm = new IndexRechercheVM
                {
                    ResultatRecherche = livresRecherches,
                    MotRecherche = listMotCles[0],
                    ListeCategories = listCategories,
                    ListeLangues = listLangues,
                    ListeTypeLivres = listTypeLivres
                };
            }

            //ViewBag qui permet de savoir le nom de l'action
            ViewBag.ActionName = "Index";
            //ViewBag qui permet de savoir sur quelle page on est et le nombre de pages total
            //Math.Ceiling permet d'arrondir au nombre supérieur
            // ReSharper disable once HeapView.BoxingAllocation
            ViewBag.CurrentPage = page;
            // ReSharper disable once HeapView.BoxingAllocation
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);
            
            return View(vm);
        }

        // GET: RechercheController
        [Route("/Recherche/Details")]
        public ActionResult Details(string id)
        {
            Livre? monLivre = _context.Livres
                    .Include(l => l.Auteur)
                    .Include(l => l.Categorie)
                    .Include(l => l.Langues)
                    .Include(l => l.Evaluations)
                    .Include(l => l.MaisonEdition)
                    .Include(l => l.LivreTypeLivres)
                    .FirstOrDefault(l => l.Id == id);


            DetailsLivreVM vm;

            if (monLivre == null) {
                vm = new DetailsLivreVM();
            } else {
                vm = new DetailsLivreVM
                {
                    Id = monLivre.Id,
                    Titre = monLivre.Titre,
                    lAuteur = monLivre.Auteur,
                    laCategorie = monLivre.Categorie,
                    Prix = monLivre.LivreTypeLivres.FirstOrDefault()?.Prix,
                    DatePublication = monLivre.DatePublication,
                    Couverture = monLivre.Couverture,
                    maisonEdition = monLivre.MaisonEdition,
                    NbPages = monLivre.NbPages,
                    Resume = monLivre.Resume,
                    NbExemplaires = monLivre.NbExemplaires,
                    LivreTypeLivres = monLivre.LivreTypeLivres,
                    
                };
            }

            return View(vm);
        }
    }
}
