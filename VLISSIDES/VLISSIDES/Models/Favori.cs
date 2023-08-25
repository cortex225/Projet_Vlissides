namespace VLISSIDES.Models;

public class Favori
{
    public string IdMembre { get; set; }
    public Membre Membre { get; set; }
    
    public string IdLivre { get; set; }
    public Livre Livre { get; set; }
}