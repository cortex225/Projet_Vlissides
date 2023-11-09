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
        private string? IdLivreSupprime = null;

        public PanierController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
            IConfiguration config, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var article = _context.LivrePanier.Where(a => a.UserId == currentUserId).ToList();

            var listeArticleVM = article.Select(a => new AfficherPanierVM
            {
                Id = a.Id,
                Livre = _context.Livres.FirstOrDefault(l => l.Id == a.LivreId),
                TypeLivre = _context.TypeLivres.FirstOrDefault(t => t.Id == a.TypeId),
                Prix = (double)_context.LivreTypeLivres.FirstOrDefault(lt => lt.LivreId == a.LivreId && lt.TypeLivreId == a.TypeId).Prix,
                UserId = a.UserId,
                Quantite = a.Quantite
            }).ToList();


            double prixtotal = 0;

            if (IdLivreSupprime != null)
            {
                listeArticleVM.RemoveAll(a => a.Id == IdLivreSupprime);
                IdLivreSupprime = null;
            }

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
            await NbArticles();

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
                    IdLivreSupprime = p.Id;
                    _context.LivrePanier.Remove(p);
                    await _context.SaveChangesAsync();

                    break;
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AfficherFacture()
        {

            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var article = _context.LivrePanier.Where(a => a.UserId == currentUserId).ToList();

            var listeArticleVM = article.Select(a => new AfficherPanierVM
            {
                Id = a.Id,
                Livre = _context.Livres.FirstOrDefault(l => l.Id == a.LivreId),
                TypeLivre = _context.TypeLivres.FirstOrDefault(t => t.Id == a.TypeId),
                Prix = (double)_context.LivreTypeLivres.FirstOrDefault(lt => lt.LivreId == a.LivreId && lt.TypeLivreId == a.TypeId).Prix,
                UserId = a.UserId,
                Quantite = a.Quantite,
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

            return PartialView("PartialViews/Panier/_FacturePartial", panier);
        }

        [HttpPost]
        public ActionResult ModifierQuantite(string id, int quantite)
        {
            var article = _context.LivrePanier.FirstOrDefault(lp => lp.Id == id);
            var livre = _context.Livres.Find(article.LivreId);

            if (quantite > livre.NbExemplaires)
            {
                // Informez l'utilisateur qu'il précommandera le surplus
                // Vous pouvez également enregistrer la quantité précommandée dans la base de données
                return Content(
                    "La quantité demandée n'est pas disponible en stock. Voulez-vous précommander le surplus ?");
            }

            article.Quantite = quantite;
            _context.SaveChanges();
            return Ok();
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

            if (vm.quantitee > livre.NbExemplaires)
            {
                // Informez l'utilisateur qu'il précommandera le surplus
                // Vous pouvez également enregistrer la quantité précommandée dans la base de données
                return Content(
                    "La quantité demandée n'est pas disponible en stock. Voulez-vous précommander le surplus ?");
            }


            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var article = _context.LivrePanier.Where(a => a.UserId == currentUserId).ToList();


            LivrePanier lp = new LivrePanier();

            if (livre != null && type != null && user != null)
            {
                await _context.Entry(user)
                    .Collection(u => u.Panier)
                    .LoadAsync();

                lp.Id = Guid.NewGuid().ToString();
                lp.LivreId = livre.Id;
                lp.TypeId = type.Id;
                lp.TypeLivre = type;
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

            //Set le nombre d'articles dans le panier
            await NbArticles();

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

        [HttpGet]
        public async Task<int> NbArticles()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var NbArticles = await _context.LivrePanier
                .Where(a => a.UserId == currentUserId)
                .SumAsync(a => a.Quantite ?? 1);
            return NbArticles;
        }

        [HttpGet]
        public IActionResult PasserAuPaiement(string numero)
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            Don? don = _context.Dons.FirstOrDefault(d => d.UserId == currentUserId);
            if (don == null)
            {
                //Ajout si don est null
                switch (numero)
                {
                    case "1":
                        don = new Don()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Nom = "Vent Verdure et Plantation",
                            Montant = 5.00,
                            UserId = currentUserId,
                        }; break;
                    case "2":
                        don = new Don()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Nom = "Écosystème et Pérennité",
                            Montant = 5.00,
                            UserId = currentUserId,
                        }; break;
                    case "3":
                        don = new Don()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Nom = "Un arbre à la fois",
                            Montant = 5.00,
                            UserId = currentUserId,
                        }; break;
                }
                _context.Dons.Add(don);
                _context.SaveChanges();
            }
            else
            {//Modification quand don n'est pas nulle
                switch (numero)
                {
                    case "1": don.Nom = "Vent Verdure et Plantation"; break;
                    case "2": don.Nom = "Écosystème et Pérennité"; break;
                    case "3": don.Nom = "Un arbre à la fois"; break;
                }
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Paiement");
        }
    }
}
