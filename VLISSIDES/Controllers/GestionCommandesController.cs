using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using VLISSIDES.Data;
using VLISSIDES.Interfaces;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionCommandes;
using VLISSIDES.ViewModels.HistoriqueCommandes;

namespace VLISSIDES.Controllers;

[Authorize(Roles = RoleName.EMPLOYE + ", " + RoleName.ADMIN)]
public class GestionCommandesController : Controller
{
    private readonly IConfiguration _config;
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ISendGridEmail _sendGridEmail;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public GestionCommandesController(ApplicationDbContext context,
        IWebHostEnvironment webHostEnvironment,
        IConfiguration config,
        UserManager<ApplicationUser> userManager,
        IHttpContextAccessor httpContextAccessor,
        ISendGridEmail sendGridEmail)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        _config = config;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _sendGridEmail = sendGridEmail;
    }

    public IActionResult Index(int page = 1)
    {
        var itemsPerPage = 10;
        var totalItems = _context.Commandes.Count();

        var commandes = _context.Commandes
            .Include(c => c.StatutCommande)
            .Include(c => c.Membre)
            .Include(c => c.LivreCommandes).ThenInclude(c => c.Livre)
            .OrderBy(c => c.DateCommande)
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToList();

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);

        return View(new AffichageCommandeVM(commandes, _context.StatutCommandes));
    }

    public async Task<IActionResult> AfficherCommandes(string? motCles, string? criteres, int? page = 1)
    {
        var itemsPerPage = 10;
        var totalItems = await _context.Commandes.CountAsync();

        var currentUserId = _userManager.GetUserId(HttpContext.User);
        var listCriteresValue = new List<string>();
        if (motCles != null) listCriteresValue = motCles.Split('|').ToList();

        var listCriteres = new List<string>();
        if (criteres != null) listCriteres = criteres.Split('|').ToList();

        //var currentUserId = _userManager.GetUserId(HttpContext.User);
        List<Commande> commandes = _context.Commandes
            .Include(c => c.StatutCommande).Include(c => c.LivreCommandes).ThenInclude(c => c.Livre)
            .Include(c => c.Membre).ToList();
        var livreCommandes = _context.LivreCommandes;

        var livreCommandeVM = livreCommandes.Select(lc => new LivreCommandeVM(lc))
            .ToList();


        if (listCriteres.Any(c => c == "rechercherCommande"))
            if (listCriteresValue[3] != "")
                commandes = commandes.Where(c => c.Id == listCriteresValue[3]).ToList();

        if (listCriteres.Any(c => c == "trierDate"))
        {
            if (listCriteresValue[0] == "2")
                commandes = commandes.OrderBy(c => c.DateCommande).ToList();
            else
                commandes = commandes.OrderByDescending(c => c.DateCommande).ToList();
        }

        if (listCriteres.Any(c => c == "filtrerStatut"))
            if (listCriteresValue[1] != "0")
                commandes = commandes.Where(c => c.StatutCommandeId == listCriteresValue[1]).ToList();

        if (listCriteres.Any(c => c == "demandeRemboursement"))
        {
            if (listCriteresValue[2] == "2")
                commandes = commandes.Where(c => c.EnDemandeAnnulation).ToList();
            if (listCriteresValue[2] == "3")
                commandes = commandes.Where(c => c.LivreCommandes.Any(lc => lc.EnDemandeRetourner))
                    .ToList();
        }

        //ViewBag qui permet de savoir sur quelle page on est et le nombre de pages total
        //Math.Ceiling permet d'arrondir au nombre supérieur
        // ReSharper disable once HeapView.BoxingAllocation
        ViewBag.CurrentPage = page;
        // ReSharper disable once HeapView.BoxingAllocation
        ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);

        var affichageCommandes = new AffichageCommandeVM(commandes, _context.StatutCommandes);
        affichageCommandes.ListCommandes.FirstOrDefault().NbCommande =
            _context.Commandes.Count(c => c.MembreId == currentUserId) + 1;
        return PartialView("PartialViews/GestionCommandes/_ListeCommandesPartial", affichageCommandes);
    }

    [HttpPost]
    public async Task<IActionResult> ModifierStatut(string id, string statut)
    {
        var commande = await _context.Commandes.FindAsync(id);
        if (commande == null) return NotFound("La commmande à l'identifiant " + id + " n'a pas été trouvé.");
        commande.StatutCommandeId = statut;
        await _context.SaveChangesAsync();
        return Ok();
    }

    public async Task<IActionResult> ShowAccepterRetourConfirmation(string commandeId, string livreId)
    {
        var livreCommande = await _context.LivreCommandes.Include(lc => lc.Livre).Include(lc => lc.Commande).Include(lc => lc.Commande.Membre)
            .FirstOrDefaultAsync(lc => lc.CommandeId == commandeId && lc.LivreId == livreId);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        if (livreCommande.QuantiteARetourner == null) return BadRequest();
        var vm = new RefundVM
        {
            Commande = livreCommande.Commande,
            Livre = livreCommande.Livre,
            Prix = livreCommande.PrixAchat,
            Quantite = (int)livreCommande.QuantiteARetourner,
            PaymentIntent = livreCommande.Commande.PaymentIntentId
        };
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        return PartialView("PartialViews/Modals/GestionCommandesModals/_ConfirmerAccepterRetourPartial", vm);
    }

    public async Task<IActionResult> ShowRefuserRetourConfirmation(string commandeId, string livreId)
    {
        var livreCommande = await _context.LivreCommandes.Include(lc => lc.Livre).Include(lc => lc.Commande)
            .Include(lc => lc.Commande.Membre)
            .FirstOrDefaultAsync(lc => lc.CommandeId == commandeId && lc.LivreId == livreId);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        if (livreCommande == null) return BadRequest();
        if (livreCommande.QuantiteARetourner == null) return BadRequest();
        var vm = new RefundVM
        {
            Commande = livreCommande.Commande,
            Livre = livreCommande.Livre,
            Prix = livreCommande.PrixAchat,
            Quantite = (int)livreCommande.QuantiteARetourner,
            PaymentIntent = livreCommande.Commande.PaymentIntentId
        };
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        return PartialView("PartialViews/Modals/GestionCommandesModals/_ConfirmerRefuserRetourPartial", vm);
    }

    public IActionResult ShowAccepterAnnulationConfirmation(string commandeId)
    {
        var commande = _context.Commandes.FirstOrDefault(c => c.Id == commandeId);
        var livresList = _context.LivreCommandes.Include(lc => lc.Livre).Where(lc => lc.CommandeId == commandeId)
            .ToList();

        var vm = new CancelVM
        {
            Commande = commande,
            Livres = livresList,
            PaymentIntent = commande.PaymentIntentId
        };

        return PartialView("PartialViews/Modals/GestionCommandesModals/_ConfirmerAccepterAnnulationPartial", vm);
    }

    public IActionResult ShowRefuserAnnulationConfirmation(string commandeId)
    {
        var commande = _context.Commandes.FirstOrDefault(c => c.Id == commandeId);
        var livresList = _context.LivreCommandes.Include(lc => lc.Livre).Where(lc => lc.CommandeId == commandeId)
            .ToList();

        var vm = new CancelVM
        {
            Commande = commande,
            Livres = livresList,
            PaymentIntent = commande.PaymentIntentId
        };

        return PartialView("PartialViews/Modals/GestionCommandesModals/_ConfirmerRefuserAnnulationPartial", vm);
    }

    [HttpPost]
    public StatusCodeResult AccepterDemandeRetour(string? commandeId, string? livreId)
    {
        var livreCommande =
            _context.LivreCommandes.FirstOrDefault(lc => lc.CommandeId == commandeId && lc.LivreId == livreId);

        var commande = _context.Commandes.FirstOrDefault(c => c.Id == livreCommande.CommandeId);
        var customer = _context.Membres.FirstOrDefault(m => m.Id == commande.MembreId);

        var quantite = livreCommande.QuantiteARetourner;
        if (quantite is not null)
        {
            livreCommande.Quantite -= (int)quantite;
            livreCommande.EnDemandeRetourner = false;
            livreCommande.QuantiteARetourner = null;
            _context.SaveChanges();
        }

        return Ok();
    }

    [HttpPost]
    public async Task<StatusCodeResult> AccepterDemandeAnnulation(string? commandeId)
    {
        var commande = _context.Commandes.FirstOrDefault(lc => lc.Id == commandeId);

        var lc = _context.LivreCommandes.Include(lc => lc.Livre).Where(lc => lc.CommandeId == commandeId);
        if (lc == null || commande == null) return BadRequest();

        var livresCommandes = lc.Select(lc => new LivreCommandeVM(lc)).ToList();

        // Récupérer l'URL complète du logo à partir de l'application
        var logoUrl =
            Url.Content(
                "http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");

        if (commande is not null)
        {
            var customer = _context.Membres.FirstOrDefault(m => m.Id == commande.MembreId);

            commande.StatutCommandeId = "5";

            commande.EnDemandeAnnulation = false;

            _context.SaveChanges();

            // Envoi du mail de confirmation de commande
#pragma warning disable CS8604 // Possible null reference argument.
            await SendConfirmationEmailAccepterAnnulation(customer, commandeId, livresCommandes, logoUrl);
#pragma warning restore CS8604 // Possible null reference argument.
        }

        return Ok();
    }

    [HttpPost]
    public StatusCodeResult RefuserDemandeRetour(string? commandeId, string? livreId)
    {
        var livreCommande =
            _context.LivreCommandes.FirstOrDefault(lc => lc.CommandeId == commandeId && lc.LivreId == livreId);

        if (livreCommande is not null)
        {
            livreCommande.EnDemandeRetourner = false;
            livreCommande.QuantiteARetourner = null;
            _context.SaveChanges();
        }

        return Ok();
    }

    [HttpPost]
    public StatusCodeResult RefuserDemandeAnnulation(string? commandeId)
    {
        var commande = _context.Commandes.FirstOrDefault(lc => lc.Id == commandeId);

        var lc = _context.LivreCommandes.Include(lc => lc.Livre).Where(lc => lc.CommandeId == commandeId);

        var livresCommandes = lc.Select(lc => new LivreCommandeVM(lc)).ToList();

        // Récupérer l'URL complète du logo à partir de l'application
        var logoUrl =
            Url.Content(
                "http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");
        if (commande is not null)
        {
            var customer = _context.Membres.FirstOrDefault(m => m.Id == commandeId);

            commande.EnDemandeAnnulation = false;
            _context.SaveChanges();

            SendConfirmationEmailRefuserAnnulation(customer, commandeId, livresCommandes, logoUrl);
        }

        return Ok();
    }

    //===================================================================
    //===================================================================
    //===================================================================

    private async Task SendConfirmationEmailAccepterAnnulation(Membre customer, string commandeId,
        List<LivreCommandeVM> livreCommande, string logoUrl)
    {
        var subject = "Retour de livres";

        // Construire le corps du courriel
        var body = BuildEmailBodyAccepterAnnulation(customer, commandeId, livreCommande, logoUrl);

        // Envoyer le courriel avec la facture en pièce jointe
        await _sendGridEmail.SendEmailAsync(customer.Email, subject, body);

        //Pouvoir envoyer un courriel à tous les employés
        //var employes = _context.Employes.ToList();
        //foreach (var employe in employes)
        //{
        //    await _sendGridEmail.SendEmailAsync(employe.Email, subject, body);
        //}
    }

    private async Task SendConfirmationEmailRefuserAnnulation(Membre customer, string commandeId,
        List<LivreCommandeVM> livreCommande, string logoUrl)
    {
        var subject = "Retour de livres";

        // Construire le corps du courriel
        var body = BuildEmailBodyRefuserAnnulation(customer, commandeId, livreCommande, logoUrl);

        // Envoyer le courriel avec la facture en pièce jointe
        await _sendGridEmail.SendEmailAsync(customer.Email, subject, body);

        //Pouvoir envoyer un courriel à tous les employés
        //var employes = _context.Employes.ToList();
        //foreach (var employe in employes)
        //{
        //    await _sendGridEmail.SendEmailAsync(employe.Email, subject, body);
        //}
    }

    private async Task SendConfirmationEmailAccepterRetour(Membre customer, LivreCommandeVM livreCommande,
        string logoUrl)
    {
        var subject = "Retour de livres";

        // Construire le corps du courriel
        var body = BuildEmailBodyAccepterRetour(customer, livreCommande, logoUrl);

        // Envoyer le courriel avec la facture en pièce jointe
        await _sendGridEmail.SendEmailAsync(customer.Email, subject, body);

        //Pouvoir envoyer un courriel à tous les employés
        //var employes = _context.Employes.ToList();
        //foreach (var employe in employes)
        //{
        //    await _sendGridEmail.SendEmailAsync(employe.Email, subject, body);
        //}
    }

    private async Task SendConfirmationEmailRefuserRetour(Membre customer, LivreCommandeVM livreCommande,
        string logoUrl)
    {
        var subject = "Retour de livres";

        // Construire le corps du courriel
        var body = BuildEmailBodyRefuserRetour(customer, livreCommande, logoUrl);

        // Envoyer le courriel avec la facture en pièce jointe
        await _sendGridEmail.SendEmailAsync(customer.Email, subject, body);

        //Pouvoir envoyer un courriel à tous les employés
        //var employes = _context.Employes.ToList();
        //foreach (var employe in employes)
        //{
        //    await _sendGridEmail.SendEmailAsync(employe.Email, subject, body);
        //}
    }

    //===================================================================
    //===================================================================
    //===================================================================

    private string BuildEmailBodyAccepterAnnulation(Membre customer, string commandeId,
        List<LivreCommandeVM> livreCommande, string logoUrl)
    {
        var body = new StringBuilder();

        body.Append(
            "<div style='font-family: \"Helvetica Neue\", Helvetica, Arial, sans-serif; max-width: 680px; margin: 20px auto; padding: 40px; border-radius: 8px; background-color: #ffffff; box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);'>");
        body.Append(
            $"<img src='{logoUrl}' alt='Logo' style='max-width: 200px; display: block; margin: 0 auto 20px;'>");
        body.Append(
            $"<h2 style='color: #333; text-align: center; margin-top: 0;'>Cher(e) {customer.UserName},</h2>");
        body.Append(
            $"<h2 style='color: #444;'>Votre demande d'annulation de la commande {commandeId} a été accepté!</h2>");
        body.Append("<h2 style='color: #444;'>Vous allez être rembourser pour la commande.</h2>");
        body.Append(
            "<p style='color: #555; font-size: 16px; text-align: center;'>Voici le récapitulatif :</p>");
        body.Append(
            "<hr style='border: 0; height: 1px; background-image: linear-gradient(to right, #146ec3, #146ec3, #fff); margin: 20px 0;'>");
        body.Append("<table style='width: 100%; margin-top: 30px; border-collapse: collapse;'>");
        body.Append("<thead>");
        body.Append("<tr style='background-color: #146ec3; color: #ffffff;'>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Produit</th>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Quantité</th>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Prix</th>");
        body.Append("</tr>");
        body.Append("</thead>");
        body.Append("<tbody>");

        foreach (var item in livreCommande)
        {
            body.Append("<tr>");
            body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{item.Livre}</td>");
            body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{item.Quantite}</td>");
            body.Append(
                $"<td style='padding: 15px; border: 1px solid #ddd;'>{item.PrixAchat:C}</td>");
            body.Append("</tr>");
        }

        body.Append("</tbody>");
        body.Append("</table>");
        double prixTotal = 0;
        foreach (var livcom in livreCommande) prixTotal += livcom.Quantite * livcom.PrixAchat;
        body.Append(
            $"<p style='color: #555; font-size: 16px;'><strong>Remboursement Total:</strong> {prixTotal:C}</p>");
        body.Append(
            "<p style='color: #555; font-size: 16px;'>Si vous avez des questions ou si vous avez besoin d'informations supplémentaires, veuillez ne pas hésiter à nous contacter.</p>");
        body.Append(
            "<p style='text-align: center; margin-top: 40px;'><a href='https://votresite.com' style='font-size: 18px; color: #146ec3; text-decoration: none;'><strong>Visitez notre site</strong></a></p>");
        body.Append("<footer style='text-align: center; color: #888; margin-top: 40px; font-size: 14px;'>");
        body.Append("<p>Merci de faire confiance à La Fourmi Aillée.</p>");
        body.Append("<p style='color: #146ec3;'>La Fourmi Aillée, 235 Rue Saint-Jacques, Granby, QC J2G 3N1</p>");
        body.Append("</div>");

        return body.ToString();
    }

    private string BuildEmailBodyRefuserAnnulation(Membre customer, string commandeId,
        List<LivreCommandeVM> livreCommande, string logoUrl)
    {
        var body = new StringBuilder();

        body.Append(
            "<div style='font-family: \"Helvetica Neue\", Helvetica, Arial, sans-serif; max-width: 680px; margin: 20px auto; padding: 40px; border-radius: 8px; background-color: #ffffff; box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);'>");
        body.Append(
            $"<img src='{logoUrl}' alt='Logo' style='max-width: 200px; display: block; margin: 0 auto 20px;'>");
        body.Append(
            $"<h2 style='color: #333; text-align: center; margin-top: 0;'>Cher(e) {customer.UserName},</h2>");
        body.Append(
            $"<h2 style='color: #444;'>Votre demande d'annulation de la commande {commandeId} a été refusé.</h2>");
        body.Append("<h2 style='color: #444;'>Désolé du malentendu...</h2>");
        body.Append(
            "<p style='color: #555; font-size: 16px; text-align: center;'>Voici le récapitulatif de la commande :</p>");
        body.Append(
            "<hr style='border: 0; height: 1px; background-image: linear-gradient(to right, #146ec3, #146ec3, #fff); margin: 20px 0;'>");
        body.Append("<table style='width: 100%; margin-top: 30px; border-collapse: collapse;'>");
        body.Append("<thead>");
        body.Append("<tr style='background-color: #146ec3; color: #ffffff;'>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Produit</th>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Quantité</th>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Prix</th>");
        body.Append("</tr>");
        body.Append("</thead>");
        body.Append("<tbody>");

        foreach (var item in livreCommande)
        {
            body.Append("<tr>");
            body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{item.Livre}</td>");
            body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{item.Quantite}</td>");
            body.Append(
                $"<td style='padding: 15px; border: 1px solid #ddd;'>{item.PrixAchat:C}</td>");
            body.Append("</tr>");
        }

        body.Append("</tbody>");
        body.Append("</table>");
        body.Append(
            "<p style='color: #555; font-size: 16px;'>Si vous avez des questions ou si vous avez besoin d'informations supplémentaires, veuillez ne pas hésiter à nous contacter.</p>");
        body.Append(
            "<p style='text-align: center; margin-top: 40px;'><a href='https://votresite.com' style='font-size: 18px; color: #146ec3; text-decoration: none;'><strong>Visitez notre site</strong></a></p>");
        body.Append("<footer style='text-align: center; color: #888; margin-top: 40px; font-size: 14px;'>");
        body.Append("<p>Merci de faire confiance à La Fourmi Aillée.</p>");
        body.Append("<p style='color: #146ec3;'>La Fourmi Aillée, 235 Rue Saint-Jacques, Granby, QC J2G 3N1</p>");
        body.Append("</div>");

        return body.ToString();
    }

    private string BuildEmailBodyAccepterRetour(Membre customer, LivreCommandeVM livreCommande, string logoUrl)
    {
        var myURL = _httpContextAccessor.HttpContext.Request.Host.Value; //_httpContextAccessor.Request.Host.Value;
        var BASE_URL_RAZOR = Url.Content("~");

        var body = new StringBuilder();

        body.Append(
            "<div style='font-family: \"Helvetica Neue\", Helvetica, Arial, sans-serif; max-width: 680px; margin: 20px auto; padding: 40px; border-radius: 8px; background-color: #ffffff; box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);'>");
        body.Append(
            $"<img src='{logoUrl}' alt='Logo' style='max-width: 200px; display: block; margin: 0 auto 20px;'>");
        body.Append(
            $"<h2 style='color: #333; text-align: center; margin-top: 0;'>Cher(e) {customer.UserName},</h2>");
        body.Append(
            $"<h2 style='color: #444;'>Votre demande d'annulation de la commande {livreCommande.CommandeId} a été accepté!</h2>");
        body.Append("<h2 style='color: #444;'>Vous allez être rembourser pour la commande.</h2>");
        body.Append(
            "<p style='color: #555; font-size: 16px; text-align: center;'>Voici le récapitulatif :</p>");
        body.Append(
            "<hr style='border: 0; height: 1px; background-image: linear-gradient(to right, #146ec3, #146ec3, #fff); margin: 20px 0;'>");
        body.Append("<table style='width: 100%; margin-top: 30px; border-collapse: collapse;'>");
        body.Append("<thead>");
        body.Append("<tr style='background-color: #146ec3; color: #ffffff;'>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Produit</th>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Quantité</th>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Prix</th>");
        body.Append("</tr>");
        body.Append("</thead>");
        body.Append("<tbody>");

        body.Append("<tr>");
        body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{livreCommande.Livre}</td>");
        body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{livreCommande.Quantite}</td>");
        body.Append(
            $"<td style='padding: 15px; border: 1px solid #ddd;'>{livreCommande.PrixAchat:C}</td>");
        body.Append("</tr>");


        body.Append("</tbody>");
        body.Append("</table>");
        double prixTotal = 0;
        prixTotal += livreCommande.Quantite * livreCommande.PrixAchat;

        body.Append(
            $"<p style='color: #555; font-size: 16px;'><strong>Remboursement Total:</strong> {prixTotal:C}</p>");
        body.Append(
            "<p style='color: #555; font-size: 16px;'>Si vous avez des questions ou si vous avez besoin d'informations supplémentaires, veuillez ne pas hésiter à nous contacter.</p>");
        body.Append(
            "<p style='text-align: center; margin-top: 40px;'><a href='https://votresite.com' style='font-size: 18px; color: #146ec3; text-decoration: none;'><strong>Visitez notre site</strong></a></p>");
        body.Append("<footer style='text-align: center; color: #888; margin-top: 40px; font-size: 14px;'>");
        body.Append("<p>Merci de faire confiance à La Fourmi Aillée.</p>");
        body.Append("<p style='color: #146ec3;'>La Fourmi Aillée, 235 Rue Saint-Jacques, Granby, QC J2G 3N1</p>");
        body.Append("</div>");

        return body.ToString();
    }

    private string BuildEmailBodyRefuserRetour(Membre customer, LivreCommandeVM livreCommande, string logoUrl)
    {
        var myURL = _httpContextAccessor.HttpContext.Request.Host.Value; //_httpContextAccessor.Request.Host.Value;
        var BASE_URL_RAZOR = Url.Content("~");

        var body = new StringBuilder();

        body.Append(
            "<div style='font-family: \"Helvetica Neue\", Helvetica, Arial, sans-serif; max-width: 680px; margin: 20px auto; padding: 40px; border-radius: 8px; background-color: #ffffff; box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);'>");
        body.Append(
            $"<img src='{logoUrl}' alt='Logo' style='max-width: 200px; display: block; margin: 0 auto 20px;'>");
        body.Append(
            $"<h2 style='color: #333; text-align: center; margin-top: 0;'>Cher(e) {customer.UserName},</h2>");
        body.Append(
            $"<h2 style='color: #444;'>Votre demande de retour de la commande {livreCommande.CommandeId} a été refusé.</h2>");
        body.Append("<h2 style='color: #444;'>Désolé du malentendu...</h2>");
        body.Append(
            "<p style='color: #555; font-size: 16px; text-align: center;'>Voici le récapitulatif du retour :</p>");
        body.Append(
            "<hr style='border: 0; height: 1px; background-image: linear-gradient(to right, #146ec3, #146ec3, #fff); margin: 20px 0;'>");
        body.Append("<table style='width: 100%; margin-top: 30px; border-collapse: collapse;'>");
        body.Append("<thead>");
        body.Append("<tr style='background-color: #146ec3; color: #ffffff;'>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Produit</th>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Quantité</th>");
        body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Prix</th>");
        body.Append("</tr>");
        body.Append("</thead>");
        body.Append("<tbody>");

        body.Append("<tr>");
        body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{livreCommande.Livre}</td>");
        body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{livreCommande.Quantite}</td>");
        body.Append(
            $"<td style='padding: 15px; border: 1px solid #ddd;'>{livreCommande.PrixAchat:C}</td>");
        body.Append("</tr>");


        body.Append("</tbody>");
        body.Append("</table>");
        body.Append(
            "<p style='color: #555; font-size: 16px;'>Si vous avez des questions ou si vous avez besoin d'informations supplémentaires, veuillez ne pas hésiter à nous contacter.</p>");
        body.Append(
            "<p style='text-align: center; margin-top: 40px;'><a href='https://votresite.com' style='font-size: 18px; color: #146ec3; text-decoration: none;'><strong>Visitez notre site</strong></a></p>");
        body.Append("<footer style='text-align: center; color: #888; margin-top: 40px; font-size: 14px;'>");
        body.Append("<p>Merci de faire confiance à La Fourmi Aillée.</p>");
        body.Append("<p style='color: #146ec3;'>La Fourmi Aillée, 235 Rue Saint-Jacques, Granby, QC J2G 3N1</p>");
        body.Append("</div>");

        return body.ToString();
    }
}