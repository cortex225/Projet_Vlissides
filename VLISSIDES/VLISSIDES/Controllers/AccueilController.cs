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
            new _ServiceCardVM("img/book-icon.png", "Vente de livre",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vulputate turpis. Aliquam purus odio, consequat at pulvinar in, sollicitudin quis augue. Fusce eu magna mauris. Sed pretium, lorem at consectetur pretium, diam nulla faucibus purus, ac iaculis tellus purus at nulla."),
            new _ServiceCardVM("img/event.png", "Évènements",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vulputate turpis. Aliquam purus odio, consequat at pulvinar in, sollicitudin quis augue. Fusce eu magna mauris. Sed pretium, lorem at consectetur pretium, diam nulla faucibus purus, ac iaculis tellus purus at nulla."),
            new _ServiceCardVM("img/book-icon.png", "a",
                "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vulputate turpis. Aliquam purus odio, consequat at pulvinar in, sollicitudin quis augue. Fusce eu magna mauris. Sed pretium, lorem at consectetur pretium, diam nulla faucibus purus, ac iaculis tellus purus at nulla.\"")
        };
        List<_EventCardVM> evenements = new()
        {
            new _EventCardVM(
                "https://images.pexels.com/photos/8613089/pexels-photo-8613089.jpeg?auto=compress&cs=tinysrgb",
                "Soirée poésie",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vulputate turpis. "),
            new _EventCardVM(
                "https://images.pexels.com/photos/8617842/pexels-photo-8617842.jpeg?auto=compress&cs=tinysrgb"),
            new _EventCardVM(
                "https://images.pexels.com/photos/8613089/pexels-photo-8613089.jpeg?auto=compress&cs=tinysrgb",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vulputate turpis. "),
            new _EventCardVM(
                "https://images.pexels.com/photos/331723/pexels-photo-331723.jpeg?auto=compress&cs=tinysrgb"),
            new _EventCardVM("img/logo/Logo.png"),
            new _EventCardVM(
                "https://images.pexels.com/photos/2608517/pexels-photo-2608517.jpeg?auto=compress&cs=tinysrgb",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vulputate turpis. ")
        };
        List<_LivreCardVM> vedettes = new()
        {
            new _LivreCardVM("img/flat.png", "Ma vie avec l'équipe Vlissides", 6.66,
                new List<Auteur> { new() { NomAuteur = "Vlissides"} },
                new List<Categorie> { new() { Nom = "Horreur" } }),
            new _LivreCardVM("img/flat.png"),
            new _LivreCardVM("img/flat.png"),
            new _LivreCardVM("img/flat.png"),
            new _LivreCardVM("img/flat.png"),
            new _LivreCardVM("img/flat.png"),
            new _LivreCardVM("img/flat.png"),
            new _LivreCardVM("img/flat.png")
        };
        List<_LivreCardVM> recommandations = new()
        {
            new _LivreCardVM("img/flat.png", "Le chaperon rouge", 0.69,
                new List<Auteur> { new() { NomAuteur = "Grimms"} },
                new List<Categorie> { new() { Nom = "Conte" } }),
            new _LivreCardVM("img/flat.png"), new _LivreCardVM("img/flat.png"), new _LivreCardVM("img/flat.png"),
            new _LivreCardVM("img/flat.png")
        };
        List<string> categories = new() { "Humour", "Essai", "Faune - Flore", "Art de vivre", "Informatique" };
        List<_LivreCardVM> livreCategories = new()
        {
            new _LivreCardVM("img/flat.png", "Fahrenheit 451", 0.69,
                new List<Auteur> { new() { NomAuteur = "Bradbury"} },
                new List<Categorie> { new() { Nom = "Fiction Dystopie" } }),
            new _LivreCardVM("img/jean-luc.png", "Coder avec Jean-Luc", 40.99,
                new List<Auteur> { new() { NomAuteur = ""} },
                new List<Categorie> { new() { Nom = "Informatique" } }),
            new _LivreCardVM("img/flat.png"),
            new _LivreCardVM("img/flat.png"), new _LivreCardVM("img/flat.png"),
            new _LivreCardVM("img/flat.png")
        };
        List<_PromotionCardVM> promotionCards = new()
        {
            new _PromotionCardVM("Rabais de 10% sur les livres de programmation", 10, DateTime.MinValue,
                DateTime.MaxValue),
            new _PromotionCardVM("Rabais de 10% sur les livres de programmation", 10, DateTime.MinValue,
                DateTime.MaxValue),
            new _PromotionCardVM("Rabais de 10% sur les livres de programmation", 10, DateTime.MinValue,
                DateTime.MaxValue)
        };
        return View(new IndexAccueilVM(services, evenements, vedettes, recommandations, categories, livreCategories,
            promotionCards));
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