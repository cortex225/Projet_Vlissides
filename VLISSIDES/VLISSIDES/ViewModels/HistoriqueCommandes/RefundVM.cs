using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.HistoriqueCommandes
{
    public class RefundVM
    {
        public Commande Commande { get; set; }
        public Livre Livre { get; set; }
        public double Prix { get; set; }
        public int Quantite { get; set; }
        public string PaymentIntent { get; set; }
    }
}
