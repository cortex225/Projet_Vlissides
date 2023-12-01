using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionCommandes;

public class AffichageCommandeVM
{
    [Display(Name = "Commandes")] public List<CommandesVM> ListCommandes { get; set; }

    [Display(Name = "Statut:")] public string StatutId { get; set; }
    [Display(Name = "Statuts")] public List<SelectListItem> SelectListStatut { get; set; }

    public AffichageCommandeVM(IEnumerable<Commande> listCommandes, IEnumerable<StatutCommande> selectListStatut,
        string statutId = "")
    {
        listCommandes ??= new List<Commande>();
        selectListStatut ??= new List<StatutCommande>();
        ListCommandes = listCommandes.Select(c => new CommandesVM(c)).OrderByDescending(c => c.DateCommande).ToList();
        StatutId = statutId;
        SelectListStatut = selectListStatut.Select(s => new SelectListItem
        {
            Text = s.Nom,
            Value = s.Id
        }).ToList();
    }
}