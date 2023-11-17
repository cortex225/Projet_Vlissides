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
            var evenementsSupprime = _context.Evenements.Include(e => e.Reservations).Where(e => e.DateFin.AddDays(7) < DateTime.Now);
            _context.Evenements.RemoveRange(evenementsSupprime);
            _context.SaveChanges();
            //La liste à afficher
            var evenements = _context.Evenements.Select(e => new GestionEvenementsIndexVM
            {
                Id = e.Id,
                Nom = e.Nom,
                Description = e.Description,
                DateDebut = e.DateDebut,
                DateFin = e.DateFin,
                Image = e.Image,
                Lieu = e.Lieu,
                NbPlaces = e.NbPlaces,
                NbPlacesMembre = e.NbPlacesMembre,
                NbPlacesMembreReserve = e.Reservations.Count(),
                Prix = e.Prix,
            }).ToList();
            return View(evenements);
        }
        public IActionResult AfficherEvenements()
        {
            var evenements = _context.Evenements.Select(e => new GestionEvenementsIndexVM
            {
                Id = e.Id,
                Nom = e.Nom,
                Description = e.Description,
                DateDebut = e.DateDebut,
                DateFin = e.DateFin,
                Image = e.Image,
                Lieu = e.Lieu,
                NbPlaces = e.NbPlaces,
                NbPlacesMembre = e.NbPlacesMembre,
                Prix = e.Prix,
            }).ToList();
            return PartialView("PartialViews/GestionEvenements/_ListeEvenementsPartial", evenements);
        }
        public IActionResult AfficherReservations()
        {
            var reservations = _context.Reservations.Include(r => r.Evenement).Include(r => r.Membre).Where(r => r.EnDemandeAnnuler == true).Select(r => new GestionEvenementsReservationVM
            {
                Id = r.Id,
                NomEvenement = r.Evenement.Nom,
                NomUtilisateur = r.Membre.UserName
            }).ToList();
            return PartialView("PartialViews/GestionEvenements/_ListeReservationsPartial", reservations);
        }
        public IActionResult AjouterEvenement()
        {
            var vm = new GestionEvenementsAjouterVM()
            {
                DateDebut = DateTime.Now,
                DateFin = DateTime.Now,
            };
            return PartialView("PartialViews/Modals/Evenements/_AjouterEvenementsPartial", vm);
        }
        [HttpPost]
        public async Task<IActionResult> AjouterEvenement(GestionEvenementsAjouterVM vm)
        {
            decimal prix = 0;
            if (vm.Prix != null)
            {
                if (!decimal.TryParse(vm.Prix, out prix))
                {
                    ModelState.AddModelError("Prix", "Le prix est invalide");
                }
            }


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
                    Prix = prix,

                };
                //if (vm.CoverPhoto != null)
                //{
                //    var wwwRootPath = _webHostEnvironment.WebRootPath;
                //    var fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
                //    var extension = Path.GetExtension(vm.CoverPhoto.FileName);
                //    fileName = fileName + "_" + Guid.NewGuid().ToString() +
                //               extension; // Utilisation de Guid pour un nom de fichier unique
                //    var folderPath =
                //        Path.Combine(wwwRootPath, _config.GetValue<string>("ImageUrl")); // Chemin du dossier où l'image sera sauvegardée
                //    var fullPath = Path.Combine(folderPath, fileName); // Chemin complet du fichier

                //    // Sauvegarder l'image
                //    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                //    {
                //        await vm.CoverPhoto.CopyToAsync(fileStream);
                //    }

                //    evenement.Image =
                //        "/img/EvenementImages/" + fileName;
                //}
                //else
                //{
                //    evenement.Image = "/img/Couvertures/livredefault.png";
                //}
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

        public IActionResult ModifierEvenement(string id)
        {
            var evenement = _context.Evenements.FirstOrDefault(e => e.Id == id);
            var vm = new GestionEvenementsModifierVM()
            {
                Id = id,
                Nom = evenement.Nom,
                Description = evenement.Description,
                DateDebut = evenement.DateDebut,
                DateFin = evenement.DateFin,
                Image = evenement.Image,
                Lieu = evenement.Lieu,
                NbPlaces = evenement.NbPlaces,
                NbPlacesMembre = evenement.NbPlacesMembre,
                Prix = evenement.Prix.ToString(),
            };
            return PartialView("PartialViews/Modals/Evenements/_ModifierEvenementsPartial", vm);
        }
        [HttpPost]
        public async Task<IActionResult> ModifierEvenement(GestionEvenementsModifierVM vm)
        {
            decimal prix = 0;
            if (vm.Prix != null)
            {
                if (!decimal.TryParse(vm.Prix, out prix))
                {
                    ModelState.AddModelError("Prix", "Le prix est invalide");
                }
            }

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
                    evenement.Prix = prix;
                    //Si nouvelle photo
                    //if (vm.CoverPhoto != null)
                    //{
                    //    var wwwRootPath = _webHostEnvironment.WebRootPath;
                    //    var fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
                    //    var extension = Path.GetExtension(vm.CoverPhoto.FileName);
                    //    fileName = fileName + "_" + Guid.NewGuid().ToString() +
                    //               extension; // Utilisation de Guid pour un nom de fichier unique
                    //    var folderPath =
                    //        Path.Combine(wwwRootPath, "img",
                    //            "EvenementImages"); // Chemin du dossier où l'image sera sauvegardée
                    //    var fullPath = Path.Combine(folderPath, fileName); // Chemin complet du fichier

                    //    // Sauvegarder l'image
                    //    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    //    {
                    //        await vm.CoverPhoto.CopyToAsync(fileStream);
                    //    }

                    //    evenement.Image =
                    //        "/img/EvenementImages/" + fileName;
                    //}
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
        public IActionResult ShowSupprimerEvenement(string id)
        {
            var evenement = _context.Evenements.FirstOrDefault(e => e.Id == id);
            var vm = new GestionEvenementSupprimerVM()
            {
                Id = evenement.Id,
                Nom = evenement.Nom
            };
            return PartialView("PartialViews/Modals/Evenements/_SupprimerEvenementPartial", vm);
        }
        public IActionResult ShowConfirmerDemande(string id)
        {
            var reservations = _context.Reservations.Include(r => r.Evenement).Include(r => r.Membre).FirstOrDefault(r => r.Id == id);
            var vm = new GestionEvenementsReservationVM
            {
                Id = reservations.Id,
                NomEvenement = reservations.Evenement.Nom,
                NomUtilisateur = reservations.Membre.UserName
            };
            return PartialView("PartialViews/Modals/Evenements/_ConfirmerReservationPartial", vm);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmerDemande(string id)
        {
            var reservation = _context.Reservations.Include(r => r.Evenement).Include(r => r.Membre).FirstOrDefault(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            //Logo fourmi ailé
            var logoUrl = Url.Content("http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");
            //Nom utilisateur du membre
            var username = reservation.Membre.UserName;
            await SendConfirmationEmailMembreConfirmed(username, reservation, logoUrl);
            return Ok();
        }
        public IActionResult ShowAnnulerDemande(string id)
        {
            var reservations = _context.Reservations.Include(r => r.Evenement).Include(r => r.Membre).FirstOrDefault(r => r.Id == id);
            var vm = new GestionEvenementsReservationVM
            {
                Id = reservations.Id,
                NomEvenement = reservations.Evenement.Nom,
                NomUtilisateur = reservations.Membre.UserName
            };
            return PartialView("PartialViews/Modals/Evenements/_AnnulerReservationPartial", vm);
        }
        [HttpPost]
        public async Task<IActionResult> AnnulerDemande(string id)
        {
            var reservation = _context.Reservations.Include(r => r.Evenement).Include(r => r.Membre).FirstOrDefault(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
            reservation.EnDemandeAnnuler = false;
            _context.SaveChanges();
            //Logo fourmi ailé
            var logoUrl = Url.Content("http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");
            //Nom utilisateur du membre
            var username = reservation.Membre.UserName;
            await SendConfirmationEmailMembreCancelled(username, reservation, logoUrl);
            return Ok();
        }
        [HttpPost]
        public IActionResult SupprimerEvenement(string id)
        {
            var evenement = _context.Evenements.FirstOrDefault(e => e.Id == id);
            if (evenement == null)
            {
                return NotFound();
            }
            _context.Evenements.Remove(evenement);
            _context.SaveChanges();
            return Ok();
        }
        private async Task SendConfirmationEmailMembreConfirmed(string? username, Reservation reservation, string logoUrl)
        {
            var subject = "Demande d'annulation de reservation";

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
