namespace VLISSIDES.Models;

public class Reservation
{
    public string Id { get; set; }

    public DateTime DateReservation { get; set; }

    public string Description { get; set; }

    public string EvenementId { get; set; }

    public Evenement Evenement { get; set; }

    public string MembreId { get; set; }

    public Membre Membre { get; set; }
}