using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Panier
{
    public class AfficherPanierVM
    {
        public Livre Livre { get; set; }

        public TypeLivre TypeLivre { get; set; } = default!;

        public string? UserId { get; set; }

        public int? Quantite { get; set; } = default!;
    }
}
