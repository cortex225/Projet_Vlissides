using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.GestionComptes;

public class GestionComptesAjouterEmployeVM
{
    [Required(ErrorMessage = "Le Nom est obligatoire")]
    [DisplayName("Nom")]
    public string Nom { get; set; } = default!;

    [Required(ErrorMessage = "Le Prenom est obligatoire")]
    [DisplayName("Prénom")]
    public string Prenom { get; set; } = default!;

    [Required(ErrorMessage = "Le Nom d'utilisateur est obligatoire")]
    [DisplayName("Nom d'utilisateur")]
    public string Username { get; set; } = default!;

    [Required(ErrorMessage = "Le Téléphone est obligatoire")]
    [DisplayName("Téléphone")]
    public string Telephone { get; set; } = default!;

    [Required(ErrorMessage = "L'Adresse Courriel est obligatoire")]
    [DisplayName("Adresse Courriel")]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Le Mot de passe est obligatoire")]
    [DisplayName("Mot de passe")]
    public string Password { get; set; } = default!;

    [Required(ErrorMessage = "Veuillez confirmez votre mot de passe")]
    [DisplayName("Confirmer le mot de passe")]
    public string PasswordConfirmed { get; set; } = default!;
}