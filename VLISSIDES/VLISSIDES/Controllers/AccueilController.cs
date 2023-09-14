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
            new _ServiceCardVM("img/book-icon.png", "Vente de livre", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vulputate turpis. Aliquam purus odio, consequat at pulvinar in, sollicitudin quis augue. Fusce eu magna mauris. Sed pretium, lorem at consectetur pretium, diam nulla faucibus purus, ac iaculis tellus purus at nulla."), new _ServiceCardVM(), new _ServiceCardVM(),
            new _ServiceCardVM(), new _ServiceCardVM()
        };
        List<_EventCardVM> evenements = new()
        {
            new _EventCardVM("img/logo/Logo.png", "Existance", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vulputate turpis. Aliquam purus odio, consequat at pulvinar in, sollicitudin quis augue. Fusce eu magna mauris. Sed pretium, lorem at consectetur pretium, diam nulla faucibus purus, ac iaculis tellus purus at nulla."),
            new _EventCardVM("img/logo/Logo.png"), new _EventCardVM("img/logo/Logo.png"),
            new _EventCardVM("img/logo/Logo.png"), new _EventCardVM("img/logo/Logo.png"),new _EventCardVM("img/logo/Logo.png")
        };
        List<_LivreCardVM> vedettes = new()
        {
            new _LivreCardVM("img/flat.png", "Ma vie avec l'équipe Vlissides", 6.66, new List<Auteur> { new() { Nom = "Vlissides", Prenom = "Team" } },
                new List<Categorie> { new() { Nom = "Horreur" } }),
            new _LivreCardVM("img/flat.png"), new _LivreCardVM("img/flat.png"), new _LivreCardVM("img/flat.png"), new _LivreCardVM("img/flat.png"),new _LivreCardVM("img/flat.png"),
            new _LivreCardVM("img/flat.png"), new _LivreCardVM("img/flat.png")
        };
        List<_LivreCardVM> recommandations = new()
        {
            new _LivreCardVM("img/flat.png", "Le chaperon rouge", 0.69, new List<Auteur> { new() { Nom = "Grimms", Prenom = "Frères" } },
                new List<Categorie> { new() { Nom = "Conte" } }),
            new _LivreCardVM("img/flat.png"), new _LivreCardVM("img/flat.png"), new _LivreCardVM("img/flat.png"), new _LivreCardVM("img/flat.png")
        };
        List<string> categories = new() { "1", "2", "3", "4", "5" };
        List<_LivreCardVM> livreCategories = new()
        {
            new _LivreCardVM("img/flat.png", "Fahrenheit 451", 0.69, new List<Auteur> { new() { Nom = "Bradbury", Prenom = "Ray" } },
                new List<Categorie> { new() { Nom = "Fiction Dystopie" } }),
            new _LivreCardVM("img/jean-luc.png", "Coder avec Jean-Luc", 40.99, new List<Auteur> { new() { Nom = "", Prenom = "Jean-Luc" } },
                new List<Categorie> { new() { Nom = "Informatique" } }),
            new _LivreCardVM("img/flat.png"), new _LivreCardVM("img/flat.png"), new _LivreCardVM("img/flat.png")
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