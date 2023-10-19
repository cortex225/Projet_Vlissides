using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Profile
{
    public class ProfileModifierPasswordVM
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Veuillez entrez votre ancien mot de passe")]
        [Display(Name = "Ancien mot de passe")] public string Password { get; set; }
        [Required(ErrorMessage = "Veuillez entrez votre nouveau mot de passe")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le nouveau mot de passe doit être entre 6 à 100 caractères")]
        [Display(Name = "Nouveau mot de passe")] public string NewPassword { get; set; }
        [Required(ErrorMessage = "Veuillez confirmez votre nouveau mot de passe")]
        [Display(Name = "Confirmez votre nouveau mot de passe")] public string ConfirmPassword { get; set; }
    }
}
