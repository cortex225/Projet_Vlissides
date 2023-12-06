using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.HistoriqueCommandes;

public class AnnulerlVM
{
    public Commande Commande { get; set; }
    public List<LivreCommande> Livres { get; set; }
    public string PaymentIntent { get; set; }
}