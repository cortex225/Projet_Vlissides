using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.GestionEvenements;

public class GestionEvenementsModifierVM
{
    public string Id { get; set; }
    [DisplayName("Nom")] public string Nom { get; set; } = default!;

    [DisplayName("Description")] public string Description { get; set; } = default!;

    [DisplayName("Image")] public string? Image { get; set; } = default!;

    [DisplayName("Date de début")] public DateTime DateDebut { get; set; } = default!;

    [DisplayName("Date de fin")] public DateTime DateFin { get; set; } = default!;

    [DisplayName("Lieu")] public string Lieu { get; set; } = default!;

    [DisplayName("Nombre de places total")]
    public int NbPlaces { get; set; } = default!;

    [DisplayName("Nombre de places réservé au membre")]
    public int NbPlacesMembre { get; set; } = default!;

    [DisplayName("Prix")] public string? Prix { get; set; } = default!;
    [Display(Name = "Image du livre")] public IFormFile? CoverPhoto { get; set; }
}