using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Panier
{
    public class PanierVM
    {
        public List<AfficherPanierVM> ListeArticles { get; set; }
        public double PrixTotal { get; set; }

        public Promotions? Promotion { get; set; }

        public decimal? PrixAvecPromotion { get; set; } = default!;

        public bool isPromotion { get; set; } = false;

    }
}
