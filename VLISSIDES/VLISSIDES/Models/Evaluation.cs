namespace VLISSIDES.Models;

public class Evaluation
{
    public string Id { get; set; }

    public string? Commentaire { get; set; }

    public int Note { get; set; }

    public DateTime DateEvaluation { get; set; }

    public string MembreId { get; set; }

    public Membre Membre { get; set; }

    public string LivreId { get; set; }

    public Livre Livre { get; set; }
}