using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionComptes;

public class GestionComptesEmployeVM
{
    [DisplayName("Udentifiant")] public string Id { get; set; }
    [DisplayName("Nom")] public string Nom { get; set; }
    [DisplayName("courriel")] public string Courriel { get; set; }

    public GestionComptesEmployeVM(ApplicationUser user)
    {
        Id = user.Id;
        Nom = user.UserName;
        Courriel = user.Email;
    }
}