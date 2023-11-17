using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        var evenements = _context.Evenements.Include(e => e.Reservations).ToList();
        var promotions = _context.Promotions.ToList();
        var vedettes = _context.Livres.Include(v => v.Evaluations).Include(v => v.LivreTypeLivres).Include(v => v.LivreAuteurs)
            .ThenInclude(la => la.Auteur).Include(v => v.Categories).ThenInclude(lc => lc.Categorie).ToList();
        vedettes.Sort((l1, l2) => decimal.ToInt32(l1.Note - l2.Note));
        var taille = 12;
        return View(new IndexAccueilVM(services, evenements.Take(taille), promotions.Take(taille), vedettes.Take(taille)));
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