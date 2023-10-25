using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.GestionCommandes
{
    public class AffichageCommandeVM
    {
        public List<CommandesVM> ListCommandes { get; set; }

        [Display(Name = "Statut:")] public string StatutId { get; set; }
        public List<SelectListItem> SelectListStatut { get; set; }
    }
}
