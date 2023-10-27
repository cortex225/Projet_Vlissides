using System.ComponentModel;

namespace VLISSIDES.Models;

public class Commande
{
    public string Id { get; set; } = default!;

    [DisplayName("Date de commande")] public DateTime DateCommande { get; set; } = default!;

    [DisplayName("Prix total")] public decimal PrixTotal { get; set; } = default!;

    [DisplayName("Identifiant du membre")] public string MembreId { get; set; } = default!;

    [DisplayName("Membre ayant commandé")] public Membre Membre { get; set; } = default!;

    [DisplayName("Livres commandés")] public ICollection<Livre> Livres { get; set; } = default!;

    [DisplayName("Identifiant de l'adresse")]
    public string AdresseId { get; set; } = default!;

    [DisplayName("Adresse de livraison")]
    public Adresse AdresseLivraison { get; set; } = default!; //Chaque commande a une adresse de livraison

    [DisplayName("Table association Livre et Commande")]
    public ICollection<LivreCommande> LivreCommandes { get; set; } = default!;

    public string StatutCommandeId { get; set; } = default!;
    public StatutCommande StatutCommande { get; set; } = default!;
}