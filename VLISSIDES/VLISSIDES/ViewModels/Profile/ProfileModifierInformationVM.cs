using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Profile
{
    public class ProfileModifierInformationVM
    {
        public string Id { get; set; }
        [Display(Name = "Prénom")] public string Prenom { get; set; }
        public string Nom { get; set; }

        [Display(Name = "Date de naissance")] public DateTime? DateNaissance { get; set; }
        [Display(Name = "Nom d'utilisateur")] public string NomUtilisateur { get; set; }
        public string Courriel { get; set; }


        [Display(Name = "Téléphone")] public string Telephone { get; set; }

        public string? CoverImageUrl { get; set; }

        [Display(Name = "Image du livre")] public IFormFile? CoverPhoto { get; set; }
    }
}
