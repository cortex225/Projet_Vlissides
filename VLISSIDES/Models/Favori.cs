namespace VLISSIDES.Models;

public class Favori
{
    public string MembreId { get; set; } = default!;
    public Membre Membre { get; set; } = default!;

    public string LivreId { get; set; } = default!;
    public Livre Livre { get; set; } = default!;
}