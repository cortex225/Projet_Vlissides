using System.ComponentModel;

namespace VLISSIDES.ViewModels.Paiement;

public class AdresseVM
{
    [DisplayName("Numéro Civique")] public string NoCivique { get; set; }

    [DisplayName("Rue")] public string Rue { get; set; }

    [DisplayName("Numéro Apartement")] public string? NoApartement { get; set; }

    [DisplayName("Ville")] public string Ville { get; set; }

    [DisplayName("Province")] public string Province { get; set; }

    [DisplayName("Code Postal")] public string CodePostal { get; set; }

    [DisplayName("Pays")] public string Pays { get; set; }
    public string? AdresseId { get; set; }

}