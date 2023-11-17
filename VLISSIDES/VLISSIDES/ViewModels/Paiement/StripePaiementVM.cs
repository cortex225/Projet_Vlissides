using System.ComponentModel;
using VLISSIDES.ViewModels.Panier;

namespace VLISSIDES.ViewModels.Paiement;

public class StripePaiementVM
{
    [DisplayName("Identifiant Utilisateur")]
    public string? UserId { get; set; }

    [DisplayName("Identifiant Client Stripe")]
    public string? StripeCustomerId { get; set; }

    [DisplayName("Nom")] public string? Name { get; set; }

    [DisplayName("Livres")] public List<AfficherPanierVM>? Livres { get; set; }

    [DisplayName("Prix Total")] public double? PrixTotal { get; set; }

    [DisplayName("Identifiant Adresse")] public string? AdresseId { get; set; }

    [DisplayName("Adresse Paiement")] public PaiementAdresseVM? PaiementAdresseVM { get; set; }
}