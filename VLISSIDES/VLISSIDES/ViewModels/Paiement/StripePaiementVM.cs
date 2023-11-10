using VLISSIDES.ViewModels.Panier;
using VLISSIDES.ViewModels.Profile;

namespace VLISSIDES.ViewModels.Paiement;

public class StripePaiementVM
{
    public string UserId { get; set; }

    public string? StripeCustomerId { get; set; }

    public string? Name { get; set; }

    public List<AfficherPanierVM>? Livres { get; set; }

    public double PrixTotal { get; set; }

    public ProfileModifierAdressesVM Adresse { get; set; }
    public PaiementAdresseVM PaiementAdresseVM { get; set; }

    public string DonEcologie { get; set; }

}