using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VLISSIDES.Data;
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

        public GestionCommandesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
            IConfiguration config, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
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
        public IActionResult AccepterDemandeRetour(string commandeId, string livreId, string quantite)
        {
            LivreCommande? livreCommande = _context.LivreCommandes.FirstOrDefault(lc => lc.CommandeId == commandeId && lc.LivreId == livreId);



            int quantiteInt;
            if (int.TryParse(quantite, out quantiteInt) && livreCommande is not null)
            {
                //if (livreCommande.Quantite == quantiteInt)
                //{
                //    //Soit qu'on supprime la commande ou on affiche le nombre de livre retournés
                //}
                //else
                //{
                livreCommande.Quantite -= quantiteInt;
                //}
            }
            else
            {
                return BadRequest();
            }

            livreCommande.EnDemandeRetourner = false;
            return View();
        }

        [HttpPost]
        public IActionResult AccepterDemandeAnnulation(string commandeId)
        {
            Commande? commande = _context.Commandes.FirstOrDefault(lc => lc.Id == commandeId);

            if (commande is not null)
            {
                commande.StatutCommandeId = "5";

                commande.EnDemandeAnnulation = false;
            }

            return View();
        }

        [HttpPost]
        public IActionResult RefuserDemandeRetour(string commandeId, string livreId, string quantite)
        {
            LivreCommande? livreCommande = _context.LivreCommandes.FirstOrDefault(lc => lc.CommandeId == commandeId && lc.LivreId == livreId);

            if (livreCommande is not null)
            {
                livreCommande.EnDemandeRetourner = false;
            }

            return View();
        }

        [HttpPost]
        public IActionResult RefuserDemandeAnnulation(string commandeId)
        {
            Commande? commande = _context.Commandes.FirstOrDefault(lc => lc.Id == commandeId);

            if (commande is not null)
            {
                commande.EnDemandeAnnulation = false;
            }

            return View();
        }
    }
}
