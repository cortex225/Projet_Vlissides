using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Profile;

public class ProfileModifierAdressesVM
{
    [DisplayName("Identifiant")] public string? Id { get; set; }

    [Required(ErrorMessage = "Le numéro civique est obligatoire")]
    [DisplayName("Numéro civique")] public string NoCivique { get; set; }

    [Required(ErrorMessage = "La rue est obligatoire")]
    [DisplayName("Rue")] public string Rue { get; set; }

    [Required(ErrorMessage = "Le numéro apartement est obligatoire")]
    [DisplayName("Numéro apartement")] public string NoApartement { get; set; }

    [Required(ErrorMessage = "La ville est obligatoire")]
    [DisplayName("Ville")] public string Ville { get; set; }

    [Required(ErrorMessage = "La province est obligatoire")]
    [DisplayName("Province")] public string Province { get; set; }

    [Required(ErrorMessage = "Le code postal est obligatoire")]
    [DisplayName("Code postal")] public string CodePostal { get; set; }

    [Required(ErrorMessage = "Le pays est obligatoire")]
    [DisplayName("Pays")] public string Pays { get; set; }


    [DisplayName("Adresses de livraison")] public List<string>? AdressesDeLivraison { get; set; }

    public ProfileModifierAdressesVM(Adresse adresse, IEnumerable<Adresse> adresses)
    {
        Id = adresse.Id;
        NoCivique = adresse.NoCivique;
        Rue = adresse.Rue;
        NoApartement = adresse.NoApartement;
        Ville = adresse.Ville;
        Province = adresse.Province;
        CodePostal = adresse.CodePostal;
        Pays = adresse.Pays;
        AdressesDeLivraison = adresses.Select(a => a.ToString()).ToList();
    }
}