using Microsoft.AspNetCore.Identity;

namespace VLISSIDES.Models;

public class ApplicationUser : IdentityUser
{
    public string Nom { get; set; }

    public string Prenom { get; set; }

    public string? AdresseId { get; set; }

    public Adresse? Adresse { get; set; }
}