using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Profile
{
    public class ProfileModifierInformationVM
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [Display(Name = "Prénom")] public string Prenom { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "La date de naissance est obligatoire")]
        [Display(Name = "Date de naissance")] public DateTime? DateNaissance { get; set; }
        [Required(ErrorMessage = "Le nom d'utilisateur est obligatoire")]
        [Display(Name = "Nom d'utilisateur")] public string NomUtilisateur { get; set; }
        [Required(ErrorMessage = "Le courriel est obligatoire")]
        public string Courriel { get; set; }

        [Required(ErrorMessage = "Le téléphone est obligatoire")]
        [Display(Name = "Téléphone")] public string Telephone { get; set; }

        public string? CoverImageUrl { get; set; }

        [Display(Name = "Image du livre")] public IFormFile? CoverPhoto { get; set; }
    }
}
