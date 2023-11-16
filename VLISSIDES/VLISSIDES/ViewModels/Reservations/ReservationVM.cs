namespace VLISSIDES.ViewModels.Reservations;

public class ReservationVM
{
    public string EvenementNom { get; set; }
    public string Description { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime DateFin { get; set; }
    public string Lieu { get; set; }
    public int NombreDePlaces { get; set; }
    public decimal? PrixTotal { get; set; }
    public string? Id { get; set; }
}