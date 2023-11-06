﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionCommandes;

namespace VLISSIDES.Controllers
{
    public class HistoriqueCommandes : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HistoriqueCommandes(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var commandes = _context.Commandes
                .Include(c => c.StatutCommande)
                .Include(c => c.Membre);
            var livreCommandes = _context.LivreCommandes;

            var livreCommandeVM = livreCommandes.Select(lc => new LivreCommandeVM
            {
                Livre = lc.Livre,
                CommandeId = lc.CommandeId,
                Quantite = lc.Quantite,
                PrixAchat = lc.PrixAchat
            }).ToList();

            var listeCommandeVM = commandes.Where(c => c.MembreId == userId).AsEnumerable().Select(c => new CommandesVM
            {
                Id = c.Id.ToString(),
                DateCommande = c.DateCommande,
                PrixTotal = c.PrixTotal,
                MembreUserName = c.Membre.UserName,
                AdresseId = c.AdresseId,
                LivreCommandes = livreCommandeVM.Where(lc => lc.CommandeId == c.Id).ToList(),
                StatutId = c.StatutCommande.Id,
                StatutNom = c.StatutCommande.Nom
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
    }
}
