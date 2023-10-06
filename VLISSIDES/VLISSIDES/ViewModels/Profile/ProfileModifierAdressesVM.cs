using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Profile
{
    public class ProfileModifierAdressesVM
    {
        public string? Id { get; set; }
        [DisplayName("Numéro civique")] public string NoCivique { get; set; } = default!;

        [DisplayName("Rue")] public string Rue { get; set; } = default!;
        [DisplayName("Numéro apartement")] public string NoApartement { get; set; } = default!;

        [DisplayName("Ville")] public string Ville { get; set; } = default!;

        [DisplayName("Province")] public string Province { get; set; } = default!;

        [DisplayName("Code postal")] public string CodePostal { get; set; } = default!;

        [DisplayName("Pays")] public string Pays { get; set; } = default!;
        //public Adresse? AdressePrincipale { get; set; }


        public List<Adresse>? AdressesDeLivraison { get; set; }

    }
}
