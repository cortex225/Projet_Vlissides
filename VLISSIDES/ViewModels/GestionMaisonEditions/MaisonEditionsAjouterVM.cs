using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.MaisonEditions;

public class MaisonEditionsAjouterVM
{
    [Display(Name = "Nom")] public string Nom { get; set; }

    public MaisonEditionsAjouterVM()
    {
        Nom = "";
    }
}