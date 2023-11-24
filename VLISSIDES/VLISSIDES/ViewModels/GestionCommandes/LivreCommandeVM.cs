using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionCommandes;

public class LivreCommandeVM
{
    [Display(Name = "Livre")] public Livre Livre { get; set; }

    [Display(Name = "Commande identifiant")] public string CommandeId { get; set; }

    [Display(Name = "Quantité")] public int Quantite { get; set; }

    [Display(Name = "Prix de l'achat")] public double PrixAchat { get; set; }

    [Display(Name = "En demande d'être retourné")] public bool EnDemandeRetourne { get; set; }

    public LivreCommandeVM(LivreCommande livreCommande)
    {
        Livre = livreCommande.Livre;
        CommandeId = livreCommande.CommandeId;
        Quantite = livreCommande.Quantite;
        PrixAchat = livreCommande.PrixAchat;
        EnDemandeRetourne = livreCommande.EnDemandeRetourner;
    }
}