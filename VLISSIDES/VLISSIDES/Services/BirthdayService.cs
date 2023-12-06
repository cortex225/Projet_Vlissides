using VLISSIDES.Data;
using VLISSIDES.Interfaces;
using VLISSIDES.Models;

namespace VLISSIDES.Services;

public class BirthdayService : BackgroundService // Service qui peut tourner en arrière plan
{
    private readonly ILogger<BirthdayService> _logger;

    private readonly IServiceScopeFactory
        _scopeFactory; // va permettre de créer un nouveau scope pour chaque itération de la boucle, le scope qui sera utilisé pour accéder à la base de données

    private readonly ISendGridEmailAdvance _sendGridEmailAdvance;

    public BirthdayService(ILogger<BirthdayService> logger, IServiceScopeFactory scopeFactory,
        ISendGridEmailAdvance sendGridEmailAdvance)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
        _sendGridEmailAdvance = sendGridEmailAdvance;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Birthday Service running at: {time}", DateTimeOffset.Now);
            await CheckBirthdaysAndSendEmails(stoppingToken);
            await Task.Delay(TimeSpan.FromDays(1), stoppingToken); // Attendre 24 heures
        }
    }

    private async Task CheckBirthdaysAndSendEmails(CancellationToken stoppingToken)
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var today = DateTime.Today;
            var usersWithBirthday = dbContext.Users
                .Where(u => u.DateNaissance.HasValue &&
                            u.DateNaissance.Value.Month == today.Month &&
                            u.DateNaissance.Value.Day == today.Day)
                .ToList();

            foreach (var user in usersWithBirthday)
            {
                if (stoppingToken.IsCancellationRequested)
                    break;

                // Générer le contenu de l'e-mail
                var emailContent = GenerateBirthdayEmailContent(user);

                // Envoye un courriel HTML sans pièces jointes
                await _sendGridEmailAdvance.SendEmailAsync(user.Email, "Joyeux Anniversaire", emailContent, true,
                    null); // Ajout de 'null' pour les pièces jointes
                _logger.LogInformation("Sent birthday email to: {Email}", user.Email);
            }
        }
    }

    private string GenerateBirthdayEmailContent(ApplicationUser user)
    {
        try
        {
            // Charge le modèle HTML depuis un fichier dans Data/TemplateEmail
            var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "TemplateEmail",
                "BirthdayEmail.html");
            var emailTemplate = File.ReadAllText(emailTemplatePath);


            // Remplace les placeholders par les données réelles de l'utilisateur
            emailTemplate = emailTemplate.Replace("{{UserName}}", user.UserName);

            // Retourne le contenu HTML généré
            return emailTemplate;
        }
        catch (DirectoryNotFoundException ex)
        {
            _logger.LogError(ex, "Le dossier du modèle d'email n'a pas été trouvé.");
            // Retourne un contenu par défaut ou gére l'erreur comme nécessaire
            return "Contenu d'email par défaut";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la génération du contenu de l'email.");
            return "Contenu d'email par défaut";
        }
    }
}