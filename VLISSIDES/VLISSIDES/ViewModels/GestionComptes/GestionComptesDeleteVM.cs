using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionComptes;

public class GestionComptesDeleteVM
{
    [DisplayName("Identifiant")] public string Id { get; set; }
    [DisplayName("Nom")] public string Nom { get; set; }

    public GestionComptesDeleteVM()
    {
        Id = "";
        Nom = "";
    }
    public GestionComptesDeleteVM(ApplicationUser user)
    {
        Id = user.Id;
        Nom = user.Nom;
    }
}