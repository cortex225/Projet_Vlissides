using System.ComponentModel;

namespace VLISSIDES.Models;

public class Evenement
{
    public string Id { get; set; } = default!;

    [DisplayName("Nom")] public string Nom { get; set; } = default!;

    [DisplayName("Description")] public string Description { get; set; } = default!;

    [DisplayName("Image")] public string Image { get; set; } = default!;

    [DisplayName("Date de début")] public DateTime DateDebut { get; set; } = default!;

    [DisplayName("Date de fin")] public DateTime DateFin { get; set; } = default!;

    [DisplayName("Lieu")] public string Lieu { get; set; } = default!;

    [DisplayName("Nombre de places total")]
    public int NbPlaces { get; set; } = default!;

    [DisplayName("Nombre de places réservé au membre")]
    public int NbPlacesMembre { get; set; } = default!;

    [DisplayName("Prix")] public decimal? Prix { get; set; } = default!;

    [DisplayName("Nombre de places réservées")]
    public int? NbPlacesReservees { get; set; } = default!;


    [DisplayName("Réservations")] public ICollection<Reservation>? Reservations { get; set; }
}