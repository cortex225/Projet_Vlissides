namespace VLISSIDES.Models;

public class LivreCommande
{
    public string LivreId { get; set; } = default!;

    public Livre Livre { get; set; } = default!;

    public string CommandeId { get; set; } = default!;

    public Commande Commande { get; set; } = default!;

    public int Quantite { get; set; } = default!;
}