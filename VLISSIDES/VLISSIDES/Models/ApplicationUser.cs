using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    [DisplayName("Adresse de livraison")] public ICollection<Adresse>? AdressesLivraison { get; set; }
    [DisplayName("Date de naissance")] public DateTime? DateNaissance { get; set; }

    [Display(Name = "Photo")] [NotMapped] public IFormFile CoverPhoto { get; set; } = default!;
    public string? CoverImageUrl { get; set; }

    [DisplayName("Panier")]
    public ICollection<LivrePanier>? Panier { get; set; }

}