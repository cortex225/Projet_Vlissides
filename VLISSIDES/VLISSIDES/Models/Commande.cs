namespace VLISSIDES.Models;

public class Commande
{
    public string Id { get; set; }

    public DateTime DateCommande { get; set; }

    public decimal PrixTotal { get; set; }
    
    public string EmployeId { get; set; }

    public Employe Employe { get; set; }
    
    public string MembreId { get; set; }
    
    public Membre Membre { get; set; }

    public ICollection<Livre> Livres { get; set; }

    public string AdresseId { get; set; }

    public Adresse AdresseLivraison { get; set; }//Chaque commande a une adresse de livraison
    
    public ICollection<LivreCommande> LivreCommandes { get; set; }
}