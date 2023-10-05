using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Profile
{
    public class ProfileModifierPasswordVM
    {
        public string Id { get; set; }
        [Display(Name = "Ancien mot de passe")] public string Password { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Le nouveau mot de passe doit être entre 6 à 100 caractères")]
        [Display(Name = "Nouveau mot de passe")] public string NewPassword { get; set; }
        [Display(Name = "Confirmez votre nouveau mot de passe")] public string ConfirmPassword { get; set; }
    }
}
