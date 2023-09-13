using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels;
using VLISSIDES.ViewModels.Accueil;

namespace VLISSIDES.Controllers;

public class AccueilController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AccueilController> _logger;

    public AccueilController(ApplicationDbContext context, ILogger<AccueilController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<_ServiceCardVM> services = new()
        {
            new _ServiceCardVM("img/jean-luc.png", "Perfection", "♥"), new _ServiceCardVM(), new _ServiceCardVM(),
            new _ServiceCardVM(), new _ServiceCardVM()
        };
        List<_EventCardVM> evenements = new()
        {
            new _EventCardVM("img/logo/Logo.png", "Existance", "♦"), new _EventCardVM(), new _EventCardVM(),
            new _EventCardVM(), new _EventCardVM()
        };
        List<_LivreCardVM> vedettes = new()
        {
            new _LivreCardVM("img/flat.png", "Titre", 6.66, new List<Auteur> { new() { Nom = "a", Prenom = "b" } },
                new List<Categorie> { new() { Nom = "♣" } }),
            new _LivreCardVM(), new _LivreCardVM(), new _LivreCardVM(), new _LivreCardVM()
        };
        List<_LivreCardVM> recommandations = new()
        {
            new _LivreCardVM("img/flat.png", "Ta vie", 0.69, new List<Auteur> { new() { Nom = "ka", Prenom = "a" } },
                new List<Categorie> { new() { Nom = "♠" } }),
            new _LivreCardVM(), new _LivreCardVM(), new _LivreCardVM(), new _LivreCardVM()
        };
        List<string> categories = new() { "1", "2", "3", "4", "5" };
        List<_LivreCardVM> livreCategories = new()
        {
            new _LivreCardVM("img/flat.png", "۞", 0.69, new List<Auteur> { new() { Nom = "123", Prenom = "654" } },
                new List<Categorie> { new() { Nom = "2" } }),
            new _LivreCardVM("img/flat.png", "۝", 0.69, new List<Auteur> { new() { Nom = "ڣ", Prenom = "ٻٸٷ" } },
                new List<Categorie> { new() { Nom = "2" } }),
            new _LivreCardVM(), new _LivreCardVM(), new _LivreCardVM()
        };
        return View(new IndexAccueilVM(services, evenements, vedettes, recommandations, categories, livreCategories));
    }

    public IActionResult Message(string titre, string message)
    {
        return View(new MessageVM(titre, message));
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}