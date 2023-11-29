using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.GestionComptes;

public class GestionComptesModifierVM
{
    public string Id { get; set; }

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

    [DisplayName("Mot de passe")] public string? Password { get; set; } = default!;

    [DisplayName("Confirmer le mot de passe")]
    public string? PasswordConfirmed { get; set; } = default!;
}