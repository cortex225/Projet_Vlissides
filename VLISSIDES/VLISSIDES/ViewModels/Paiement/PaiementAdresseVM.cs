using System.ComponentModel;

namespace VLISSIDES.ViewModels.Paiement
{
    public class PaiementAdresseVM
    {
        [DisplayName("Numéro civique")] public string NoCivique { get; set; } = default!;

        [DisplayName("Rue")] public string Rue { get; set; } = default!;
        [DisplayName("Numéro apartement")] public string NoApartement { get; set; } = default!;

        [DisplayName("Ville")] public string Ville { get; set; } = default!;

        [DisplayName("Province")] public string Province { get; set; } = default!;

        [DisplayName("Code postal")] public string CodePostal { get; set; } = default!;

        [DisplayName("Pays")] public string Pays { get; set; } = default!;
    }
}
