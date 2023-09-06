namespace VLISSIDES.Models;

public class Membre : ApplicationUser
{
    public string NoMembre { get; set; } = default!;

    public DateTime DateAdhesion { get; set; } = default!;

    public string? CommandeId { get; set; }

    public ICollection<Commande>? Commandes { get; set; }

    public string? ReservationId { get; set; } = default!;

    public ICollection<Reservation>? Reservations { get; set; }

    public ICollection<Favori>? Favoris { get; set; }
}