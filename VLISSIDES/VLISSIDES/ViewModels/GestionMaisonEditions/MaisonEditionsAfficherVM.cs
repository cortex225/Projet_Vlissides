using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels;

public class MaisonEditionsAfficherVM
{
    [Display(Name = "Identifiant")] public string Id { get; set; }
    [Display(Name = "Nom")] public string Nom { get; set; }
    [Display(Name = "Livres")] public List<string> Livres { get; set; }

    public MaisonEditionsAfficherVM(MaisonEdition maisonEdition)
    {
        Id = maisonEdition.Id;
        Nom = maisonEdition.Nom;
        Livres = maisonEdition.Livres.Select(l => l.Titre).ToList();
    }
}