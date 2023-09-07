namespace VLISSIDES.Models;

public class Commande
{
    public string Id { get; set; } = default!;

    public DateTime DateCommande { get; set; } = default!;

    public decimal PrixTotal { get; set; } = default!;

    public string MembreId { get; set; } = default!;

    public Membre Membre { get; set; } = default!;

    public ICollection<Livre> Livres { get; set; } = default!;

    public string AdresseId { get; set; } = default!;

    public Adresse AdresseLivraison { get; set; } = default!; //Chaque commande a une adresse de livraison

    public ICollection<LivreCommande> LivreCommandes { get; set; } = default!;
}