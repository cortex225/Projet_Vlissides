using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Evenements;

public class EvenementsVM
{
    [DisplayName("Identifiant")] public string Id { get; set; }

    [DisplayName("Nom")] public string Nom { get; set; }

    [DisplayName("Description")] public string Description { get; set; }

    [DisplayName("Image")] public string Image { get; set; }

    [DisplayName("Date de début")] public DateTime DateDebut { get; set; }

    [DisplayName("Date de fin")] public DateTime DateFin { get; set; }

    [DisplayName("Lieu")] public string Lieu { get; set; }

    [DisplayName("Nombre de places total")] public string NbPlaces { get; set; }

    [DisplayName("Nombre de places destinés aux membres")] public string NbPlacesMembre { get; set; }

    [DisplayName("Nombre de places réservées ")] public string NbPlacesReservees { get; set; }

    [DisplayName("Prix")] public decimal? Prix { get; set; }
    public bool EstEnDemandeAnnuler { get; set; }

    public EvenementsVM(Evenement evenement)
    {
        Id = evenement.Id;
        Nom = evenement.Nom;
        Description = evenement.Description;
        DateDebut = evenement.DateDebut;
        DateFin = evenement.DateFin;
        Image = evenement.Image;
        Lieu = evenement.Lieu;
        NbPlaces = evenement.Reservations == null ? evenement.NbPlaces.ToString() + "/" + evenement.NbPlaces.ToString()
            : (evenement.NbPlaces - evenement.Reservations.Select(rq => rq.Quantite).Sum()).ToString() + "/"
            + evenement.NbPlaces.ToString();
        NbPlacesMembre = evenement.Reservations == null ? evenement.NbPlacesMembre.ToString() + "/"
            + evenement.NbPlacesMembre.ToString() : (evenement.NbPlacesMembre
            - evenement.Reservations.Select(rq => rq.Quantite).Sum()).ToString() + "/"
            + evenement.NbPlacesMembre.ToString();
        NbPlacesReservees = evenement.Reservations == null ? evenement.NbPlacesReservees.ToString() + "/"
            + evenement.NbPlacesReservees.ToString() : (evenement.NbPlacesReservees
            - evenement.Reservations.Select(rq => rq.Quantite).Sum()).ToString() + "/"
            + evenement.NbPlacesReservees.ToString();
        Prix = evenement.Prix;
        EstEnDemandeAnnuler = false;
    }
    public EvenementsVM(Reservation reservation)
    {
        Id = reservation.Evenement.Id;
        Nom = reservation.Evenement.Nom;
        Description = reservation.Evenement.Description;
        DateDebut = reservation.Evenement.DateDebut;
        DateFin = reservation.Evenement.DateFin;
        Image = reservation.Evenement.Image;
        Lieu = reservation.Evenement.Lieu;
        NbPlaces = reservation.Evenement.Reservations == null ? reservation.Evenement.NbPlaces.ToString() + "/"
            + reservation.Evenement.NbPlaces.ToString() : (reservation.Evenement.NbPlaces
            - reservation.Evenement.Reservations.Select(rq => rq.Quantite).Sum()).ToString() + "/"
            + reservation.Evenement.NbPlaces.ToString();
        NbPlacesMembre = reservation.Evenement.Reservations == null ? reservation.Evenement.NbPlacesMembre.ToString() + "/"
            + reservation.Evenement.NbPlacesMembre.ToString() : (reservation.Evenement.NbPlacesMembre
            - reservation.Evenement.Reservations.Select(rq => rq.Quantite).Sum()).ToString() + "/"
            + reservation.Evenement.NbPlacesMembre.ToString();
        NbPlacesReservees = reservation.Evenement.Reservations == null ? reservation.Evenement.NbPlacesReservees.ToString()
            + "/" + reservation.Evenement.NbPlacesReservees.ToString() : (reservation.Evenement.NbPlacesReservees
            - reservation.Evenement.Reservations.Select(rq => rq.Quantite).Sum()).ToString() + "/"
            + reservation.Evenement.NbPlacesReservees.ToString();
        Prix = reservation.Evenement.Prix;
        EstEnDemandeAnnuler = reservation.EnDemandeAnnuler ?? false;
    }
}