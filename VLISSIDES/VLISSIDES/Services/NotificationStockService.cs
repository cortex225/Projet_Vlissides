using VLISSIDES.Data;
using VLISSIDES.Interfaces;
using VLISSIDES.Models;

public class NotificationStockService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ISendGridEmailAdvance _sendGridEmailAdvance;
    private readonly ILogger<NotificationStockService> _logger;

    // Constructeur pour injecter les dépendances nécessaires
    public NotificationStockService(IServiceScopeFactory serviceScopeFactory,
        ISendGridEmailAdvance sendGridEmailAdvance,
        ILogger<NotificationStockService> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;//Permet de créer un scope pour accéder aux services
        _sendGridEmailAdvance = sendGridEmailAdvance;//Permet d'envoyer un mail
        _logger = logger;//Permet de logger les erreurs
    }

    // Méthode principale exécutée par le service en arrière-plan
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Boucle continue jusqu'à ce que le signal d'arrêt soit reçu
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await VerifierStockEtEnvoyerNotifications(dbContext, stoppingToken);
            }

            // Pause d'un jour avant la prochaine vérification
            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
        }
    }

    // Méthode pour vérifier le stock et envoyer des notifications
    private async Task VerifierStockEtEnvoyerNotifications(ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        // Vérification préalable d'une demande d'annulation
        if (cancellationToken.IsCancellationRequested) return;

        try
        {
            // Récupération des demandes de notification non traitées
            var demandes = dbContext.DemandesNotifications.Where(d => !d.NotificationEnvoyee).ToList();

            // Traitement de chaque demande
            foreach (var demande in demandes)
            {
                var livre = dbContext.Livres.Find(demande.LivreId);
                // Vérification de la disponibilité du livre
                if (livre != null && livre.NbExemplaires > 0)
                {
                    var membre = dbContext.Membres.Find(demande.MembreId);
                    // Envoi d'une notification par e-mail si le membre est trouvé
                    if (membre != null)
                    {
                        var emailContent = GenerateStockNotificationEmailContent(membre, livre);
                        await EnvoyerNotification(membre.Email, livre.Titre, emailContent);
                        demande.NotificationEnvoyee = true;
                    }
                }
            }

            // Sauvegarde des modifications dans la base de données
            dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            // Gestion des erreurs lors de la vérification ou de l'envoi des notifications
            _logger.LogError($"Erreur lors de la vérification du stock et de l'envoi des notifications: {ex.Message}");
        }
    }

    // Méthode pour envoyer une notification par e-mail
    private async Task EnvoyerNotification(string email, string titreLivre, string content)
    {
        string subject = "Livre Disponible : " + titreLivre;
        await _sendGridEmailAdvance.SendEmailAsync(email, subject, content, true, null);
    }

    // Méthode pour générer le contenu de l'e-mail de notification
    private string GenerateStockNotificationEmailContent(ApplicationUser user, Livre livre)
    {
        try
        {
            // Chargement et mise en forme du template d'e-mail
            var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "TemplateEmail",
                "NotificationStockEmail.html");
            var emailTemplate = File.ReadAllText(emailTemplatePath);

            emailTemplate = emailTemplate.Replace("{{UserName}}", user.UserName);
            emailTemplate = emailTemplate.Replace("{{TitreLivre}}", livre.Titre);

            return emailTemplate;
        }
        catch (Exception ex)
        {
            // Gestion des erreurs lors de la génération du contenu de l'e-mail
            _logger.LogError(ex, "Une erreur est survenue lors de la génération du contenu de l'email.");
            return "Contenu d'email par défaut pour la notification de stock";
        }
    }
}
