using System.ComponentModel;

namespace VLISSIDES.Models;

public class Membre : ApplicationUser
{
    [DisplayName("Numéro de membre")]
    public string NoMembre { get; set; } = default!;

    [DisplayName("Date d'adhésion")]
    public DateTime DateAdhesion { get; set; } = default!;

    [DisplayName("Identifiant de la commande")]
    public string? CommandeId { get; set; }

    [DisplayName("Commandes")]
    public ICollection<Commande>? Commandes { get; set; }

    [DisplayName("Identifiant de la réservation")]
    public string? ReservationId { get; set; } = default!;

    [DisplayName("Réservations")]
    public ICollection<Reservation>? Reservations { get; set; }

    [DisplayName("Livres favoris")]
    public ICollection<Favori>? Favoris { get; set; }
}