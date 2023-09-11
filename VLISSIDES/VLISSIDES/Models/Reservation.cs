using System.ComponentModel;

namespace VLISSIDES.Models;

public class Reservation
{
    public string Id { get; set; } = default!;

    [DisplayName("Date réservation")]
    public DateTime DateReservation { get; set; } = default!;

    [DisplayName("Description")]
    public string Description { get; set; } = default!;

    [DisplayName("Identifiant de l'évenement")]
    public string EvenementId { get; set; } = default!;

    [DisplayName("Évenement associé")]
    public Evenement Evenement { get; set; } = default!;

    [DisplayName("Identifiant du membre réservateur")]
    public string MembreId { get; set; } = default!;

    [DisplayName("Membre réservateur")]
    public Membre Membre { get; set; } = default!;
}