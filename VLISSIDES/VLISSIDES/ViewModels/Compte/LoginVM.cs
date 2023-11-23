using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Compte;

public class LoginVM
{
    [Display(Name = "Nom d'utilisateur")] public string? UserName { get; set; }

    [Required(ErrorMessage = "Veuillez entrer votre nom d'utilisateur ou votre adresse e-mail.")]
    [Display(Name = "Nom d'utilisateur/E-mail (*)")] public string EmailOrUserName { get; set; }


    [Required(ErrorMessage = "Veuillez entrer votre mot de passe (*)z")]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "Le {0} doit contenir au moins {2} et au maximum {1} caractères.",
        MinimumLength = 6)]
    [Display(Name = "Mot de passe (*)")] public string Password { get; set; }


    [Display(Name = "Mémoriser le mot de passe ?")] public bool RememberMe { get; set; }

    [Display(Name = "Chemin de retour")] public string? ReturnUrl { get; set; }

    public LoginVM(string? returnUrl = "", string? userName = null, string emailOrUserName="",
        string password="", bool rememberMe=false)
    {
        UserName = userName;
        EmailOrUserName = emailOrUserName;
        Password = password;
        RememberMe = rememberMe;
        ReturnUrl = returnUrl;
    }
}