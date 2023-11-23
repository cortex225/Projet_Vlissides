using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil;

public class IndexAccueilVM
{
    [DisplayName("Services offerts")] public List<ServiceCardVM> Services { get; set; }
    [DisplayName("Évenements")] public List<EventCardVM> Evenements { get; set; }
    [DisplayName("Promotions")] public List<PromotionCardVM> Promotions { get; set; }
    [DisplayName("Livres en vedette")] public List<LivreCardVM> Vedettes { get; set; }
    public IndexAccueilVM(IEnumerable<ServiceCardVM> services, IEnumerable<Evenement> evenements, IEnumerable<Promotions> promotions, IEnumerable<Livre> vedettes)
    {
        services ??= new List<ServiceCardVM>();
        evenements ??= new List<Evenement>();
        promotions ??= new List<Promotions>();
        vedettes ??= new List<Livre>();
        Services = services.ToList();
        Evenements = evenements.Select(e => new EventCardVM(e)).ToList();
        Promotions = promotions.Select(p => new PromotionCardVM(p)).ToList();
        Vedettes = vedettes.Select(v => new LivreCardVM(v)).ToList();
    }
}