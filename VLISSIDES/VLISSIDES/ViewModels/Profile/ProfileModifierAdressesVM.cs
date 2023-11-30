using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Profile;

public class ProfileModifierAdressesVM
{
    public string? Id { get; set; }

    [Required(ErrorMessage = "Le numéro civique est obligatoire")]
    [DisplayName("Numéro civique")]
    public string NoCivique { get; set; } = default!;

    [Required(ErrorMessage = "La rue est obligatoire")]
    [DisplayName("Rue")]
    public string Rue { get; set; } = default!;


    [DisplayName("Numéro apartement")]
    public string? NoApartement { get; set; } = default!;

    [Required(ErrorMessage = "La ville est obligatoire")]
    [DisplayName("Ville")]
    public string Ville { get; set; } = default!;

    [Required(ErrorMessage = "La province est obligatoire")]
    [DisplayName("Province")]
    public string Province { get; set; } = default!;

    [Required(ErrorMessage = "Le code postal est obligatoire")]
    [DisplayName("Code postal")]
    public string CodePostal { get; set; } = default!;

    [Required(ErrorMessage = "Le pays est obligatoire")]
    [DisplayName("Pays")]
    public string Pays { get; set; } = default!;
    //public Adresse? AdressePrincipale { get; set; }


    public List<Adresse>? AdressesDeLivraison { get; set; }
}