namespace VLISSIDES.Models;

public class LivrePanier
{
    public string Id { get; set; } = default!;

    public string LivreId { get; set; } = default!;

    public Livre Livre { get; set; } = default!;

    public string TypeId { get; set; } = default!;

    public TypeLivre TypeLivre { get; set; } = default!;

    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }

    public int? Quantite { get; set; } = default!;

    public decimal? PrixOriginal { get; set; } = default!;

    public decimal? PrixApresPromotion { get; set; } = default!;
}