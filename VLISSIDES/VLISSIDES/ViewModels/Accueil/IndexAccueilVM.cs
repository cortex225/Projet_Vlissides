﻿namespace VLISSIDES.ViewModels.Accueil;

public class IndexAccueilVM
{
    [DisplayName("Services offerts")] public List<ServiceCardVM> Services { get; set; }
    [DisplayName("Évenements")] public List<EventCardVM> Evenements { get; set; }
    [DisplayName("Promotions")] public List<PromotionCardVM> Promotions { get; set; }
    [DisplayName("Livres en vedette")] public List<LivreCardVM> Vedettes { get; set; }

    [DisplayName("Recommendation pour vous")]
    public List<LivreCardVM> Recommendations { get; set; }

    [DisplayName("Catégories")] public List<string> Categories { get; set; }

    [DisplayName("Livres catégories")] public List<LivreCardVM> LivreCategories { get; set; }
    [DisplayName("Promotions")] public List<PromotionCardVM> Promotions { get; set; }

    public ApplicationUser? user { get; set; }
    public IndexAccueilVM(IEnumerable<ServiceCardVM> services = default, IEnumerable<Evenement> evenement = default, IEnumerable<Promotions> promotions = default,
        IEnumerable<Livre> vedettes = default)
    {
        Services = services.ToList();
        Evenements = evenement.Select(e => new EventCardVM(e)).ToList();
        Promotions = promotions.Select(p => new PromotionCardVM(p)).ToList();
        Vedettes = vedettes.Select(v => new LivreCardVM(v.Couverture, v)).ToList();
    }
}