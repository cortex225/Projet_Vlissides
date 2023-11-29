using SendGrid.Helpers.Mail;

namespace VLISSIDES.Interfaces;

public interface ISendGridEmailAdvance
{
    Task SendEmailAsync(string toEmail, string subject, string message, bool isHtml, List<Attachment>? attachments);
}