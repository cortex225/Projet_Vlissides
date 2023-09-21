using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionLivres
{
    public class GestionLivresInventaireVM
    {
        public List<GestionLivresAfficherVM> ListeLivres { get; set; }
        public List<Categorie> ListeCategories { get; set; }
        public List<Langue> ListeLangue { get; set; }
        public List<TypeLivre> ListeTypeLivres { get; set; }
    }
}
