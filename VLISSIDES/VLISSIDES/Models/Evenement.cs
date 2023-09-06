namespace VLISSIDES.Models;

public class Evenement
{
    public string Id { get; set; } = default!;

    public string Nom { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string Image { get; set; } = default!;

    public DateTime DateDebut { get; set; } = default!;

    public DateTime DateFin { get; set; } = default!;

    public ICollection<Reservation>? Reservations { get; set; }
}