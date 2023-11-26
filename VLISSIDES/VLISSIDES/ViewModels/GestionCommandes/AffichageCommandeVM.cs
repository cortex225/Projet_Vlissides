using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionCommandes;

public class AffichageCommandeVM
{
    [Display(Name = "Commande")] public List<CommandesVM> Commandes { get; set; }

    [Display(Name = "Statut:")] public string StatutId { get; set; }
    [Display(Name = "Liste statue")] public List<SelectListItem> ListStatut { get; set; }

    public AffichageCommandeVM(IEnumerable<CommandesVM> commandes, string statutId, IEnumerable<StatutCommande> listStatut)
    {
        Commandes = commandes.ToList();
        StatutId = statutId;
        ListStatut = listStatut.Select(ls=>new SelectListItem(ls.Nom,ls.Id)).ToList();
    }
}