namespace VLISSIDES.Models;

public class Adresse
{
    public string Id { get; set; }

    public string NoCivique { get; set; }

    public string Rue { get; set; }

    public string Ville { get; set; }

    public string Province { get; set; }

    public string CodePostal { get; set; }

    public string Pays { get; set; }
    
    public string? MembreId { get; set; }
    
    public Membre? Membre { get; set; }

    // Pour les adresses de livraison
    public string? MembreLivraisonId { get; set; }
    public  Membre MembreLivraison { get; set; }
}