using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Recherche
{
    public class DetailsLivreVM
    {
        public string Id { get; set; }
        public string Titre { get; set; }
        public ICollection<Auteur> lesAuteurs { get; set; }
        public ICollection<Categorie> lesCategories { get; set; }
        public double Prix { get; set; }
        public DateTime DatePublication { get; set; }
        public string Couverture { get; set; }
        public MaisonEdition? maisonEdition { get; set; }
        public int NbPages { get; set; }
        public string Resume { get; set; }
        public int NbExemplaires { get; set; }
    }
}
