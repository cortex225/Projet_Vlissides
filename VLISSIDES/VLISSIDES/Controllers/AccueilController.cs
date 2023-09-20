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
        List<ServiceCardVM> services = new()
        {
            new ServiceCardVM("img/book-icon.png", "Boutique en ligne ",
                "Découvrez notre vaste sélection de livres neufs et numériques. Recherchez facilement parmi vos auteurs, genres ou éditeurs préférés et profitez d'une livraison rapide. Notre stock en temps réel vous assure de trouver ce que vous cherchez.","fa-solid fa-cart-shopping"),
            new ServiceCardVM("img/event.png", "Événements et Activités",
                "Plongez dans le monde littéraire avec nos événements exclusifs ! De la poésie aux ateliers d'écriture, réservez votre place en ligne et rejoignez une communauté passionnée de littérature.","fa-solid fa-calendar-check"),
            new ServiceCardVM("img/book-icon.png", "Programme Éco-responsable",
                "Faites un choix éco-responsable lors de vos achats. Participez à notre initiative de réduction de l'empreinte écologique et contribuez à la plantation d'arbres. Ensemble, faisons une différence !","fa-brands fa-pagelines"),
            new ServiceCardVM("img/book-icon.png", "Promotions et Offres spéciales  ",
                "Ne manquez pas nos offres exceptionnelles ! Découvrez les promotions du moment, bénéficiez de rabais exclusifs et profitez de réductions spéciales pour nos membres.","fa-solid fa-tags"),
            new ServiceCardVM("img/book-icon.png", "Espace Membre",
                "Devenez membre gratuitement et accédez à des avantages exclusifs. Gérez votre profil, suivez vos commandes et réservations, et profitez d'une expérience d'achat personnalisée.",
                "fa-solid fa-user-group"),

        };
        List<EventCardVM> evenements = new()
        {
            new EventCardVM(
                "https://images.pexels.com/photos/8613089/pexels-photo-8613089.jpeg?auto=compress&cs=tinysrgb",
                "Soirée poésie",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vulputate turpis. "),
            new EventCardVM(
                "https://images.pexels.com/photos/8617842/pexels-photo-8617842.jpeg?auto=compress&cs=tinysrgb"),
            new EventCardVM(
                "https://images.pexels.com/photos/8613089/pexels-photo-8613089.jpeg?auto=compress&cs=tinysrgb",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vulputate turpis. "),
            new EventCardVM(
                "https://images.pexels.com/photos/331723/pexels-photo-331723.jpeg?auto=compress&cs=tinysrgb"),
            new EventCardVM("img/logo/Logo.png"),
            new EventCardVM(
                "https://images.pexels.com/photos/2608517/pexels-photo-2608517.jpeg?auto=compress&cs=tinysrgb",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac vulputate turpis. ")
        };
        List<LivreCardVM> vedettes = new()
        {
            new LivreCardVM("img/flat.png", "Ma vie avec l'équipe Vlissides", 6.66,
                new List<Auteur> { new() { Nom = "Vlissides", Prenom = "Équipe" } },
                new List<Categorie> { new() { Nom = "Horreur" } }),
            new LivreCardVM("img/flat.png"),
            new LivreCardVM("img/flat.png"),
            new LivreCardVM("img/flat.png"),
            new LivreCardVM("img/flat.png"),
            new LivreCardVM("img/flat.png"),
            new LivreCardVM("img/flat.png"),
            new LivreCardVM("img/flat.png")
        };
        List<LivreCardVM> recommandations = new()
        {
            new LivreCardVM("img/flat.png", "Le chaperon rouge", 0.69,
                new List<Auteur> { new() { Nom = "Grimms", Prenom = "Frères" } },
                new List<Categorie> { new() { Nom = "Conte" } }),
            new LivreCardVM("img/flat.png"), new LivreCardVM("img/flat.png"), new LivreCardVM("img/flat.png"),
            new LivreCardVM("img/flat.png")
        };
        List<string> categories = new() { "Humour", "Essai", "Faune - Flore", "Art de vivre", "Informatique" };
        List<LivreCardVM> livreCategories = new()
        {
            new LivreCardVM("img/flat.png", "Fahrenheit 451", 0.69,
                new List<Auteur> { new() { Nom = "Bradbury", Prenom = "Ray" } },
                new List<Categorie> { new() { Nom = "Fiction Dystopie" } }),
            new LivreCardVM("img/jean-luc.png", "Coder avec Jean-Luc", 40.99,
                new List<Auteur> { new() { Nom = "", Prenom = "Jean-Luc" } },
                new List<Categorie> { new() { Nom = "Informatique" } }),
            new LivreCardVM("img/flat.png"),
            new LivreCardVM("img/flat.png"), new LivreCardVM("img/flat.png"),
            new LivreCardVM("img/flat.png")
        };
        List<PromotionCardVM> promotionCards = new()
        {
            new PromotionCardVM("Rabais de 10% sur les livres de programmation", 10, DateTime.MinValue,
                DateTime.MaxValue),
            new PromotionCardVM("Rabais de 10% sur les livres de programmation", 10, DateTime.MinValue,
                DateTime.MaxValue),
            new PromotionCardVM("Rabais de 10% sur les livres de programmation", 10, DateTime.MinValue,
                DateTime.MaxValue)
        };
        return View(new IndexAccueilVM(services, evenements, vedettes, recommandations, categories, livreCategories,
            promotionCards));
    }

    public IActionResult Message(string titre, string message)
    {
        return View(new MessageVM(titre, message));
    }
    public IActionResult Info() => View();

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