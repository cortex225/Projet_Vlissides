using System.ComponentModel;

namespace VLISSIDES.ViewModels.Accueil;

public class IndexAccueilVM
{
    public IndexAccueilVM(List<ServiceCardVM> services = default!, List<EventCardVM> evenement = default!,
        List<LivreCardVM> vedettes = default!, List<LivreCardVM> recommendations = default!,
        List<string> categories = default!, List<LivreCardVM> livreCatégories = default!,
        List<PromotionCardVM> promotions = default!)
    {
        Services = services;
        Evenements = evenement;
        Vedettes = vedettes;
        Recommendations = recommendations;
        Categories = categories;
        LivreCategories = livreCatégories;
        Promotions = promotions;
    }

    [DisplayName("Services offerts")] public List<ServiceCardVM> Services { get; set; }

    [DisplayName("Évenements")] public List<EventCardVM> Evenements { get; set; }

    [DisplayName("Livres en vedette")] public List<LivreCardVM> Vedettes { get; set; }

    [DisplayName("Recommendation pour vous")]
    public List<LivreCardVM> Recommendations { get; set; }

    [DisplayName("Catégories")] public List<string> Categories { get; set; }

    [DisplayName("Livres catégories")] public List<LivreCardVM> LivreCategories { get; set; }
    [DisplayName("Promotions")] public List<PromotionCardVM> Promotions { get; set; }
}