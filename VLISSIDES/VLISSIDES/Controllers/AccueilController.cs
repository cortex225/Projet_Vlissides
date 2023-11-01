using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
            new ServiceCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/book-icon.png", "Boutique en ligne ",
                "Découvrez notre vaste sélection de livres neufs et numériques. Recherchez facilement parmi vos auteurs, genres ou éditeurs préférés et profitez d'une livraison rapide. Notre stock en temps réel vous assure de trouver ce que vous cherchez.",
                "fa-solid fa-cart-shopping"),
            new ServiceCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/event.png", "Événements et Activités",
                "Plongez dans le monde littéraire avec nos événements exclusifs ! De la poésie aux ateliers d'écriture, réservez votre place en ligne et rejoignez une communauté passionnée de littérature.",
                "fa-solid fa-calendar-check"),
            new ServiceCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/book-icon.png",
                "Programme Éco-responsable",
                "Faites un choix éco-responsable lors de vos achats. Participez à notre initiative de réduction de l'empreinte écologique et contribuez à la plantation d'arbres. Ensemble, faisons une différence !",
                "fa-brands fa-pagelines"),
            new ServiceCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/book-icon.png",
                "Promotions et Offres spéciales  ",
                "Ne manquez pas nos offres exceptionnelles ! Découvrez les promotions du moment, bénéficiez de rabais exclusifs et profitez de réductions spéciales pour nos membres.",
                "fa-solid fa-tags"),
            new ServiceCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/book-icon.png", "Espace Membre",
                "Devenez membre gratuitement et accédez à des avantages exclusifs. Gérez votre profil, suivez vos commandes et réservations, et profitez d'une expérience d'achat personnalisée.",
                "fa-solid fa-user-group")
        };
        List<EventCardVM> evenements = new()
        {
            new EventCardVM(
                "/img/images_Events/pinocio.png",
                "Projet Pinochio (5 ans et plus)",
                "Matières chorégraphiques d’exception, ces métamorphoses fantastiques permettent d’évoquer les tourments du corps," +
                " les revirements de l’âme, les changements auxquels nous sommes toutes" +
                " et tous confrontés. La chorégraphe déconstruit le récit pour en extraire sa subtile essence.",
                new DateTime(2023, 08, 01, 14, 00, 00), new DateTime(2023, 08, 01, 14, 00, 00), 20, 0, 0,
                "Salle de spectacle", 0),

            new EventCardVM(
                "/img/images_Events/reve.png",
                "Rêves à colorier",
                "Aventure musicale haute-voltige qui allie la chanson, le théâtre d’objets et la littérature." +
                " et tous confrontés. La chorégraphe déconstruit le récit pour en extraire sa subtile essence.",
                new DateTime(2023, 08, 01, 14, 00, 00), new DateTime(2023, 08, 01, 14, 00, 00), 25, 0, 15,
                "Salle de spectacle", 8),
            new EventCardVM(
                "/img/images_Events/Heli.png",
                "Héli, l’enfant cerf-volant",
                "À l’ère du numérique et des fausses nouvelles, ce spectacle foisonnant interroge notre rapport à la mémoire et braque les projecteurs" +
                " sur les limites parfois floues entre la fiction et la réalité.\r\nAtelier d’écriture pour les 12-16 ans\r\n",
                new DateTime(2023, 08, 01, 14, 00, 00), new DateTime(2023, 08, 01, 14, 00, 00), 25, 0, 0,
                "Salle de spectacle", 0),
            new EventCardVM(
                "https://sqlinfocg.cegepgranby.qc.ca/2167594/img/flat.png",
                "Atelier d’écriture pour les 12-16 ans",
                "Un atelier d’écriture pour les 12-16 ans sera offert en lien avec le spectacle. Les jeunes participants seront invités à écrire un texte",
                new DateTime(2023, 08, 01, 14, 00, 00), new DateTime(2023, 08, 01, 14, 00, 00), 30, 0, 15,
                "Salle de lecture", 0)
        };
        List<LivreCardVM> vedettes = new()
        {
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png",
                "Ma vie avec l'équipe Vlissides", (decimal)6.66,
                new Auteur { NomAuteur = "Vlissides" },
                new Categorie { Nom = "Horreur" }),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png"),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png"),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png"),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png"),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png"),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png"),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png")
        };
        List<LivreCardVM> recommandations = new()
        {
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png", "Le chaperon rouge",
                (decimal)0.69,
                new Auteur { NomAuteur = "Grimms" },
                new Categorie { Nom = "Conte" }),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png"),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png"),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png"),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png")
        };
        List<string> categories = new() { "Humour", "Essai", "Faune - Flore", "Art de vivre", "Informatique" };
        List<LivreCardVM> livreCategories = new()
        {
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png", "Fahrenheit 451", (decimal)0.69,
                new Auteur { NomAuteur = "Bradbury" },
                new Categorie { Nom = "Fiction Dystopie" }),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/jean-luc.png", "Coder avec Jean-Luc",
                (decimal)40.99,
                new Auteur { NomAuteur = "" },
                new Categorie { Nom = "Informatique" }),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png"),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png"),
            new LivreCardVM("img/flat.png"),
            new LivreCardVM("https://sqlinfocg.cegepgranby.qc.ca/2147186/img/flat.png")
        };
        List<PromotionCardVM> promotionCards = new()
        {
            new PromotionCardVM("Tout pour la lecture 2 pour 1 sur tous les livres québécois", 100, DateTime.MinValue,
                DateTime.MaxValue, "/img/images_Promo/promo1.png"),
            new PromotionCardVM("Tout pour la lecture", 30, DateTime.MinValue,
                DateTime.MaxValue, "/img/images_Promo/promo2.png"),
            new PromotionCardVM("Promotion éclair d’une journée\r\nDimanche 1er octobre 2023\r\n", 25,
                DateTime.MinValue,
                DateTime.MaxValue, "/img/images_Promo/promo3.png"),
            new PromotionCardVM("Promotion éclair d’une journée\r\nVendredi 27 octobre 2023\r\n", 30, DateTime.MinValue,
                DateTime.MaxValue, "/img/images_Promo/promo3.png"),
            new PromotionCardVM("Promotion éclair sur 2 jours\r\nLes 15 et 16 janvier 2024\r\n", 20, DateTime.MinValue,
                DateTime.MaxValue, "/img/images_Promo/promo3.png")
        };
        return View(new IndexAccueilVM(services, evenements, vedettes, recommandations, categories, livreCategories,
            promotionCards));
    }

    public IActionResult Message(string titre, string message)
    {
        return View(new MessageVM(titre, message));
    }

    public IActionResult Info()
    {
        return View();
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