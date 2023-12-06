using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil;

public class IndexAccueilVM
{
    [DisplayName("Services offerts")] public List<CarteServiceVM> Services { get; set; }
    [DisplayName("Évenements")] public List<CarteEvenementVM> Evenements { get; set; }
    [DisplayName("Promotion")] public List<CartePromotionVM> Promotions { get; set; }
    [DisplayName("Livres en vedette")] public List<CarteLivreVM> Vedettes { get; set; }
    [DisplayName("Utilisateur")] public DateTime? Naissance { get; set; }
    public IndexAccueilVM(IEnumerable<CarteServiceVM> services, IEnumerable<Evenement> evenements,
        IEnumerable<Promotion> promotions, IEnumerable<Livre> vedettes, ApplicationUser utilisateur)
    {
        services ??= new List<CarteServiceVM>();
        evenements ??= new List<Evenement>();
        promotions ??= new List<Promotion>();
        vedettes ??= new List<Livre>();
        Services = services.ToList();
        Evenements = evenements.Select(e => new CarteEvenementVM(e)).ToList();
        Promotions = promotions.Select(p => new CartePromotionVM(p)).ToList();
        Vedettes = vedettes.Select(v => new CarteLivreVM(v)).ToList();
        Naissance = (utilisateur ?? new()).DateNaissance;
    }
}