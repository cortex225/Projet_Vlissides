using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text;
using VLISSIDES.Data;
using VLISSIDES.Interfaces;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionCommandes;
using VLISSIDES.ViewModels.HistoriqueCommandes;

namespace VLISSIDES.Controllers
{
    [Authorize(Roles = RoleName.EMPLOYE + ", " + RoleName.ADMIN)]
    public class GestionCommandesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISendGridEmail _sendGridEmail;

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
        public IActionResult Index(string? motCles, string? criteres)
        {
            var commandes = _context.Commandes
                .Include(c => c.StatutCommande)
                .Include(c => c.Membre);
            var livreCommandes = _context.LivreCommandes;

            var livreCommandeVM = livreCommandes.Select(lc => new LivreCommandeVM
            {
                Livre = lc.Livre,
                CommandeId = lc.CommandeId,
                Quantite = lc.Quantite,
                PrixAchat = lc.PrixAchat,
                EnDemandeRetourner = lc.EnDemandeRetourner
            }).ToList();

            var listeCommandeVM = commandes.AsEnumerable().Select(c => new CommandesVM
            {
                Id = c.Id.ToString(),
                DateCommande = c.DateCommande,
                PrixTotal = c.PrixTotal,
                MembreUserName = c.Membre.UserName,
                AdresseId = c.AdresseId,
                LivreCommandes = livreCommandeVM.Where(lc => lc.CommandeId == c.Id).ToList(),
                StatutId = c.StatutCommande.Id,
                StatutNom = c.StatutCommande.Nom,
                EnDemandeAnnulation = c.EnDemandeAnnulation
            }).OrderBy(c => c.DateCommande).ToList();

            var affichageCommandes = new AffichageCommandeVM
            {
                ListCommandes = listeCommandeVM
            };

            affichageCommandes.SelectListStatut = _context.StatutCommandes.Select(s => new SelectListItem
            {
                Text = s.Nom,
                Value = s.Id
            }).ToList();

            return View(affichageCommandes);
        }

        public IActionResult AfficherCommandes(string? motCles, string? criteres)
        {
            var listCriteresValue = new List<string>();
            if (motCles != null) listCriteresValue = motCles.Split('|').ToList();

            var listCriteres = new List<string>();
            if (criteres != null) listCriteres = criteres.Split('|').ToList();

            //var currentUserId = _userManager.GetUserId(HttpContext.User);
            var commandes = _context.Commandes
                .Include(c => c.StatutCommande)
                .Include(c => c.Membre);
            var livreCommandes = _context.LivreCommandes;

            var livreCommandeVM = livreCommandes.Select(lc => new LivreCommandeVM
            {
                Livre = lc.Livre,
                CommandeId = lc.CommandeId,
                Quantite = lc.Quantite,
                PrixAchat = lc.PrixAchat,
                EnDemandeRetourner = lc.EnDemandeRetourner
            }).ToList();

            var listeCommandeVM = commandes.AsEnumerable().Select(c => new CommandesVM
            {
                Id = c.Id.ToString(),
                DateCommande = c.DateCommande,
                PrixTotal = c.PrixTotal,
                MembreUserName = c.Membre.UserName,
                AdresseId = c.AdresseId,
                LivreCommandes = livreCommandeVM.Where(lc => lc.CommandeId == c.Id).ToList(),
                StatutId = c.StatutCommande.Id,
                StatutNom = c.StatutCommande.Nom,
                EnDemandeAnnulation = c.EnDemandeAnnulation
            }).OrderByDescending(c => c.DateCommande).ToList();

            if (listCriteres.Any(c => c == "rechercherCommande"))
            {
                if (listCriteresValue[3] != "")
                    listeCommandeVM = listeCommandeVM.Where(c => c.Id == listCriteresValue[2]).ToList();
            }

            if (listCriteres.Any(c => c == "trierDate"))
            {
                if (listCriteresValue[0] == "2")
                {
                    listeCommandeVM = listeCommandeVM.OrderBy(c => c.DateCommande).ToList();
                }
                else
                {
                    listeCommandeVM = listeCommandeVM.OrderByDescending(c => c.DateCommande).ToList();
                }
            }

            if (listCriteres.Any(c => c == "filtrerStatut"))
            {
                if (listCriteresValue[1] != "0")
                {
                    listeCommandeVM = listeCommandeVM.Where(c => c.StatutId == listCriteresValue[1].ToString()).ToList();
                }
            }

            if (listCriteres.Any(c => c == "demandeRemboursement"))
            {
                if (listCriteresValue[2] == "2")
                {
                    listeCommandeVM = listeCommandeVM.Where(c => c.EnDemandeAnnulation == true).ToList();
                }
                if (listCriteresValue[2] == "3")
                {
                    listeCommandeVM = listeCommandeVM.Where(c => c.LivreCommandes.Any(lc => lc.EnDemandeRetourner == true)).ToList();
                }
            }

            var affichageCommandes = new AffichageCommandeVM
            {
                ListCommandes = listeCommandeVM
            };

            affichageCommandes.SelectListStatut = _context.StatutCommandes.Select(s => new SelectListItem
            {
                Text = s.Nom,
                Value = s.Id
            }).ToList();

            return PartialView("PartialViews/GestionCommandes/_ListeCommandesPartial", affichageCommandes);
        }

