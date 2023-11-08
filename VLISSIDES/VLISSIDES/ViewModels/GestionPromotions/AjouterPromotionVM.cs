using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionPromotions
{
    public class AjouterPromotionVM
    {
        [Display(Name = "Nom de la promotion")] public string Nom { get; set; }
        [Display(Name = "Description")] public string Description { get; set; }

        [Display(Name = "Début de la promotion")] public DateTime DateDebut { get; set; }
        [Display(Name = "Fin de la promotion")] public DateTime DateFin { get; set; }

        //Image
        public string? CoverImageUrl { get; set; }

        [Display(Name = "Image de la promotion")] public IFormFile? CoverPhoto { get; set; }

        [Display(Name = "Auteur")] public string? AuteurId { get; set; }
        public Auteur? Auteur { get; set; }

        [Display(Name = "Catégorie")] public string? CategorieId { get; set; }
        public Categorie? Categorie { get; set; }

        [Display(Name = "Maison d'édition")] public string? MaisonEditionId { get; set; }
        public MaisonEdition? MaisonEdition { get; set; }

        [Display(Name = "Type de promotion")] public string TypePromotion { get; set; }

        [Display(Name = "Livres à acheter")] public int? LivresAcheter { get; set; }
        [Display(Name = "Livres gratuits")] public int? LivresGratuits { get; set; }

        [Display(Name = "Pourcentage du rabais")] public int? PourcentageRabais { get; set; }

        //Select lists
        public ICollection<Auteur>? Auteurs { get; set; }

        public List<SelectListItem>? SelectListAuteurs { get; set; }

        public ICollection<MaisonEdition>? MaisonEditions { get; set; }

        public List<SelectListItem>? SelectListMaisonEditions { get; set; }

        public ICollection<Categorie>? Categories { get; set; }

        public List<SelectListItem>? SelectListCategories { get; set; }
    }
}
