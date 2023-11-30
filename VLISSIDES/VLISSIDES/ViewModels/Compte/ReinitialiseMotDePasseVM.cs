using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Compte;

public class ReinitialiseMotDePasseVM
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")] public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
        MinimumLength = 6)]
    [Display(Name = "Mot de passe")] public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
    [Display(Name = "Confirmation mot de passe")] public string ConfirmPassword { get; set; }

    public ReinitialiseMotDePasseVM(string email, string password, string confirmPassword)
    {
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
    }
}