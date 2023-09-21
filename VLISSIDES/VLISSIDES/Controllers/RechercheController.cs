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
        public ActionResult Index(string? motCles, string? criteres)
        {
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
                    .Include(l => l.Auteurs)
                    .Include(l => l.Categories)
                    .Include(l => l.Langue)
                    .Include(l => l.Evaluations)
                    .Include(l => l.MaisonEdition)
                    .ToList();
            if (motCles == null)
            {
                livresRecherches = new List<Livre>(); //Donne une liste vide car aucun
            }
            else if (criteres == null) //Lorsqu'il n'y a pas de criteres spécifiques
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
                            .Where(livre => livre.Auteurs.Any(auteur => Regex.IsMatch(auteur.NomComplet, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase)))
                            .ToList();
                            break;
                        case "categorie":
                            livresRecherches = livresRecherches
                            .Where(livre => livre.Categories.Any(categorie => Regex.IsMatch(categorie.Nom, listMotCles[i], RegexOptions.IgnoreCase)))
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
                            .Where(livre => Regex.IsMatch(livre.Langue.Nom, listMotCles[i], RegexOptions.IgnoreCase))
                            .ToList();
                            break;
                        case "typeLivre":
                            livresRecherches = livresRecherches
                            .Where(livre => Regex.IsMatch(livre.TypesLivre.Nom, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase))
                            .ToList();
                            break;
                        case "prixMin":
                            double prixMinD;
                            if (double.TryParse(listMotCles[i], out prixMinD))
                            {
                                livresRecherches = livresRecherches
                                    .Where(objet => objet.Prix >= prixMinD)
                                    .ToList();
                            }
                            break;

                        case "prixMax":
                            double prixMaxD;
                            if (double.TryParse(listMotCles[i], out prixMaxD))
                            {
                                livresRecherches = livresRecherches
                                    .Where(objet => objet.Prix <= prixMaxD)
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

            return View(vm);
        }
    }
}
