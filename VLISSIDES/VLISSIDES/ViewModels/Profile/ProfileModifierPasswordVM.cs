using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Profile;

public class ProfileModifierPasswordVM
{
    [Display(Name = "Identifiant")] public string Id { get; set; }

    [Required(ErrorMessage = "Veuillez entrez votre ancien mot de passe")]
    [Display(Name = "Ancien mot de passe")] public string MotDePasse { get; set; }

    [Required(ErrorMessage = "Veuillez entrez votre nouveau mot de passe")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Le nouveau mot de passe doit être entre 6 à 100 caractères")]
    [Display(Name = "Nouveau mot de passe")] public string NouveauMotDePasse { get; set; }

    [Required(ErrorMessage = "Veuillez confirmez votre nouveau mot de passe")]
    [Display(Name = "Confirmez votre nouveau mot de passe")] public string MotDePasseConfirme { get; set; }

    public ProfileModifierPasswordVM()
    {
        Id = "";
        MotDePasse = "";
        NouveauMotDePasse = "";
        MotDePasseConfirme = "";
    }
    public ProfileModifierPasswordVM(string id)
    {
        Id = id;
        MotDePasse = "";
        NouveauMotDePasse = "";
        MotDePasseConfirme = "";
    }
}