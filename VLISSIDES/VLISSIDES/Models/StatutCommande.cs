namespace VLISSIDES.Models;

public class StatutCommande
{
    public string Id { get; set; } = default!;

    public string Nom { get; set; } = default!;

    public ICollection<Commande> Commandes { get; set; } = default!;
}