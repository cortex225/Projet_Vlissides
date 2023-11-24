using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.MaisonEditions;

public class MaisonEditionsIndexVM
{
    [Display(Name = "MaisonEditionsAjouterVM")] public MaisonEditionsAjouterVM? MaisonEditionsAjouterVM { get; set; }
    [Display(Name = "MaisonEditionsModifierVM")] public MaisonEditionsModifierVM? MaisonEditionsModifierVM { get; set; }
    [Display(Name = "MaisonEditionsAfficherVM")] public List<MaisonEditionsAfficherVM>? MaisonEditionsAfficherVM { get; set; }

    public MaisonEditionsIndexVM(MaisonEditionsAjouterVM? maisonEditionsAjouterVM,
        MaisonEditionsModifierVM? maisonEditionsModifierVM, List<MaisonEditionsAfficherVM>? maisonEditionsAfficherVM)
    {
        MaisonEditionsAjouterVM = maisonEditionsAjouterVM;
        MaisonEditionsModifierVM = maisonEditionsModifierVM;
        MaisonEditionsAfficherVM = maisonEditionsAfficherVM;
    }
}