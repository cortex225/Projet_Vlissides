using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Profile
{
    public class ProfileModifierAdressesVM
    {
        public string AdressePrincipale { get; set; }
        public List<Adresse>? AdressesDeLivraison { get; set; }
    }
}
