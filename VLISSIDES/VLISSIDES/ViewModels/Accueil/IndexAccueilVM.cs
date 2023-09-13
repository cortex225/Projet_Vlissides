using System.ComponentModel;

namespace VLISSIDES.ViewModels.Accueil;

public class IndexAccueilVM
{
    public IndexAccueilVM(List<_ServiceCardVM> services = default!, List<_EventCardVM> evenement = default!,
        List<_LivreCardVM> vedettes = default!, List<_LivreCardVM> recommendations = default!,
        List<string> categories = default!, List<_LivreCardVM> livreCatégories = default!)
    {
        Services = services;
        Evenements = evenement;
        Vedettes = vedettes;
        Recommendations = recommendations;
        Categories = categories;
        LivreCategories = livreCatégories;
    }

    [DisplayName("Services offerts")] public List<_ServiceCardVM> Services { get; set; }

    [DisplayName("Évenements")] public List<_EventCardVM> Evenements { get; set; }

    [DisplayName("Livres en vedette")] public List<_LivreCardVM> Vedettes { get; set; }

    [DisplayName("Recommendation pour vous")]
    public List<_LivreCardVM> Recommendations { get; set; }

    [DisplayName("Catégories")] public List<string> Categories { get; set; }

    [DisplayName("Livres catégories")] public List<_LivreCardVM> LivreCategories { get; set; }
}