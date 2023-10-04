namespace VLISSIDES.Models
{
    public class LivrePanier
    {
        public string Id { get; set; } = default!;

        public string LivreId { get; set; } = default!;

        public Livre Livre { get; set; } = default!;

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public int Quantite { get; set; } = default!;
    }
}
