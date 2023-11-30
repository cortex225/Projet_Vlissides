using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionComptes
{
    public class GestionComptesMembreVM
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Courriel { get; set; }
        public bool IsBanned { get; set; }

        public GestionComptesMembreVM(ApplicationUser user)
        {
            Id = user.Id;
            Nom = user.UserName;
            Courriel = user.Email;
            IsBanned = user.IsBanned;
        }
    }
}
