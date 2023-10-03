using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace VLISSIDES.Models;

public class ApplicationUser : IdentityUser
{
    [DisplayName("Nom")] public string Nom { get; set; } = default!;

    [DisplayName("Prénom")] public string Prenom { get; set; } = default!;

    // Un utilisateur peut avoir une adresse principale
    [DisplayName("Identifiant de l'adresse principale")]
    public string? AdressePrincipaleId { get; set; }

    [DisplayName("Adresse principale")] public Adresse? AdressePrincipale { get; set; }

    // Un utilisateur peut avoir plusieurs adresses de livraison
    [DisplayName("Identifiant de l'adresse de livraison")]
    public string? AdresseLivraisonId { get; set; }

    [DisplayName("Adresse de livraison")] public ICollection<Adresse>? AdressesLivraison { get; set; }

    [DisplayName("Identifiant du panier")]
    public string? PanierId { get; set; }

    [DisplayName("Panier")]
    public Panier? Panier { get; set; }
}