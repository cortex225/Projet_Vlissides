namespace VLISSIDES.Interfaces;

public interface ISendGridEmail
{
    // Méthode existante pour envoyer un message texte simple
    Task SendEmailAsync(string toEmail, string subject, string message);
}