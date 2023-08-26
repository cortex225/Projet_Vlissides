namespace VLISSIDES.Models;

public class LivreCommande
{
    public string LivreId { get; set; }

    public Livre Livre { get; set; }

    public string CommandeId { get; set; }

    public Commande Commande { get; set; }

    public int Quantite { get; set; }
}