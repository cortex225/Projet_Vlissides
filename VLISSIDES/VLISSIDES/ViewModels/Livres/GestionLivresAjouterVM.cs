using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Livres
{
    public class GestionLivresAjouterVM
    {

        public string Titre { get; set; }

        public string Resume { get; set; }
        public string? Couverture { get; set; }

        public int NbExemplaires { get; set; }

        public int NbPages { get; set; }

        public double Prix { get; set; }
        public DateTime? DatePublication { get; set; }

        public string ISBN { get; set; }

        //Categories
        public string CategorieId { get; set; }
        public List<SelectListItem>? SelectListCategories { get; set; }

        //Auteurs
        public string AuteurId { get; set; }
        public List<SelectListItem>? SelectListAuteurs { get; set; }
        public ICollection<Auteur>? Auteurs { get; set; }//Plusieur auteurs écrit un livre 
        //Maison Edition
        public string MaisonEditionId { get; set; }
        public List<SelectListItem>? SelectMaisonEditions { get; set; }
        //Type
        public string? TypeLivreId { get; set; }
        public List<TypeLivre>? CheckboxTypes { get; set; }
        public ICollection<TypeLivre>? Types { get; set; }

        //public string EvaluationId { get; set; }

        //Langue
        public List<Langue>? ListeLangue { get; set; }
        public string? LangueId { get; set; }

        //Image
        public string? CoverImageUrl { get; set; }
        [NotMapped]
        [Display(Name = "Image du livre")]
        public IFormFile? CoverPhoto { get; set; }

    }
}
