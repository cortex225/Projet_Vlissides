using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.MaisonEditions;

public class MaisonEditionsModifierVM
{
    [Display(Name = "Identifiant")] public string Id { get; set; }
    [Display(Name = "Nom")] public string Nom { get; set; }

    public MaisonEditionsModifierVM(MaisonEdition maisonEdition)
    {
        Id = maisonEdition.Id;
        Nom = maisonEdition.Nom;
    }
}