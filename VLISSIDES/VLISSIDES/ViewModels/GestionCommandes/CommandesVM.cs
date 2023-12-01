using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionCommandes;

public class CommandesVM
{
    [Display(Name = "Identifiant")] public string Id { get; set; }

    [DisplayName("Date de commande")] public DateTime DateCommande { get; set; }

    [DisplayName("Prix total")] public decimal PrixTotal { get; set; }

    [DisplayName("Nom d'utilisateur du membre")] public string MembreUserName { get; set; }

    [DisplayName("Identifiant de l'adresse")] public string? AdresseId { get; set; }

    [DisplayName("Table association Livre et Commande")] public List<LivreCommandeVM> LivreCommandes { get; set; }

    [DisplayName("Id du statut de la commande")] public string StatutId { get; set; }

    [DisplayName("Statut de la commande")] public string StatutNom { get; set; }

    [DisplayName("Demande d'annulation")] public bool EnDemandeAnnulation { get; set; }

    [DisplayName("Promotion")] public string? PromotionId { get; set; }

    public Promotion? Promotion { get; set; }

    public CommandesVM()
    {
        Id = "";
        DateCommande = DateTime.Now;
        PrixTotal = 0;
        MembreUserName = "";
        AdresseId = "";
        LivreCommandes = new();
        StatutId = "";
        StatutNom = "";
        EnDemandeAnnulation = false;
        PromotionId = "";
        Promotion = new();

    }
    public CommandesVM(Commande commande)
    {
        commande ??= new();
        Id = commande.Id;
        DateCommande = commande.DateCommande;
        PrixTotal = commande.PrixTotal;
        MembreUserName = (commande.Membre ?? new()).UserName;
        AdresseId = commande.AdresseId;
        LivreCommandes = (commande.LivreCommandes ?? new List<LivreCommande>()).ToList().Select(lc => new LivreCommandeVM(lc)).ToList();
        StatutId = commande.StatutCommandeId;
        StatutNom = (commande.StatutCommande ?? new()).Nom;
        EnDemandeAnnulation = commande.EnDemandeAnnulation;
        PromotionId = commande.PromotionId;
        Promotion = commande.Promotion;
    }
}