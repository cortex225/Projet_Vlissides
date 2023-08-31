using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Compte;

public class LoginVM
{

    [Display(Name = "Nom d'utilisateur")] public string? UserName { get; set; }

    [Required(ErrorMessage = "Veuillez entrer votre nom d'utilisateur ou votre adresse e-mail.")]
    [Display(Name = "Nom d'utilisateur/E-mail")]
    public string EmailOrUserName { get; set; } = default!;


    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "Le {0} doit contenir au moins {2} et au maximum {1} caractères.",
        MinimumLength = 6)]
    [Display(Name = "Mot de passe")]
    public string Password { get; set; } = default!;


    [Display(Name = "Mémoriser le mot de passe ?")]

    public bool RememberMe { get; set; }

    public string? ReturnUrl { get; set; }
}