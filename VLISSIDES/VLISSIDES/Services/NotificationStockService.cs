
using VLISSIDES.Data;
using VLISSIDES.Interfaces;
using VLISSIDES.Models;

public class NotificationStockService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ISendGridEmailAdvance _sendGridEmailAdvance;
    private readonly ILogger<NotificationStockService> _logger;

    public NotificationStockService(IServiceScopeFactory serviceScopeFactory,
                                    ISendGridEmailAdvance sendGridEmailAdvance,
                                    ILogger<NotificationStockService> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _sendGridEmailAdvance = sendGridEmailAdvance;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await VerifierStockEtEnvoyerNotifications(dbContext, stoppingToken);

            }


            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
        }
    }

    private async Task VerifierStockEtEnvoyerNotifications(ApplicationDbContext dbContext, CancellationToken cancellationToken)
    {
        // Assurez-vous de vérifier si l'opération a été annulée
        if (cancellationToken.IsCancellationRequested) return;

        try
        {
            var demandes = dbContext.DemandesNotifications.Where(d => !d.NotificationEnvoyee).ToList();

            foreach (var demande in demandes)
            {
                var livre = dbContext.Livres.Find(demande.LivreId);
                if (livre != null && livre.NbExemplaires > 0)
                {
                    var membre = dbContext.Membres.Find(demande.MembreId);
                    if (membre != null)
                    {
                        var emailContent = GenerateStockNotificationEmailContent(membre, livre);
                        await EnvoyerNotification(membre.Email, livre.Titre, emailContent);
                        demande.NotificationEnvoyee = true;
                    }
                }
            }

            dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erreur lors de la vérification du stock et de l'envoi des notifications: {ex.Message}");
        }
    }

    private async Task EnvoyerNotification(string email, string titreLivre, string content)
    {
        string subject = "Livre Disponible : " + titreLivre;
        await _sendGridEmailAdvance.SendEmailAsync(email, subject, content, true, null);

    }

    private string GenerateStockNotificationEmailContent(ApplicationUser user, Livre livre)
    {
        try
        {
            var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "TemplateEmail",
                "NotificationStockEmail.html");
            var emailTemplate = File.ReadAllText(emailTemplatePath);

            emailTemplate = emailTemplate.Replace("{{UserName}}", user.UserName);
            emailTemplate = emailTemplate.Replace("{{TitreLivre}}", livre.Titre);

            return emailTemplate;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la génération du contenu de l'email.");
            return "Contenu d'email par défaut pour la notification de stock";
        }
    }

}
