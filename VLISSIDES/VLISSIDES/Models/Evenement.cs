namespace VLISSIDES.Models;

public class Evenement
{
    public string Id { get; set; }

    public string Nom { get; set; }

    public string Description { get; set; }

    public DateTime DateDebut { get; set; }

    public DateTime DateFin { get; set; }

    public ICollection<Reservation> Reservations { get; set; }
}