using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Compte;

public class RegisterVM
{
    [Display(Name = "Nom d'utilisateur (?)")] public string? UserName { get; set; }

    [Required(ErrorMessage = "Le prenom est requis.")]
    [Display(Name = "Prenom (*)")] public string FirstName { get; set; }

    [Required(ErrorMessage = "Le Nom est requis.")]
    [Display(Name = "Nom (*)")] public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email (*)")] public string Email { get; set; }

    [Required(ErrorMessage = "Le téléphone est requis.")]
    [Phone]
    [Display(Name = "Téléphone (*)")] public string Phone { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "Le {0} doit contenir au moins {2} et au maximum {1} caractères.",
        MinimumLength = 6)]
    [Display(Name = "Mot de passe (*)")] public string Password { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Veuillez confirmer votre mot de passe")]
    [Compare("Password", ErrorMessage = "Le mot de passe et la confirmation ne correspondent pas.")]
    [Display(Name = "Confirmation mot de passe (*)")] public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Veuillez accepter les conditions d'utilisation")]
    [Display(Name = "Conditions d'utilisation (*)")] public bool Conditions { get; set; }

    [Display(Name = "Chemin de retour")] public string? ReturnUrl { get; set; }

    public RegisterVM(string? returnUrl="", string? userName="", string firstName="", string lastName="",
        string email="", string phone="", string password="", string confirmPassword="",
        bool conditions=false)
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Password = password;
        ConfirmPassword = confirmPassword;
        Conditions = conditions;
        ReturnUrl = returnUrl;
    }
}