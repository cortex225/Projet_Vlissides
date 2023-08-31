using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace VLISSIDES.Models;

public class ApplicationUser : IdentityUser
{
    public string Nom { get; set; }

    public string Prenom { get; set; }

    // Un utilisateur peut avoir une adresse principale
    public string? AdressePrincipaleId { get; set; }
    public Adresse? AdressePrincipale { get; set; }

    // Un utilisateur peut avoir plusieurs adresses de livraison
    public ICollection<Adresse>? AdressesLivraison { get; set; }
}