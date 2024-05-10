using System.ComponentModel;

namespace VLISSIDES.Models;

public class Reservation
{
    public string Id { get; set; } = default!;

    [DisplayName("Date r�servation")] public DateTime DateReservation { get; set; } = default!;

    [DisplayName("Description")] public string Description { get; set; } = default!;

    [DisplayName("Identifiant de l'�venement")]
    public string EvenementId { get; set; } = default!;

    [DisplayName("�venement associ�")] public Evenement Evenement { get; set; } = default!;

    [DisplayName("Identifiant du membre r�servateur")]
    public string MembreId { get; set; } = default!;

    [DisplayName("Membre r�servateur")] public Membre Membre { get; set; } = default!;
    public decimal? prixAchat { get; set; } = default!;

    public string? PaymentIntentId { get; set; } = default!;

    public bool? EnDemandeAnnuler { get; set; } = default!;

    [DisplayName("Quantité")] public int Quantite { get; set; } = 1;
}