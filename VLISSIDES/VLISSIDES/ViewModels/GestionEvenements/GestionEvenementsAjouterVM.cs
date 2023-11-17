using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.GestionEvenements;

public class GestionEvenementsAjouterVM
{
    [Required(ErrorMessage = "Le nom est obligatoire")]
    [DisplayName("Nom")]
    public string Nom { get; set; } = default!;

    [Required(ErrorMessage = "La description est obligatoire")]
    [DisplayName("Description")]
    public string Description { get; set; } = default!;

    [DisplayName("Image")] public string? Image { get; set; } = default!;

    [DisplayName("Date de début")] public DateTime DateDebut { get; set; } = default!;

    [DisplayName("Date de fin")] public DateTime DateFin { get; set; } = default!;

    [Required(ErrorMessage = "Le lieu est obligatoire")]
    [DisplayName("Lieu")]
    public string Lieu { get; set; } = default!;

    [Required(ErrorMessage = "Le nombre de place total est obligatoire")]
    [DisplayName("Nombre de places total")]
    public int NbPlaces { get; set; } = default!;

    [Required(ErrorMessage = "Le nombre de place réservé au membre est obligatoire")]
    [DisplayName("Nombre de places réservé au membre")]
    public int NbPlacesMembre { get; set; } = default!;


    [DisplayName("Prix")] public string? Prix { get; set; } = default!;
    [Display(Name = "Image du livre")] public IFormFile? CoverPhoto { get; set; }
}