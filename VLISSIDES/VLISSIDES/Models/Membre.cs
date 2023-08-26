namespace VLISSIDES.Models;

public class Membre : ApplicationUser
{
    public string NoMembre { get; set; }

    public DateTime DateAdhesion { get; set; }

    public string? CommandeId { get; set; }

    public ICollection<Commande>? Commandes { get; set; }

    public string? ReservationId { get; set; }

    public ICollection<Reservation>? Reservations { get; set; }

    public ICollection<Favori>? Favoris { get; set; }

    // Adresse principale
    public string AdressePrincipaleId { get; set; }
    public  Adresse AdressePrincipale { get; set; }

    // Adresse de livraison
    public string AdresseLivraisonId { get; set; }
    public ICollection<Adresse>? AdressesLivraison { get; set; }

}