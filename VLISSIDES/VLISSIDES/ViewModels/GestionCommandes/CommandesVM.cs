using System.ComponentModel;

namespace VLISSIDES.ViewModels.GestionCommandes;

public class CommandesVM
{
    public string Id { get; set; } = default!;

    [DisplayName("Date de commande")] public DateTime DateCommande { get; set; } = default!;

    [DisplayName("Prix total")] public decimal PrixTotal { get; set; } = default!;

    [DisplayName("Nom d'utilisateur du membre")]
    public string MembreUserName { get; set; } = default!;

    [DisplayName("Identifiant de l'adresse")]
    public string? AdresseId { get; set; } = default!;

    [DisplayName("Table association Livre et Commande")]
    public List<LivreCommandeVM> LivreCommandes { get; set; } = default!;

    [DisplayName("Id du statut de la commande")]
    public string StatutId { get; set; } = default!;

    [DisplayName("Statut de la commande")] public string StatutNom { get; set; } = default!;

    [DisplayName("Demande d'annulation")] public bool EnDemandeAnnulation { get; set; } = default!;
}