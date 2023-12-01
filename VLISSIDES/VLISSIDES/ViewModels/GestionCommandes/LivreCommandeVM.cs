using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionCommandes;

public class LivreCommandeVM
{
    [DisplayName("Date de commande")] public Livre Livre { get; set; }

    [DisplayName("Date de commande")] public string CommandeId { get; set; }

    [DisplayName("Date de commande")] public int Quantite { get; set; }

    [DisplayName("Date de commande")] public double PrixAchat { get; set; }

    [DisplayName("Date de commande")] public bool EnDemandeRetourner { get; set; }

    public LivreCommandeVM()
    {
        Livre = new();
        CommandeId = "";
        Quantite = 0;
        PrixAchat = 0;
        EnDemandeRetourner = false;
    }
    public LivreCommandeVM(LivreCommande livreCommande)
    {
        livreCommande ??= new();
        Livre = livreCommande.Livre;
        CommandeId = livreCommande.CommandeId;
        Quantite = livreCommande.Quantite;
        PrixAchat = livreCommande.PrixAchat;
        EnDemandeRetourner = livreCommande.EnDemandeRetourner;
    }
}