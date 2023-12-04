using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using VLISSIDES.Data;
using VLISSIDES.Interfaces;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionEvenements;

namespace VLISSIDES.Controllers
{
    [Authorize(Roles = RoleName.EMPLOYE + ", " + RoleName.ADMIN)]
    public class GestionEvenementsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ISendGridEmail _sendGridEmail;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GestionEvenementsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
        IConfiguration config, ISendGridEmail sendGridEmail, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
            _sendGridEmail = sendGridEmail;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            //Supprimer automatiquement les evenements trop vieux
            _context.Evenements.RemoveRange(_context.Evenements.Include(e => e.Reservations).Where(e => e.DateFin
            .AddDays(7) < DateTime.Now));
            _context.SaveChanges();
            //La liste à afficher
            return View(_context.Evenements.Select(e => new GestionEvenementsIndexVM(e)).ToList());
        }
        public IActionResult AfficherEvenements() => PartialView("PartialViews/GestionEvenements/_ListeEvenementsPartial",
                _context.Evenements.Select(e => new GestionEvenementsIndexVM(e)).ToList());
        public IActionResult AfficherReservations() => PartialView("PartialViews/GestionEvenements/_ListeReservationsPartial"
            , _context.Reservations.Include(r => r.Evenement).Include(r => r.Membre)
            .Select(r => new GestionEvenementsReservationVM(r)).ToList());
        public IActionResult AjouterEvenement() => PartialView("PartialViews/Modals/Evenements/_AjouterEvenementsPartial",
            new GestionEvenementsAjouterVM());
        [HttpPost]
        public async Task<IActionResult> AjouterEvenement(GestionEvenementsAjouterVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.DateDebut < DateTime.Now)
                {
                    ModelState.AddModelError("DateDebut", "La date de début est invalide");
                    return PartialView("PartialViews/Modals/Evenements/_AjouterEvenementsPartial", vm);
                }
                if (vm.DateFin < vm.DateDebut)
                {
                    ModelState.AddModelError("DateFin", "La date de fin est invalide");
                    return PartialView("PartialViews/Modals/Evenements/_AjouterEvenementsPartial", vm);
                }
                var evenement = new Evenement()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nom = vm.Nom,
                    Description = vm.Description,
                    DateDebut = vm.DateDebut,
                    DateFin = vm.DateFin,
                    Image = vm.Image,
                    Lieu = vm.Lieu,
                    NbPlaces = vm.NbPlaces,
                    NbPlacesMembre = vm.NbPlacesMembre,
                    Prix = vm.Prix,

                };
                if (vm.CoverPhoto != null)
                {
                    var wwwRootPath = _webHostEnvironment.WebRootPath;
                    var fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
                    var extension = Path.GetExtension(vm.CoverPhoto.FileName);
                    fileName += DateTime.Now.ToString("yyyymmssfff") + extension;
                    vm.Image = _config.GetValue<string>("ImageUrl") + fileName;
                    var path = Path.Combine(wwwRootPath + _config.GetValue<string>("ImageUrl"), fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await vm.CoverPhoto.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    vm.Image = "/img/CouvertureLivre/livredefault.png";
                }
                evenement.Image = vm.Image;
                _context.Evenements.Add(evenement);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return PartialView("PartialViews/Modals/Evenements/_AjouterEvenementsPartial", vm);
        }

        public async Task<IActionResult> ModifierEvenement(string id)
        {
            var evenement = await _context.Evenements.FindAsync(id);
            if (evenement == null) return NotFound("L'évènement à l'identifiant " + id + " n'a pas été trouvé.");
            return PartialView("PartialViews/Modals/Evenements/_ModifierEvenementsPartial",
                    new GestionEvenementsModifierVM(evenement));

        }
        [HttpPost]
        public async Task<IActionResult> ModifierEvenement(GestionEvenementsModifierVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.DateDebut < DateTime.Now)
                {
                    ModelState.AddModelError("DateDebut", "La date de début est invalide");
                    return PartialView("PartialViews/Modals/Evenements/_ModifierEvenementsPartial", vm);
                }
                if (vm.DateFin < vm.DateDebut)
                {
                    ModelState.AddModelError("DateFin", "La date de fin est invalide");
                    return PartialView("PartialViews/Modals/Evenements/_ModifierEvenementsPartial", vm);
                }
                var evenement = _context.Evenements.FirstOrDefault(e => e.Id == vm.Id);
                if (evenement != null)
                {
                    //Modifications
                    evenement.Nom = vm.Nom;
                    evenement.Description = vm.Description;
                    evenement.DateDebut = vm.DateDebut;
                    evenement.DateFin = vm.DateFin;
                    evenement.Lieu = vm.Lieu;
                    evenement.NbPlaces = vm.NbPlaces;
                    evenement.NbPlacesMembre = vm.NbPlacesMembre;
                    evenement.Prix = vm.Prix;

                    if (vm.CoverPhoto != null)
                    {
                        var wwwRootPath = _webHostEnvironment.WebRootPath;
                        var fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
                        var extension = Path.GetExtension(vm.CoverPhoto.FileName);
                        fileName += DateTime.Now.ToString("yyyymmssfff") + extension;
                        vm.Image = _config.GetValue<string>("ImageUrl") + fileName;
                        var path = Path.Combine(wwwRootPath + _config.GetValue<string>("ImageUrl"), fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await vm.CoverPhoto.CopyToAsync(fileStream);
                        }
                        evenement.Image = vm.Image;
                    }

                    //Sauvegarder
                    await _context.SaveChangesAsync();
                    return Ok();
                }


            }
            return PartialView("PartialViews/Modals/Evenements/_ModifierEvenementsPartial", vm);
        }
        public async Task<IActionResult> ShowSupprimerEvenement(string id)
        {
            var evenement = await _context.Evenements.FindAsync(id);
            if (evenement == null) return NotFound("L'évènement à l'identifiant " + id + " n'a pas été trouvé.");
            return PartialView("PartialViews/Modals/Evenements/_SupprimerEvenementPartial",
                new GestionEvenementSupprimerVM(evenement));
        }

        public async Task<IActionResult> ShowConfirmerDemande(string id)
        {
            var reservation = await _context.Reservations.SingleOrDefaultAsync(e => e.Id == id);
            if (reservation == null) return NotFound("L'évènement à l'identifiant " + id + " n'a pas été trouvé.");
            return PartialView("PartialViews/Modals/Evenements/_ConfirmerReservationPartial",
                new GestionEvenementsReservationVM(_context.Reservations.Include(r => r.Evenement)
                    .Include(r => r.Membre)
                    .FirstOrDefault(r => r.Id == id)));
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmerDemande(string id)
        {
            if (_context.Reservations.FindAsync(id) == null) return NotFound("La réservation à l'identifiant " + id
                + " n'a pas été trouvé.");

            var reservation = _context.Reservations.Include(r => r.Evenement).Include(r => r.Membre)
                .First(r => r.Id == id);
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            //Logo fourmi ailé
            var logoUrl = Url.Content("http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");
            //Nom utilisateur du membre
            var username = reservation.Membre.UserName;
            await SendConfirmationEmailMembreConfirmed(username, reservation, logoUrl);
            return Ok();
        }
        public async Task<IActionResult> ShowAnnulerDemande(string id)
        {
            if (await _context.Evenements.FindAsync(id) == null) return NotFound("L'évènement à l'identifiant " + id + " n'a pas été trouvé.");

            return PartialView("PartialViews/Modals/Evenements/_AnnulerReservationPartial",
                new GestionEvenementsReservationVM(_context.Reservations.Include(r => r.Evenement).Include(r => r.Membre)
                    .FirstOrDefault(r => r.Id == id)));
        }
        [HttpPost]
        public async Task<IActionResult> AnnulerDemande(string id)
        {
            if (_context.Reservations.FindAsync(id) == null) return NotFound("L'évènement à l'identifiant " + id
                + " n'a pas été trouvé.");

            var reservation = _context.Reservations.Include(r => r.Evenement).Include(r => r.Membre)
                .FirstOrDefault(r => r.Id == id);

            reservation.EnDemandeAnnuler = false;
            _context.SaveChanges();
            //Logo fourmi ailé
            var logoUrl = Url.Content("http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");
            //Nom utilisateur du membre
            var username = reservation.Membre.UserName;
            await SendConfirmationEmailMembreCancelled(username, reservation, logoUrl);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> SupprimerEvenement(string id)
        {
            var evenement = await _context.Evenements.FindAsync(id);
            if (evenement == null) return NotFound("L'évènement à l'identifiant " + id + " n'a pas été trouvé.");

            _context.Evenements.Remove(evenement);
            _context.SaveChanges();
            return Ok();
        }
        private async Task SendConfirmationEmailMembreConfirmed(string? username, Reservation reservation, string logoUrl)
        {
            var subject = "Demande d'annulation de réservation";

            // Construire le corps du courriel
            var body = BuildConfirmationEmailMembreConfirmedBody(username, reservation, logoUrl);

            var emailAddress = _context.Users.FirstOrDefault(u => u.Id == reservation.MembreId).Email;
            // Envoyer le courriel avec la facture en pièce jointe
            await _sendGridEmail.SendEmailAsync(emailAddress, subject, body);
        }
        private string BuildConfirmationEmailMembreConfirmedBody(string username, Reservation reservation, string logoUrl)
        {
            var body = new StringBuilder();

            string myURL = _httpContextAccessor.HttpContext.Request.Host.Value;//_httpContextAccessor.Request.Host.Value;            string BASE_URL_RAZOR = Url.Content("~"); 


            body.Append("<div style='font-family: \"Helvetica Neue\", Helvetica, Arial, sans-serif; max-width: 680px; margin: 20px auto; padding: 40px; border-radius: 8px; background-color: #ffffff; box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);'>");
            body.Append($"<img src='{logoUrl}' alt='Logo' style='max-width: 200px; display: block; margin: 0 auto 20px;'>");
            body.Append($"<h2 style='color: #333; text-align: center; margin-top: 0;'>Cher(e) {username},</h2>");
            body.Append($"<h2 style='color: #444;'>Votre demande d'annulation de la commande {reservation.Id} a été accepté!</h2>");
            body.Append($"<h2 style='color: #444;'>Vous allez être rembourser pour la commande.</h2>");
            body.Append("<p style='color: #555; font-size: 16px; text-align: center;'>Voici le récapitulatif :</p>");
            body.Append("<hr style='border: 0; height: 1px; background-image: linear-gradient(to right, #146ec3, #146ec3, #fff); margin: 20px 0;'>");
            body.Append("<table style='width: 100%; margin-top: 30px; border-collapse: collapse;'>");
            body.Append("<thead>");
            body.Append("<tr style='background-color: #146ec3; color: #ffffff;'>");
            body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Evenement</th>");

            body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Prix</th>");
            body.Append("</tr>");
            body.Append("</thead>");
            body.Append("<tbody>");
            body.Append("<tr>");
            body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{reservation.Evenement.Nom}</td>");

            body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{reservation.prixAchat}</td>");
            body.Append("</tr>");
            body.Append("</tbody>");
            body.Append("</table>");

            body.Append($"<p style='color: #555; font-size: 16px;'><strong>Remboursement Total:</strong> {reservation.prixAchat}</p>");
            body.Append("<p style='color: #555; font-size: 16px;'>Si vous avez des questions ou si vous avez besoin d'informations supplémentaires, veuillez ne pas hésiter à nous contacter.</p>");
            body.Append("<p style='text-align: center; margin-top: 40px;'><a href='https://sqlinfocg.cegepgranby.qc.ca/2147186' style='font-size: 18px; color: #146ec3; text-decoration: none;'><strong>Visitez notre site</strong></a></p>");
            body.Append("<footer style='text-align: center; color: #888; margin-top: 40px; font-size: 14px;'>");
            body.Append("<p>Merci de faire confiance à La Fourmi Aillée.</p>");
            body.Append("<p style='color: #146ec3;'>La Fourmi Aillée, 235 Rue Saint-Jacques, Granby, QC J2G 3N1</p>");
            body.Append("</div>");

            return body.ToString();

        }
        private async Task SendConfirmationEmailMembreCancelled(string? username, Reservation reservation, string logoUrl)
        {
            var subject = "Demande d'annulation de reservation";

            // Construire le corps du courriel
            var body = BuildConfirmationEmailMembreCancelledBody(username, reservation, logoUrl);

            var emailAddress = _context.Users.FirstOrDefault(u => u.Id == reservation.MembreId).Email;
            // Envoyer le courriel avec la facture en pièce jointe
            await _sendGridEmail.SendEmailAsync(emailAddress, subject, body);
        }
        private string BuildConfirmationEmailMembreCancelledBody(string username, Reservation reservation, string logoUrl)
        {
            var body = new StringBuilder();

            string myURL = _httpContextAccessor.HttpContext.Request.Host.Value;//_httpContextAccessor.Request.Host.Value;            string BASE_URL_RAZOR = Url.Content("~"); 


            body.Append("<div style='font-family: \"Helvetica Neue\", Helvetica, Arial, sans-serif; max-width: 680px; margin: 20px auto; padding: 40px; border-radius: 8px; background-color: #ffffff; box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);'>");
            body.Append($"<img src='{logoUrl}' alt='Logo' style='max-width: 200px; display: block; margin: 0 auto 20px;'>");
            body.Append($"<h2 style='color: #333; text-align: center; margin-top: 0;'>Cher(e) {username},</h2>");
            body.Append($"<h2 style='color: #444;'>Votre demande d'annulation de la commande {reservation.Id} a été refusé.</h2>");
            body.Append($"<h2 style='color: #444;'>Désolé du malentendu...</h2>");
            body.Append("<p style='color: #555; font-size: 16px; text-align: center;'>Voici le récapitulatif :</p>");
            body.Append("<hr style='border: 0; height: 1px; background-image: linear-gradient(to right, #146ec3, #146ec3, #fff); margin: 20px 0;'>");
            body.Append("<table style='width: 100%; margin-top: 30px; border-collapse: collapse;'>");
            body.Append("<thead>");
            body.Append("<tr style='background-color: #146ec3; color: #ffffff;'>");
            body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Evenement</th>");

            body.Append("<th style='padding: 15px; border: 1px solid #146ec3;'>Prix</th>");
            body.Append("</tr>");
            body.Append("</thead>");
            body.Append("<tbody>");
            body.Append("<tr>");
            body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{reservation.Evenement.Nom}</td>");

            body.Append($"<td style='padding: 15px; border: 1px solid #ddd;'>{reservation.prixAchat}</td>");
            body.Append("</tr>");
            body.Append("</tbody>");
            body.Append("</table>");

            body.Append("<p style='color: #555; font-size: 16px;'>Si vous avez des questions ou si vous avez besoin d'informations supplémentaires, veuillez ne pas hésiter à nous contacter.</p>");
            body.Append("<p style='text-align: center; margin-top: 40px;'><a href='https://sqlinfocg.cegepgranby.qc.ca/2147186' style='font-size: 18px; color: #146ec3; text-decoration: none;'><strong>Visitez notre site</strong></a></p>");
            body.Append("<footer style='text-align: center; color: #888; margin-top: 40px; font-size: 14px;'>");
            body.Append("<p>Merci de faire confiance à La Fourmi Aillée.</p>");
            body.Append("<p style='color: #146ec3;'>La Fourmi Aillée, 235 Rue Saint-Jacques, Granby, QC J2G 3N1</p>");
            body.Append("</div>");


            return body.ToString();

        }
    }
}
