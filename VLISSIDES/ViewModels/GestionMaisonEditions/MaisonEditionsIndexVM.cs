using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.MaisonEditions;

public class MaisonEditionsIndexVM
{
    [Display(Name = "Maison d'édition ajouté")] public MaisonEditionsAjouterVM? MaisonEditionsAjoute { get; set; }
    [Display(Name = "Maison d'édition modifié")] public MaisonEditionsModifierVM? MaisonEditionsModifie { get; set; }
    [Display(Name = "Maison d'édition affiché")] public List<MaisonEditionsAfficherVM>? MaisonEditionsAffiche { get; set; }

    public MaisonEditionsIndexVM()
    {
        MaisonEditionsAjoute = null;
        MaisonEditionsModifie = null;
        MaisonEditionsAffiche = new();
    }
    public MaisonEditionsIndexVM(IEnumerable<MaisonEdition> maisonEditions)
    {
        MaisonEditionsAjoute = null;
        MaisonEditionsModifie = null;
        MaisonEditionsAffiche = maisonEditions.Select(e => new MaisonEditionsAfficherVM(e)).ToList();
    }
}