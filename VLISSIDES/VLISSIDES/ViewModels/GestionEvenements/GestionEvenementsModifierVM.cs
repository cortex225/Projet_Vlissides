using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionEvenements;

public class GestionEvenementsModifierVM
{
    [DisplayName("Identifiant")] public string Id { get; set; }
    [DisplayName("Nom")] public string Nom { get; set; }

    [DisplayName("Description")] public string Description { get; set; }

    [DisplayName("Image")] public string? Image { get; set; }

    [DisplayName("Date de début")] public DateTime DateDebut { get; set; }

    [DisplayName("Date de fin")] public DateTime DateFin { get; set; }

    [DisplayName("Lieu")] public string Lieu { get; set; }

    [DisplayName("Nombre de places total")] public int NbPlaces { get; set; }

    [DisplayName("Nombre de places réservé au membre")] public int NbPlacesMembre { get; set; }

    [DisplayName("Prix")] public string? Prix { get; set; }
    [Display(Name = "Image du livre")] public IFormFile? CoverPhoto { get; set; }

    public GestionEvenementsModifierVM(Evenement evenement, IFormFile? coverPhoto = null)
    {
        Id = evenement.Id;
        Nom = evenement.Nom;
        Description = evenement.Description;
        Image = evenement.Image;
        DateDebut = evenement.DateDebut;
        DateFin = evenement.DateFin;
        Lieu = evenement.Lieu;
        NbPlaces = evenement.NbPlaces;
        NbPlacesMembre = evenement.NbPlacesMembre;
        Prix = evenement.Prix.ToString();
        CoverPhoto = coverPhoto;
    }
}