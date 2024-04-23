using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionEvenements;

public class GestionEvenementsAjouterVM
{
    [Required(ErrorMessage = "Le nom est obligatoire")]
    [DisplayName("Nom")] public string Nom { get; set; }

    [Required(ErrorMessage = "La description est obligatoire")]
    [DisplayName("Description")] public string Description { get; set; }

    [DisplayName("Image")] public string? Image { get; set; }

    [DisplayName("Date de début")] public DateTime DateDebut { get; set; }

    [DisplayName("Date de fin")] public DateTime DateFin { get; set; }

    [Required(ErrorMessage = "Le lieu est obligatoire")]
    [DisplayName("Lieu")] public string Lieu { get; set; }

    [Required(ErrorMessage = "Le nombre de place total est obligatoire")]
    [DisplayName("Nombre de places total")] public int NbPlaces { get; set; }

    [Required(ErrorMessage = "Le nombre de place réservé au membre est obligatoire")]
    [DisplayName("Nombre de places réservé au membre")] public int NbPlacesMembre { get; set; }


    [DisplayName("Prix")] public decimal Prix { get; set; }
    [Display(Name = "Image du livre")] public IFormFile? CoverPhoto { get; set; }

    public GestionEvenementsAjouterVM()
    {
        Nom = "";
        Description = "";
        Image = "";
        DateDebut = DateTime.Now;
        DateFin = DateTime.Now;
        Lieu = "";
        NbPlaces = 0;
        NbPlacesMembre = 0;
        Prix = 0;
        CoverPhoto = null;
    }
    public GestionEvenementsAjouterVM(Evenement evenement)
    {
        evenement ??= new();
        Nom = evenement.Nom;
        Description = evenement.Description;
        Image = evenement.Image;
        DateDebut = evenement.DateDebut;
        DateFin = evenement.DateFin;
        Lieu = evenement.Lieu;
        NbPlaces = evenement.NbPlaces;
        NbPlacesMembre = evenement.NbPlacesMembre;
        Prix = evenement.Prix ?? 0;
        CoverPhoto = null;
    }
}