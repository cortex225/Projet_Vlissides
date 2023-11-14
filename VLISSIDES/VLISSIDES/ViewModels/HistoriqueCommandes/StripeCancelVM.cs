using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.HistoriqueCommandes
{
    public class StripeCancelVM
    {
        public string Id { get; set; }
        public List<LivreCommande> Livres { get; set; }
    }
}
