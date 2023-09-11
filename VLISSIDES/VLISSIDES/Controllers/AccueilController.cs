using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VLISSIDES.Data;
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
        List<_ServiceCardVM> services = new() { new("img/jean-luc.png", "Perfection", "♥"), new(), new(), new(), new() };
        List<_EventCardVM> evenements = new() { new("img/logo/Logo.png", "Existance", "♦"), new(), new(), new(), new() };
        List<_LivreCardVM> vedettes = new() { new("img/flat.png", "Titre", 6.66, new() { new() { Nom = "a", Prenom = "b" } }, new() { new() { Nom = "♣" } }), new(), new(), new(), new() };
        List<_LivreCardVM> recommandations = new() { new("img/flat.png", "Ta vie", 0.69, new() { new() { Nom = "ka", Prenom = "a" } }, new() { new() { Nom = "♠" } }), new(), new(), new(), new() };
        List<string> categories = new() { "1", "2", "3", "4", "5", };
        List<_LivreCardVM> livreCategories = new() { new("img/flat.png", "۞", 0.69, new() { new() { Nom = "123", Prenom = "654" } }, new() { new() { Nom = "2" } }), new("img/flat.png", "۝", 0.69, new() { new() { Nom = "ڣ", Prenom = "ٻٸٷ" } }, new() { new() { Nom = "2" } }), new(), new(), new() };
        return View(new IndexAccueilVM(services, evenements, vedettes, recommandations, categories, livreCategories));
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