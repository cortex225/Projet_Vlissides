using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Panier
{
    public class AfficherPanierVM
    {
        public string Id { get; set; }

        public Livre Livre { get; set; }

        public TypeLivre TypeLivre { get; set; } = default!;

        public double Prix { get; set; }

        public string? UserId { get; set; }

        public int? Quantite { get; set; } = default!;
    }
}
