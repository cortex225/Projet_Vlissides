namespace VLISSIDES.Models;

public class Favori
{
    public string MembreId { get; set; }
    public Membre Membre { get; set; }

    public string LivreId { get; set; }
    public Livre Livre { get; set; }
}