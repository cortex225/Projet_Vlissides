namespace VLISSIDES.Models;

public class DemandeNotification
{
    public string Id { get; set; } // Identifiant unique
    public string LivreId { get; set; } // ID du livre
    public string MembreId { get; set; } // ID du membre demandant la notification
    public bool NotificationEnvoyee { get; set; } = false; // Pour marquer si la notification a été envoyée
}