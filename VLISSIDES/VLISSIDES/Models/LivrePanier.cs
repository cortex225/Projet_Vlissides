namespace VLISSIDES.Models
{
    public class LivrePanier
    {
        public string LivreId { get; set; } = default!;

        public Livre Livre { get; set; } = default!;

        public string PanierId { get; set; } = default!;

        public Panier Panier { get; set; } = default!;

        public int Quantite { get; set; } = default!;
    }
}
