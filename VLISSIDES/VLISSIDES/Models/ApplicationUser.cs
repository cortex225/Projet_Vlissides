using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace VLISSIDES.Models;

public class ApplicationUser : IdentityUser
{
    [DisplayName("Nom")] public string Nom { get; set; } = default!;

    [DisplayName("Pr�nom")] public string Prenom { get; set; } = default!;

    // Un utilisateur peut avoir une adresse principale
    [DisplayName("Identifiant de l'adresse principale")]
    public string? AdressePrincipaleId { get; set; }

    [DisplayName("Adresse principale")] public Adresse? AdressePrincipale { get; set; }

    // Un utilisateur peut avoir plusieurs adresses de livraison
    [DisplayName("Adresse de livraison")] public ICollection<Adresse>? AdressesLivraison { get; set; }
    [DisplayName("Date de naissance")] public DateTime? DateNaissance { get; set; }
}