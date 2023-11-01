using System.ComponentModel;

namespace VLISSIDES.Models;

public class StatutCommande
{
    public string Id { get; set; } = default!;

    [DisplayName("Nom")] public string Nom { get; set; } = default!;

    //[DisplayName("Commandes")] public ICollection<Commande> Commandes { get; set; } = default!;
}