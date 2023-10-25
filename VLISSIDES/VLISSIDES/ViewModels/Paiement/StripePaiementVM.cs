using VLISSIDES.ViewModels.Panier;
using VLISSIDES.ViewModels.Profile;

namespace VLISSIDES.ViewModels.Paiement;

public class StripePaiementVM
{
    public string MembreId { get; set; }

    public string StripeCustomerId { get; set; }

    public List<AfficherPanierVM>? Livres { get; set; }

    public double PrixTotal { get; set; }

    public string Email { get; set; }

    public string Nom { get; set; }

    public ProfileModifierAdressesVM Adresse { get; set; }
}