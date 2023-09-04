namespace VLISSIDES.Models;

public class Evaluation
{
    public string Id { get; set; } = default!;

    public string? Commentaire { get; set; } = default!;

    public int Note { get; set; } = default!;

    public DateTime DateEvaluation { get; set; } = default!;

    public string MembreId { get; set; } = default!;

    public Membre Membre { get; set; } = default!;

    public string LivreId { get; set; } = default!;

    public Livre Livre { get; set; } = default!;
}