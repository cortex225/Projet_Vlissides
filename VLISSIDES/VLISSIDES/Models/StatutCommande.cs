namespace VLISSIDES.Models;

public class StatutCommande
{
    public string Id { get; set; }

    public string Nom { get; set; }

    public ICollection<Commande> Commandes { get; set; }
}