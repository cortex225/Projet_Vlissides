using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil;

public class IndexAccueilVM
{
    [DisplayName("Services offerts")] public List<ServiceCardVM> Services { get; set; }
    [DisplayName("Évenements")] public List<EventCardVM> Evenements { get; set; }
    [DisplayName("Promotion")] public List<PromotionCardVM> Promotions { get; set; }
    [DisplayName("Livres en vedette")] public List<LivreCardVM> Vedettes { get; set; }
    public ApplicationUser? User { get; set; }

    public IndexAccueilVM(IEnumerable<ServiceCardVM> services = default, IEnumerable<Evenement> evenement = default, IEnumerable<Promotion> promotions = default,
        IEnumerable<Livre> vedettes = default, ApplicationUser? user = default!)
    {
        Services = services.ToList();
        Evenements = evenement.Select(e => new EventCardVM(e)).ToList();
        Promotions = promotions.Select(p => new PromotionCardVM(p)).ToList();
        Vedettes = vedettes.Select(v => new LivreCardVM(v.Couverture, v)).ToList();
        User = user;

    }
}