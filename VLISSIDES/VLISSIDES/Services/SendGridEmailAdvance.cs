using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using VLISSIDES.Helpers;
using VLISSIDES.Interfaces;

namespace VLISSIDES.Services;

public class SendGridEmailAdvance : ISendGridEmailAdvance
{
    private readonly ILogger<SendGridEmailAdvance> _logger;
    public AuthMessageSenderOptions Options { get; set; }

    public SendGridEmailAdvance(IOptions<AuthMessageSenderOptions> optionsAccessor, ILogger<SendGridEmailAdvance> logger)
    {
        Options = optionsAccessor.Value;
        _logger = logger;
    }

    // Méthode pour envoyer un e-mail en texte brut
    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(Options.ApiKey)) throw new Exception("Null SendGridKey");
        await Execute(Options.ApiKey, subject, message, toEmail, null, false);
    }

    // Méthode pour envoyer un e-mail HTML avec des pièces jointes
    public async Task SendEmailAsync(string toEmail, string subject, string content, bool isHtml,
        List<Attachment>? attachments)
    {
        if (string.IsNullOrEmpty(Options.ApiKey)) throw new Exception("Null SendGridKey");
        await Execute(Options.ApiKey, subject, content, toEmail, attachments, isHtml);
    }

    private async Task Execute(string apiKey, string subject, string content, string toEmail, List<Attachment> attachments, bool isHtml)
    {
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage
        {
            From = new EmailAddress("1900751@cegepgranby.qc.ca", "La Fourmie Aillée"),
            Subject = subject,
            PlainTextContent = isHtml ? null : content,
            HtmlContent = isHtml ? content : null
        };

        msg.AddTo(new EmailAddress(toEmail));

        if (attachments != null)
        {
            foreach (var attachment in attachments)
            {
                msg.AddAttachment(attachment.Filename, attachment.Content, attachment.Type, attachment.Disposition, attachment.ContentId);
            }
        }

        msg.SetClickTracking(false, false);

        var response = await client.SendEmailAsync(msg);

        _logger.LogInformation(response.IsSuccessStatusCode
            ? $"Email to {toEmail} queued successfully!"
            : $"Failure Email to {toEmail}");
    }
}
