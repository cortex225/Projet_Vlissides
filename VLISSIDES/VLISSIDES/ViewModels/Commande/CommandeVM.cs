namespace VLISSIDES.ViewModels.Commande;

public class CommandeVM
{
    public string LivreId { get; set; }
    public string Titre { get; set; }
    public string TypeLivre { get; set; }
    public double Prix { get; set; } // Prix basé sur le type de livre
    public int Quantite { get; set; }
    public double Total { get; set; } // Prix * Quantite
}