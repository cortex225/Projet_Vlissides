using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VLISSIDES.ViewModels.Compte;

public class RegisterVM
{
    [Display(Name = "Nom d'utilisateur")] public string? UserName { get; set; }

    [Required(ErrorMessage = "Le prenom est requis.")]
    [Display(Name = "Prenom")]
    public string FirstName { get; set; } = default!;

    [Required(ErrorMessage = "Le Nom est requis.")]
    [Display(Name = "Nom")]
    public string LastName { get; set; } = default!;

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]

    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Le telephone est requis.")]
    [Phone]
    [Display(Name = "Téléphone")]
    public string Phone { get; set; } = default!;


    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "Le {0} doit contenir au moins {2} et au maximum {1} caractères.",
        MinimumLength = 6)]
    [Display(Name = "Mot de passe")]
    public string Password { get; set; } = default!;

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Veuillez confirmer votre mot de passe")]
    [Display(Name = "Confirmation mot de passe")]
    [Compare("Password", ErrorMessage = "Le mot de passe et la confirmation ne correspondent pas.")]
    public string ConfirmPassword { get; set; } = default!;

    [Display(Name = "Conditions d'utilisation")]
    [Required(ErrorMessage = "Veuillez accepter les conditions d'utilisation")]
    public bool Conditions { get; set; }

    public string? ReturnUrl { get; set; }


}