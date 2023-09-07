using Microsoft.AspNetCore.Mvc.Rendering;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionLivres
{
    public class GestionLivresAfficherVM
    {
        public string Image { get; set; }
        public string Titre { get; set; }
        public ICollection<Auteur>? Auteur { get; set; }
        public List<SelectListItem>? ListAuteur { get; set; }
        public ICollection<MaisonEdition>? Editeur { get; set; }
        public List<SelectListItem>? ListEditeur { get; set; }
        public int Quantite { get; set; }
    }
}
