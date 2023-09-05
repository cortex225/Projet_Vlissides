using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using VLISSIDES.Helpers;
using VLISSIDES.Interfaces;

namespace VLISSIDES.Services;

public class SendGridEmail : ISendGridEmail
{
    private readonly ILogger<SendGridEmail> _logger;

    public SendGridEmail(IOptions<AuthMessageSenderOptions> options, ILogger<SendGridEmail> logger)
    {
        Options = options.Value;
        _logger = logger;
    }

    public AuthMessageSenderOptions Options { get; set; }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(Options.ApiKey)) throw new Exception("Null SendGridKey");
        await Execute(Options.ApiKey, subject, message, toEmail);
    }

    private async Task Execute(string apiKey, string subject, string message, string toEmail)
    {
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage
        {
            From = new EmailAddress("1900751@cegepgranby.qc.ca", "La Fourmie Aillée"),
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = message
        };

        msg.AddTo(new EmailAddress(toEmail));

        // Disable click tracking.

        msg.SetClickTracking(false, false);
        var response = await client.SendEmailAsync(msg);
        var dummy = response.StatusCode;
        var dummy2 = response.Headers;
        _logger.LogInformation(response.IsSuccessStatusCode
            ? $"Email to {toEmail} queued successfully!"
            : $"Failure Email to {toEmail}");
        Console.WriteLine(response.IsSuccessStatusCode ? "Email queued successfully!" : "Something went wrong!");
    }
}