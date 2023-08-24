namespace VLISSIDES.Models;

public class LivreCommande
{
    public string IdLivre { get; set; }
    
    public Livre Livre { get; set; }
    
    public string IdCommande { get; set; }
    
    public Commande Commande { get; set; }
    
    public int Quantite { get; set; }
}