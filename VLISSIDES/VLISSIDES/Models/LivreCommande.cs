namespace VLISSIDES.Models;

public class LivreCommande
{
    public string LivreId { get; set; } = default!;

    public Livre Livre { get; set; } = default!;

    public string CommandeId { get; set; } = default!;

    public Commande Commande { get; set; } = default!;

    public int Quantite { get; set; } = default!;
    
    //Cela garantit que le total de la commande reste précis, même si les prix des livres changent dans le futur
    public decimal PrixParArticle { get; set; }
}