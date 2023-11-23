using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VLISSIDES.ViewModels.GestionCommandes;

public class AffichageCommandeVM
{
    public List<CommandesVM> ListCommandes { get; set; }

    [Display(Name = "Statut:")] public string StatutId { get; set; }
    public List<SelectListItem> SelectListStatut { get; set; }
}