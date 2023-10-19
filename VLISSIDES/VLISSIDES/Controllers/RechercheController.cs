﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Web.WebPages;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Recherche;

namespace VLISSIDES.Controllers;

public class RechercheController : Controller
{
    private readonly IConfiguration _config;
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public RechercheController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
        IConfiguration config)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        _config = config;
    }

    // GET: RechercheController
    //[Route("2147186/Recherche/Index")]
    //[Route("{controller}/{action}")]
    public ActionResult Index(string? motCles, string? criteres)
    {
        var listMotCles = new List<string>();
        if (motCles != null) listMotCles = motCles.Split('|').ToList();

        var listCriteres = new List<string>();
        if (criteres != null) listCriteres = criteres.Split('|').ToList();

        var TousLesLivres = _context.Livres.ToList();

        var listCategories = _context.Categories.ToList();
        var listLangues = _context.Langues.ToList();
        var listTypeLivres = _context.TypeLivres.ToList();

        List<Livre> livresRecherches;

        livresRecherches = _context.Livres
            .Include(l => l.LivreAuteurs)
            .ThenInclude(la => la.Auteur)
            .Include(l => l.Categories)
            .ThenInclude(lc => lc.Categorie)
            .Include(l => l.Langue)
            .Include(l => l.Evaluations)
            .Include(l => l.MaisonEdition)
            .Include(l => l.LivreTypeLivres)
            .ThenInclude(ltl => ltl.TypeLivre)
            .ToList();

        if (criteres.IsEmpty()) //Lorsqu'il n'y a pas de criteres spécifiques
            for (var id = 0; id < listMotCles.Count(); ++id)
                livresRecherches = livresRecherches
                    .Where(livre => Regex.IsMatch(livre.Titre, ".*" + (listMotCles.Any() ? listMotCles[id] : "") + ".*", RegexOptions.IgnoreCase))
                    .ToList();
        else if (listCriteres.Count > 0)
            for (var i = 0; i < listMotCles.Count(); ++i)
                switch (listCriteres[i])
                {
                    default:
                        livresRecherches = livresRecherches
                            .Where(livre =>
                                Regex.IsMatch(livre.Titre, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase))
                            .ToList();
                        break;
                    case "titre":
                        livresRecherches = livresRecherches
                            .Where(livre =>
                                Regex.IsMatch(livre.Titre, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase))
                            .ToList();
                        break;
                    case "auteur":
                        livresRecherches = livresRecherches
                            .Where(livre => livre.LivreAuteurs.Any(la =>
                                la.Auteur != null
                                    ? Regex.IsMatch(la.Auteur.NomAuteur, ".*" + listMotCles[i] + ".*",
                                        RegexOptions.IgnoreCase)
                                    : false))
                            .ToList();
                        break;
                    case "categorie":
                        livresRecherches = livresRecherches
                            .Where(livre => livre.Categories.Any(lc =>
                                Regex.IsMatch(lc.Categorie.Nom, listMotCles[i], RegexOptions.IgnoreCase)))
                            .ToList();
                        break;
                    case "maisonEdition":
                        livresRecherches = livresRecherches
                            .Where(livre =>
                                livre.MaisonEdition != null &&
                                Regex.IsMatch(livre.MaisonEdition.Nom, ".*" + listMotCles[i] + ".*",
                                    RegexOptions.IgnoreCase))
                            .ToList();
                        break;
                    case "langue":
                        livresRecherches = livresRecherches
                            .Where(livre =>
                                livre.Langue != null
                                    ? Regex.IsMatch(livre.Langue.Nom, listMotCles[i], RegexOptions.IgnoreCase)
                                    : false)
                            .ToList();
                        break;
                    case "typeLivre":
                        livresRecherches = livresRecherches
                            .Where(livre => livre.LivreTypeLivres.Any(type =>
                                Regex.IsMatch(type.TypeLivre.Nom, ".*" + listMotCles[i] + ".*",
                                    RegexOptions.IgnoreCase)))
                            .ToList();
                        break;
                    case "prixMin":
                        decimal prixMinD;
                        if (decimal.TryParse(listMotCles[i], out prixMinD))
                            livresRecherches = livresRecherches
                                .Where(objet => objet.LivreTypeLivres.FirstOrDefault().Prix >= prixMinD)
                                .ToList();
                        break;

                    case "prixMax":
                        decimal prixMaxD;
                        if (decimal.TryParse(listMotCles[i], out prixMaxD))
                            livresRecherches = livresRecherches
                                .Where(objet => objet.LivreTypeLivres.FirstOrDefault().Prix <= prixMaxD)
                                .ToList();
                        break;
                }
        else
            livresRecherches = livresRecherches
                .Where(livre => Regex.IsMatch(livre.Titre, ".*" + listMotCles[0] + ".*", RegexOptions.IgnoreCase))
                .ToList();

        return View(new IndexRechercheVM(motCles, livresRecherches, listCategories, listLangues, listTypeLivres));
    }

    // GET: RechercheController
    //[Route("/Recherche/Details")]
    public ActionResult Details(string id)
    {
        //var listTypeLivres = _context.TypeLivres.ToList();

        var livre = _context.Livres
            .Include(l => l.LivreAuteurs)
            .ThenInclude(la => la.Auteur)
            .Include(l => l.Categories)
            .ThenInclude(lc => lc.Categorie)
            .Include(l => l.Langue)
            .Include(l => l.Evaluations)
            .Include(l => l.MaisonEdition)
            .Include(l => l.LivreTypeLivres)
            .ThenInclude(ltl => ltl.TypeLivre)
            .FirstOrDefault(l => l.Id == id);

        if (livre == null) return NotFound();

        return View(new DetailsLivreVM(livre.Id, livre.Titre, livre.LivreAuteurs.Select(la => la.Auteur),
            livre.Categories.Select(lc => lc.Categorie), livre.DatePublication, livre.Couverture, livre.MaisonEdition,
            livre.NbPages, livre.Resume, livre.NbExemplaires, livre.LivreTypeLivres));
    }
}