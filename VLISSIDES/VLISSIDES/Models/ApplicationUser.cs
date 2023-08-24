using Microsoft.AspNetCore.Identity;

namespace VLISSIDES.Models;

public class ApplicationUser: IdentityUser
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Adresse { get; set; }
    public string Ville { get; set; }
    public string CodePostal { get; set; }
    public string Courriel { get; set; }
    public string MotDePasse { get; set; }
    public string Telephone { get; set; }
    public string Role { get; set; }
}