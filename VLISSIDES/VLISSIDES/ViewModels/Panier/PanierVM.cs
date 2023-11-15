using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Panier
{
    public class PanierVM
    {
        public List<AfficherPanierVM> ListeArticles { get; set; }
        public double PrixTotal { get; set; }

        public Promotions? Promotion { get; set; }

        public bool? isPromotion { get; set; } = false;




    }
}
