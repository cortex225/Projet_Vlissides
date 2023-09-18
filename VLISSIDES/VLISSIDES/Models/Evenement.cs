using System.ComponentModel;

namespace VLISSIDES.Models;

public class Evenement
{
    public string Id { get; set; } = default!;

    [DisplayName("Nom")] public string Nom { get; set; } = default!;

    [DisplayName("Description")] public string Description { get; set; } = default!;

    [DisplayName("Image")] public string Image { get; set; } = default!;

    [DisplayName("Date de d�but")] public DateTime DateDebut { get; set; } = default!;

    [DisplayName("Date de fin")] public DateTime DateFin { get; set; } = default!;

    [DisplayName("R�servations")] public ICollection<Reservation>? Reservations { get; set; }
}