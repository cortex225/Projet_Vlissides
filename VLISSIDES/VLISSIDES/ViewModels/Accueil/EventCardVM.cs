//ViewModel pour _CarteEvenement.cshtml

using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil;

public class EventCardVM
{
    public EventCardVM(string image = "", string nom = "", string description = "", DateTime dateDebut = new(), DateTime dateFin = new(),
        int nbPlaces = 0, int nbPlacesRestantes = 0,int nbPlacesMembre=0, string lieu = "", decimal? prix = null)
    {
        Image = image;
        Nom = nom;
        Description = description;
        DateDebut = dateDebut;
        DateFin = dateFin;
        NbPlaces = nbPlaces;
        NbPlacesMembre= nbPlacesMembre;
        NbPlacesRestantes = nbPlacesRestantes;
        Lieu = lieu;
        Prix = prix;
        
    }




    public EventCardVM(Evenement evenement)
    {
        Image = evenement.Image;
        Nom = evenement.Nom;
        Description = evenement.Description;
        DateDebut = evenement.DateDebut;
        DateFin = evenement.DateFin;
        NbPlaces = evenement.NbPlaces;
        NbPlacesMembre = evenement.NbPlacesMembre;
        NbPlacesRestantes = evenement.NbPlaces - evenement.NbPlacesMembre;
        Lieu = evenement.Lieu;
        Prix = evenement.Prix;
        
    }

    [DisplayName("Image")] public string Image { get; set; }

    [DisplayName("NomAuteur")] public string Nom { get; set; }

    [DisplayName("Description")] public string Description { get; set; }
   [DisplayName("Prix de l'evenement")] public decimal? Prix { get; set; }

   [DisplayName("Lieux de l'evenement")] public string? Lieu { get; set; }

   [DisplayName("Nombre de place à la porte")] public int NbPlacesRestantes { get; set; }

   [DisplayName("Nombre de place memebre")] public int NbPlacesMembre { get; set; }
    [DisplayName("Nombre de place Total")] public int NbPlaces { get; set; }

   [DisplayName("Date de début de l'evenement")] public DateTime DateDebut { get; set; }
   [DisplayName("Date de fin de l'evenement")] public DateTime? DateFin { get; set; }
}