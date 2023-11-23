using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil;

public class IndexAccueilVM
{
    [DisplayName("Services offerts")] public List<ServiceCardVM> Services { get; set; }
    [DisplayName("Évenements")] public List<EventCardVM> Evenements { get; set; }
    [DisplayName("Promotion")] public List<PromotionCardVM> Promotions { get; set; }
    [DisplayName("Livres en vedette")] public List<LivreCardVM> Vedettes { get; set; }
    [DisplayName("Utilisateur")] public ApplicationUser User { get; set; }
    public IndexAccueilVM(IEnumerable<ServiceCardVM> services, IEnumerable<Evenement> evenements,
        IEnumerable<Promotion> promotions, IEnumerable<Livre> vedettes, ApplicationUser user)
    {
        services ??= new List<ServiceCardVM>();
        evenements ??= new List<Evenement>();
        promotions ??= new List<Promotion>();
        vedettes ??= new List<Livre>();
        Services = services.ToList();
        Evenements = evenements.Select(e => new EventCardVM(e)).ToList();
        Promotions = promotions.Select(p => new PromotionCardVM(p)).ToList();
        Vedettes = vedettes.Select(v => new LivreCardVM(v)).ToList();
        this.User = user;
    }
}