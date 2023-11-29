using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using VLISSIDES.Helpers;
using VLISSIDES.Interfaces;

namespace VLISSIDES.Services;

public class SendGridEmailAdvance : ISendGridEmailAdvance
{
    // Déclaration d'une variable pour enregistrer les messages d'erreur ou d'information.
    private readonly ILogger<SendGridEmailAdvance> _logger;

    // Constructeur de la classe qui initialise les options de configuration et le logger.
    public SendGridEmailAdvance(IOptions<AuthMessageSenderOptions> optionsAccessor,
        ILogger<SendGridEmailAdvance> logger)
    {
        Options = optionsAccessor.Value;
        _logger = logger;
    }

    // Propriété publique pour accéder aux options de configuration de SendGrid.
    public AuthMessageSenderOptions Options { get; set; }

    // Méthode asynchrone pour envoyer un e-mail HTML avec des pièces jointes.
    public async Task SendEmailAsync(string toEmail, string subject, string content, bool isHtml,
        List<Attachment>? attachments)
    {
        // Vérifie si la clé API de SendGrid est présente, sinon lance une exception.
        if (string.IsNullOrEmpty(Options.ApiKey)) throw new Exception("Null SendGridKey");
        // Appelle la méthode Execute pour envoyer l'email.
        await Execute(Options.ApiKey, subject, content, toEmail, attachments, isHtml);
    }

    // Méthode asynchrone pour envoyer un e-mail en texte brut.
    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        // Vérifie si la clé API de SendGrid est présente, sinon lance une exception.
        if (string.IsNullOrEmpty(Options.ApiKey)) throw new Exception("Null SendGridKey");
        // Appelle la méthode Execute pour envoyer l'email.
        await Execute(Options.ApiKey, subject, message, toEmail, null, false);
    }

    // Méthode privée asynchrone qui effectue l'envoi de l'e-mail.
    private async Task Execute(string apiKey, string subject, string content, string toEmail,
        List<Attachment> attachments, bool isHtml)
    {
        // Crée un nouveau client SendGrid avec la clé API.
        var client = new SendGridClient(apiKey);
        // Crée un nouveau message SendGrid.
        var msg = new SendGridMessage
        {
            From = new EmailAddress("1900751@cegepgranby.qc.ca", "La Fourmie Aillée"),
            Subject = subject,
            PlainTextContent = isHtml ? null : content,
            HtmlContent = isHtml ? content : null
        };

        // Ajoute le destinataire de l'e-mail.
        msg.AddTo(new EmailAddress(toEmail));

        // Si des pièces jointes sont fournies, les ajoute au message.
        if (attachments != null)
            foreach (var attachment in attachments)
                msg.AddAttachment(attachment.Filename, attachment.Content, attachment.Type, attachment.Disposition,
                    attachment.ContentId);

        // Désactive le suivi des clics dans l'e-mail.
        msg.SetClickTracking(false, false);

        // Envoie l'e-mail et attend la réponse de SendGrid.
        var response = await client.SendEmailAsync(msg);

        // Enregistre un message d'information dans le logger selon le succès ou l'échec de l'envoi.
        _logger.LogInformation(response.IsSuccessStatusCode
            ? $"Email to {toEmail} queued successfully!"
            : $"Failure Email to {toEmail}");
    }
}