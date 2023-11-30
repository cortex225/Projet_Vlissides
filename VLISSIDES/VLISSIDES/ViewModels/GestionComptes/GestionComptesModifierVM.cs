using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionComptes;

public class GestionComptesModifierVM
{
    [DisplayName("Identifiant")] public string Id { get; set; }

    [Required(ErrorMessage = "Le Nom est obligatoire")]
    [DisplayName("Nom")] public string Nom { get; set; }

    [Required(ErrorMessage = "Le Prenom est obligatoire")]
    [DisplayName("Prénom")] public string Prenom { get; set; }

    [Required(ErrorMessage = "Le Nom d'utilisateur est obligatoire")]
    [DisplayName("Nom d'utilisateur")] public string Username { get; set; }


    [DisplayName("Téléphone")] public string? Telephone { get; set; }

    [Required(ErrorMessage = "L'Adresse Courriel est obligatoire")]
    [DisplayName("Adresse Courriel")] public string Email { get; set; }

    [DisplayName("Mot de passe")] public string? Password { get; set; }

    [DisplayName("Confirmer le mot de passe")] public string? PasswordConfirmed { get; set; }

    public GestionComptesModifierVM()
    {
        Id = "";
        Nom = "";
        Prenom = "";
        Username = "";
        Telephone = "";
        Email = "";
        Password = "";
        PasswordConfirmed = "";
    }
    public GestionComptesModifierVM(ApplicationUser user)
    {
        Id = user.Id;
        Nom = user.Nom;
        Prenom = user.Prenom;
        Username = user.UserName;
        Telephone = user.PhoneNumber;
        Email = user.Email;
        Password = "";
        PasswordConfirmed = "";
    }
}