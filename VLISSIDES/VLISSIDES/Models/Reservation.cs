namespace VLISSIDES.Models;

public class Reservation
{
    public string Id { get; set; } = default!;

    public DateTime DateReservation { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string EvenementId { get; set; } = default!;

    public Evenement Evenement { get; set; } = default!;

    public string MembreId { get; set; } = default!;

    public Membre Membre { get; set; } = default!;
}