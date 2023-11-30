using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionComptes;

public class GestionComptesAdminVM
{
    [DisplayName("Identifiant")] public string Id { get; set; }
    [DisplayName("Nom")] public string Nom { get; set; }
    [DisplayName("Courriel")] public string Courriel { get; set; }

    public GestionComptesAdminVM(ApplicationUser user)
    {
        Id = user.Id;
        Nom = user.UserName;
        Courriel = user.Email;
    }
}