        [HttpPost]
        public async Task<IActionResult> ModifierStatut(string id, string statut)
        {
            var commande = await _context.Commandes.FindAsync(id);
            if (commande == null) return BadRequest();
            commande.StatutCommandeId = statut;
            await _context.SaveChangesAsync();
            return Ok();
        }

        public async Task<IActionResult> ShowAccepterRetourConfirmation(string commandeId, string livreId)
        {
            var livreCommande = await _context.LivreCommandes.Include(lc => lc.Livre).Include(lc => lc.Commande).FirstOrDefaultAsync(lc => lc.CommandeId == commandeId && lc.LivreId == livreId);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var vm = new StripeRefundVM
            {
                Commande = livreCommande.Commande,
                Livre = livreCommande.Livre,
                Prix = livreCommande.PrixAchat,
                Quantite = 0 //Valeur non nécessaire(À voir si on l'utilise ou pas)
            };
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            return PartialView("PartialViews/Modals/GestionCommandesModals/_ConfirmerAccepterRetourPartial", vm);
        }

        public async Task<IActionResult> ShowRefuserRetourConfirmation(string commandeId, string livreId)
        {
            var livreCommande = await _context.LivreCommandes.Include(lc => lc.Livre).Include(lc => lc.Commande).FirstOrDefaultAsync(lc => lc.CommandeId == commandeId && lc.LivreId == livreId);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var vm = new StripeRefundVM
            {
                Commande = livreCommande.Commande,
                Livre = livreCommande.Livre,
                Prix = livreCommande.PrixAchat,
                Quantite = 0 //Valeur non nécessaire(À voir si on l'utilise ou pas)
            };
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            return PartialView("PartialViews/Modals/GestionCommandesModals/_ConfirmerRefuserRetourPartial", vm);
        }

        public IActionResult ShowAccepterAnnulationConfirmation(string commandeId)
        {
            var livresList = _context.LivreCommandes.Include(lc => lc.Livre).Where(lc => lc.CommandeId == commandeId).ToList();

            var vm = new StripeCancelVM
            {
                Id = commandeId,
                Livres = livresList,
            };

            return PartialView("PartialViews/Modals/GestionCommandesModals/_ConfirmerAccepterAnnulationPartial", vm);
        }

        public IActionResult ShowRefuserAnnulationConfirmation(string commandeId)
        {
            var livresList = _context.LivreCommandes.Include(lc => lc.Livre).Where(lc => lc.CommandeId == commandeId).ToList();

            var vm = new StripeCancelVM
            {
                Id = commandeId,
                Livres = livresList,
            };

            return PartialView("PartialViews/Modals/GestionCommandesModals/_ConfirmerRefuserAnnulationPartial", vm);
        }

