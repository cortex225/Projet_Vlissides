using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Paiement;

public class AdresseVM
{
    [DisplayName("Identifiant")] public string? Id { get; set; }
    [DisplayName("Numéro Civique")] public string NoCivique { get; set; }

    [DisplayName("Rue")] public string Rue { get; set; }

    [DisplayName("Numéro Apartement")] public string? NoApartement { get; set; }

    [DisplayName("Ville")] public string Ville { get; set; }

    [DisplayName("Province")] public string Province { get; set; }

    [DisplayName("Code Postal")] public string CodePostal { get; set; }

    [DisplayName("Pays")] public string Pays { get; set; }

    public AdresseVM(Adresse adresse)
    {
        Id = adresse.Id;
        NoCivique = adresse.NoCivique;
        Rue = adresse.Rue;
        NoApartement = adresse.NoApartement;
        Ville = adresse.Ville;
        Province = adresse.Province;
        CodePostal = adresse.CodePostal;
        Pays = adresse.Pays;
    }
}