﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Panier;

namespace VLISSIDES.Controllers
{
    public class PanierController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PanierController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
            IConfiguration config, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var article = _context.LivrePanier.Where(a => a.UserId == currentUserId).ToList();

            var listeArticleVM = article.Select(a => new AfficherPanierVM
            {
                Livre = _context.Livres.FirstOrDefault(l => l.Id == a.LivreId),
                TypeLivre = _context.TypeLivres.FirstOrDefault(t => t.Id == a.TypeId),
                Prix = (double)_context.LivreTypeLivres.FirstOrDefault(lt => lt.LivreId == a.LivreId && lt.TypeLivreId == a.TypeId).Prix,
                UserId = a.UserId,
                Quantite = a.Quantite,
                Id = a.Id
            }).ToList();

            double prixtotal = 0;

            foreach (var item in listeArticleVM)
            {
                if (item.Quantite is not null)
                {
                    prixtotal += (double)item.Quantite * item.Prix;
                }
                else
                {
                    prixtotal += item.Prix;
                }

            }

            var panier = new PanierVM
            {
                ListeArticles = listeArticleVM,
                PrixTotal = prixtotal

            };

            return View(panier);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        [Route("/Panier/SupprimerPanier")]
        public async Task<IActionResult> SupprimerPanier(string id)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser? user = await _userManager.FindByIdAsync(userId);

            await _context.Entry(user)
                    .Collection(u => u.Panier)
                    .LoadAsync();

            foreach (LivrePanier p in user.Panier)
            {
                if (p.Id == id)
                {
                    _context.LivrePanier.Remove(p);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("/Panier/Index", new { refresh = true });
        }

        [HttpPost]
        public ActionResult ModifierMaison(string id, int quantite)
        {
            if (ModelState.IsValid)
            {
                var article = _context.LivrePanier.FirstOrDefault(lp => lp.Id == id);
                article.Quantite = quantite;
                _context.SaveChanges();
                return Ok();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Panier/AjouterPanier")]
        //[Route("{controller}/{action}")]
        public async Task<IActionResult> AjouterPanier([FromBody] AjouterPanierVM vm)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser? user = await _userManager.FindByIdAsync(userId);

            TypeLivre? type = await _context.TypeLivres.FindAsync(vm.typeId);

            Livre? livre = await _context.Livres.FindAsync(vm.livreAjouteId);

            LivrePanier lp = new LivrePanier();

            if (livre != null && type != null && user != null)
            {
                await _context.Entry(user)
                    .Collection(u => u.Panier)
                    .LoadAsync();

                lp.Id = Guid.NewGuid().ToString();
                lp.LivreId = livre.Id;
                lp.TypeId = type.Id;
                lp.Quantite = vm.quantitee;
                lp.UserId = user.Id;

                bool siExiste = false;

                if (user.Panier == null)
                {
                    user.Panier = new List<LivrePanier>();
                }

                foreach (LivrePanier livrePanier in user.Panier)
                {
                    if (livrePanier.LivreId == vm.livreAjouteId)
                    {
                        if (livrePanier.TypeId == "2")//Vérifier si le livre numérique est déja ajouté (peux pas l'ajouter deux fois)
                        {
                            siExiste = true;
                        }
                        else if (livrePanier.TypeId == "1")
                        {
                            siExiste = true;

                            if (livre.NbExemplaires > livrePanier.Quantite)//Voir si il y reste des livres en stock
                            {
                                //Ajouter ce que le client commande au reste des livres 
                                if (livre.NbExemplaires > (vm.quantitee + livrePanier.Quantite))
                                {
                                    livrePanier.Quantite += vm.quantitee;
                                    await _context.SaveChangesAsync();
                                }
                                else //Prendre tous les livres
                                {
                                    livrePanier.Quantite = livre.NbExemplaires;
                                    await _context.SaveChangesAsync();
                                }
                            }
                        }
                    }
                }

                if (!siExiste)
                {
                    _context.LivrePanier.Add(lp);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("Recherche/Details?id=" + vm.livreAjouteId);
        }

        //Pour montrer la partial view de confirmation de suppression
        [HttpGet]
        public async Task<IActionResult> ShowDeleteConfirmation(string id)
        {
            if (id == null) return NotFound();

            var livreP = await _context.LivrePanier.Include(lp => lp.Livre).FirstOrDefaultAsync(lp => lp.Id == id);
            if (livreP == null) return NotFound();

            SupprPanierConfirmationVM vm = new SupprPanierConfirmationVM() 
            {
                Id = livreP.Id,
                Titre = livreP.Livre.Titre
            };


            return PartialView("PartialViews/Modals/Panier/_DeletePanierConfirmation", vm);
        }
    }
}
