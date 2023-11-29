using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionComptes
{
    public class GestionComptesBanVM
    {
        [Display(Name = "Identifiant")] public string Id { get; set; }
        [Display(Name = "Nom utilisateur")] public string Username { get; set; }

        public GestionComptesBanVM(ApplicationUser user)
        {
            Id = user.Id;
            Username = user.UserName;
        }
    }
}