        [HttpPost]
        public IActionResult AccepterDemandeRetour(string? commandeId, string? livreId, string? quantite)
        {
            LivreCommande? livreCommande = _context.LivreCommandes.FirstOrDefault(lc => lc.CommandeId == commandeId && lc.LivreId == livreId);

            int quantiteInt;
            if (int.TryParse(quantite, out quantiteInt) && livreCommande is not null)
            {
                livreCommande.Quantite -= quantiteInt;
                livreCommande.EnDemandeRetourner = false;
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AccepterDemandeAnnulation(string? commandeId)
        {
            Commande? commande = _context.Commandes.FirstOrDefault(lc => lc.Id == commandeId);

            var lc = _context.LivreCommandes.Include(lc => lc.Livre).Where(lc => lc.CommandeId == commandeId);
            if (lc == null || commande == null) return BadRequest();

            var livresCommandes = lc.Select(lc => new LivreCommandeVM
            {
                Livre = lc.Livre,
                CommandeId = lc.CommandeId,
                Quantite = lc.Quantite,
                PrixAchat = lc.PrixAchat,
                EnDemandeRetourner = lc.EnDemandeRetourner
            }).ToList();

            // Récupérer l'URL complète du logo à partir de l'application
            var logoUrl =
                Url.Content(
                    "http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");

            if (commande is not null)
            {
                Membre? customer = _context.Membres.FirstOrDefault(m => m.Id == commande.MembreId);

                commande.StatutCommandeId = "5";

                commande.EnDemandeAnnulation = false;

                _context.SaveChanges();

                // Envoi du mail de confirmation de commande
#pragma warning disable CS8604 // Possible null reference argument.
                await SendConfirmationEmailAccepterAnnulation(customer, commandeId, livresCommandes, logoUrl);
#pragma warning restore CS8604 // Possible null reference argument.
            }

            return View();
        }

        [HttpPost]
        public IActionResult RefuserDemandeRetour(string? commandeId, string? livreId, string? quantite)
        {
            LivreCommande? livreCommande = _context.LivreCommandes.FirstOrDefault(lc => lc.CommandeId == commandeId && lc.LivreId == livreId);

            if (livreCommande is not null)
            {
                livreCommande.EnDemandeRetourner = false;
                _context.SaveChanges();
            }

            return View();
        }

        [HttpPost]
        public IActionResult RefuserDemandeAnnulation(string? commandeId)
        {
            Commande? commande = _context.Commandes.FirstOrDefault(lc => lc.Id == commandeId);

            var lc = _context.LivreCommandes.Include(lc => lc.Livre).Where(lc => lc.CommandeId == commandeId);

            var livresCommandes = lc.Select(lc => new LivreCommandeVM
            {
                Livre = lc.Livre,
                CommandeId = lc.CommandeId,
                Quantite = lc.Quantite,
                PrixAchat = lc.PrixAchat,
                EnDemandeRetourner = lc.EnDemandeRetourner
            }).ToList();

            // Récupérer l'URL complète du logo à partir de l'application
            var logoUrl =
                Url.Content(
                    "http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");
            if (commande is not null)
            {
                Membre? customer = _context.Membres.FirstOrDefault(m => m.Id == commandeId);

                commande.EnDemandeAnnulation = false;
                _context.SaveChanges();

                SendConfirmationEmailRefuserAnnulation(customer, commandeId, livresCommandes, logoUrl);
            }

            return View();
        }

        private async Task SendConfirmationEmailAccepterAnnulation(Membre customer, string commandeId, List<LivreCommandeVM> livreCommande, string logoUrl)
        {
            var subject = "Retour de livres";

            // Construire le corps du courriel
            var body = SendConfirmationEmailRefuserAnnulation(customer, commandeId, livreCommande, logoUrl);

            // Envoyer le courriel avec la facture en pièce jointe
            await _sendGridEmail.SendEmailAsync(customer.Email, subject, body);

            //Pouvoir envoyer un courriel à tous les employés
            //var employes = _context.Employes.ToList();
            //foreach (var employe in employes)
            //{
            //    await _sendGridEmail.SendEmailAsync(employe.Email, subject, body);
            //}
        }

        private async Task SendConfirmationEmailRefuserAnnulation(Membre customer, string commandeId, List<LivreCommandeVM> livreCommande, string logoUrl)
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

        private string BuildEmailBodyAccepterAnnulation(Membre customer, string commandeId, List<LivreCommandeVM> livreCommande, string logoUrl)
        {
            var body = new StringBuilder();

            body.Append(
                "<div style='font-family: \"Helvetica Neue\", Helvetica, Arial, sans-serif; max-width: 680px; margin: 20px auto; padding: 40px; border-radius: 8px; background-color: #ffffff; box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);'>");
            body.Append(
                $"<img src='{logoUrl}' alt='Logo' style='max-width: 200px; display: block; margin: 0 auto 20px;'>");
            body.Append(
                $"<h2 style='color: #333; text-align: center; margin-top: 0;'>Cher(e) {customer.UserName},</h2>");
            body.Append($"<h2 style='color: #444;'>Votre demande d'annulation de la commande {commandeId} à été accepté!</h2>");
            body.Append($"<h2 style='color: #444;'>Vous allez être rembourser pour la commande.</h2>");
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
                body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{item.Livre.Titre}</td>");
                body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{item.Quantite}</td>");
                body.Append(
                    $"<td style='padding: 15px; border: 1px solid #ddd;'>{item.Livre.LivreTypeLivres.FirstOrDefault()?.Prix:C}</td>");
                body.Append("</tr>");
            }

            body.Append("</tbody>");
            body.Append("</table>");
            double prixTotal = 0;
            foreach (var livcom in livreCommande)
            {
                prixTotal += (livcom.Quantite * livcom.PrixAchat);
            }
            body.Append($"<p style='color: #555; font-size: 16px;'><strong>Prix Total:</strong> {prixTotal:C}</p>");
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

        private string BuildEmailBodyRefuserAnnulation(Membre customer, string commandeId, List<LivreCommandeVM> livreCommande, string logoUrl)
        {
            var body = new StringBuilder();

            body.Append(
                "<div style='font-family: \"Helvetica Neue\", Helvetica, Arial, sans-serif; max-width: 680px; margin: 20px auto; padding: 40px; border-radius: 8px; background-color: #ffffff; box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);'>");
            body.Append(
                $"<img src='{logoUrl}' alt='Logo' style='max-width: 200px; display: block; margin: 0 auto 20px;'>");
            body.Append(
                $"<h2 style='color: #333; text-align: center; margin-top: 0;'>Cher(e) {customer.UserName},</h2>");
            body.Append($"<h2 style='color: #444;'>Votre demande d'annulation de la commande {commandeId} à été accepté!</h2>");
            body.Append($"<h2 style='color: #444;'>Vous allez être rembourser pour la commande.</h2>");
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
                body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{item.Livre.Titre}</td>");
                body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{item.Quantite}</td>");
                body.Append(
                    $"<td style='padding: 15px; border: 1px solid #ddd;'>{item.Livre.LivreTypeLivres.FirstOrDefault()?.Prix:C}</td>");
                body.Append("</tr>");
            }

            body.Append("</tbody>");
            body.Append("</table>");
            double prixTotal = 0;
            foreach (var livcom in livreCommande)
            {
                prixTotal += (livcom.Quantite * livcom.PrixAchat);
            }
            body.Append($"<p style='color: #555; font-size: 16px;'><strong>Prix Total:</strong> {prixTotal:C}</p>");
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
}
