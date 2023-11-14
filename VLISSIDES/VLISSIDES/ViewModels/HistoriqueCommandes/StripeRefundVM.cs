using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.HistoriqueCommandes
{
    public class StripeRefundVM
    {
        public Commande Commande { get; set; }
        public Livre Livre { get; set; }
        public double Prix { get; set; }
        public int Quantite { get; set; }
    }
}
