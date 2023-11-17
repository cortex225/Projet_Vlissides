using Microsoft.AspNetCore.Identity;
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
            // Récupérer l'ID de l'utilisateur actuel
            var currentUserId = _userManager.GetUserId(HttpContext.User);

            // Récupérer tous les articles du panier pour cet utilisateur
            var articles = _context.LivrePanier.Where(a => a.UserId == currentUserId).ToList();

            var listeArticleVM = new List<AfficherPanierVM>();

            // Parcourir chaque article du panier
            foreach (var a in articles)
            {
                // Récupérer les détails du livre et du type de livre associés à l'article
                var livre = _context.Livres.FirstOrDefault(l => l.Id == a.LivreId);
                var typeLivre = _context.TypeLivres.FirstOrDefault(t => t.Id == a.TypeId);

                // Récupérer le prix original du livre
                var prixOriginal = _context.LivreTypeLivres
                    .FirstOrDefault(lt => lt.LivreId == a.LivreId && lt.TypeLivreId == a.TypeId)?.Prix ?? 0;

                // Récupérer le prix après promotion s'il est disponible, sinon utiliser le prix original
                var prixApresPromotion = a.PrixApresPromotion.HasValue ? a.PrixApresPromotion.Value : prixOriginal;

                // Ajouter les détails de l'article au ViewModel de la liste d'articles
                listeArticleVM.Add(new AfficherPanierVM
                {
                    Id = a.Id,
                    Livre = livre,
                    TypeLivre = typeLivre,
                    PrixOriginal = (double)prixOriginal,
                    PrixApresPromotion = (double)prixApresPromotion,
                    UserId = a.UserId,
                    Quantite = a.Quantite,
                });
            }

            // Calculer le prix total du panier
            double prixtotal = listeArticleVM.Sum(item =>
                item.Quantite != null ? (double)item.Quantite * item.PrixApresPromotion : item.PrixApresPromotion);

            // Créer le ViewModel du panier et lui assigner la liste des articles et le prix total
            var panier = new PanierVM
            {
                ListeArticles = listeArticleVM,
                PrixTotal = prixtotal
            };

            // Retourner la vue avec le ViewModel du panier
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
            var articles = _context.LivrePanier.Where(a => a.UserId == currentUserId).ToList();

            var listeArticleVM = new List<AfficherPanierVM>();

            foreach (var a in articles)
            {
                var livre = _context.Livres.FirstOrDefault(l => l.Id == a.LivreId);
                var typeLivre = _context.TypeLivres.FirstOrDefault(t => t.Id == a.TypeId);
                var prixOriginal = _context.LivreTypeLivres
                    .FirstOrDefault(lt => lt.LivreId == a.LivreId && lt.TypeLivreId == a.TypeId)?.Prix ?? 0;

                // Utiliser 'FirstOrDefault' et vérifier si l'objet n'est pas null avant d'accéder à 'PrixApresPromotion'
                var livrePanier = _context.LivrePanier.FirstOrDefault(lp => lp.Id == a.Id);
                var prixApresPromotion = livrePanier?.PrixApresPromotion ?? prixOriginal;

                listeArticleVM.Add(new AfficherPanierVM
                {
                    Id = a.Id,
                    Livre = livre,
                    TypeLivre = typeLivre,
                    PrixOriginal = (double)prixOriginal,
                    UserId = a.UserId,
                    Quantite = a.Quantite,
                    PrixApresPromotion = (double)prixApresPromotion,
                });
            }

            double prixtotal = listeArticleVM.Sum(item =>
                item.Quantite != null ? (double)item.Quantite * item.PrixApresPromotion : item.PrixApresPromotion);

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
                // Informe l'utilisateur qu'il précommandera le surplus
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
                // Informe l'utilisateur qu'il précommandera le surplus
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
                lp.PrixOriginal = _context.LivreTypeLivres
                    .FirstOrDefault(lt => lt.LivreId == livre.Id && lt.TypeLivreId == type.Id).Prix;




                bool siExiste = false;

                if (user.Panier == null)
                {
                    user.Panier = new List<LivrePanier>();
                }

                foreach (LivrePanier livrePanier in user.Panier)
                {
                    if (livrePanier.LivreId == vm.livreAjouteId)
                    {
                        if (livrePanier.TypeId ==
                            "2") //Vérifier si le livre numérique est déja ajouté (peux pas l'ajouter deux fois)
                        {
                            siExiste = true;
                        }
                        else if (livrePanier.TypeId == "1")
                        {
                            siExiste = true;

                            if (livre.NbExemplaires > livrePanier.Quantite) //Voir si il y reste des livres en stock
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


        [HttpPost]
        public async Task<IActionResult> ValiderCodePromo(string codePromo)
        {
            var promotion = _context.Promotions.FirstOrDefault(p => p.CodePromo == codePromo);

            if (promotion == null)
            {
                return Json(new { success = false, message = "Code promo invalide ou expiré." });
            }

            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var panierVM = new PanierVM
            {
                ListeArticles = _context.LivrePanier
                    .Where(a => a.UserId == currentUserId)
                    .Select(a => new AfficherPanierVM
                    {
                        Id = a.Id,
                        Livre = _context.Livres.FirstOrDefault(l => l.Id == a.LivreId),
                        TypeLivre = _context.TypeLivres.FirstOrDefault(t => t.Id == a.TypeId),
                        PrixOriginal = (double)_context.LivreTypeLivres
                            .FirstOrDefault(lt => lt.LivreId == a.LivreId && lt.TypeLivreId == a.TypeId).Prix,
                        Quantite = a.Quantite
                    }).ToList()
            };

            double prixTotal = 0;

            if (promotion.TypePromotion == "2pour1")
            {
                AppliquerPromotionDeuxPourUn(panierVM, promotion);
                prixTotal = panierVM.ListeArticles.Sum(a => a.PrixApresPromotion * (a.Quantite ?? 1));

            }
            else if (promotion.TypePromotion == "pourcentage")
            {
                foreach (var article in panierVM.ListeArticles)
                {
                    if (EstEligiblePourPromotion(article, promotion))
                    {
                        article.PrixApresPromotion = CalculerPrixApresPromotion(article.PrixOriginal, promotion);

                    }
                    else
                    {
                        article.PrixApresPromotion = article.PrixOriginal;

                    }

                    prixTotal += article.PrixApresPromotion * (article.Quantite ?? 1);

                }
            }

            panierVM.PrixTotal = panierVM.ListeArticles.Sum(a => a.PrixApresPromotion * (a.Quantite ?? 1));
            panierVM.Promotion = promotion;

            foreach (var articleVM in panierVM.ListeArticles)
            {
                var articleBD = _context.LivrePanier.FirstOrDefault(a => a.Id == articleVM.Id);
                if (articleBD != null)
                {
                    articleBD.PrixApresPromotion = (decimal)articleVM.PrixApresPromotion;
                    _context.Update(articleBD);
                }
            }

            await _context.SaveChangesAsync();

            return Json(new { success = true, nouveauTotal = prixTotal, isValid=true, message = "Code promo appliqué avec succès." });
        }

        private void AppliquerPromotionDeuxPourUn(PanierVM panierVM, Promotions promo)
        {

            if (!promo.LivresAcheter.HasValue || !promo.LivresGratuits.HasValue)
            {
                return;
            }
            // Récupérer tous les articles éligibles pour la promotion
            var articlesEligibles = panierVM.ListeArticles
                .Where(a => EstEligiblePourPromotion(a, promo))
                .SelectMany(a => Enumerable.Repeat(a, a.Quantite ?? 1))
                .OrderBy(a => a.PrixOriginal)
                .ToList();

            // Initialisez PrixApresPromotion pour tous les articles éligibles
            foreach (var article in articlesEligibles)
            {
                article.PrixApresPromotion = article.PrixOriginal;
            }

            int nombreTotalArticles = articlesEligibles.Count;
            int tailleGroupe = promo.LivresAcheter.Value + promo.LivresGratuits.Value;
            int nombreDeGroupes = nombreTotalArticles / tailleGroupe;
            int nombreArticlesGratuits = nombreDeGroupes * promo.LivresGratuits.Value;

            // Appliquer la promotion aux articles gratuits
            for (int i = 0; i < nombreArticlesGratuits; i++)
            {
                articlesEligibles[i].PrixApresPromotion = 0;
            }

        }


    private double CalculerPrixApresPromotion(double articlePrixOriginal, Promotions promo)
    {
        double prixApresPromotion = articlePrixOriginal;

        // Si la promotion est une réduction en pourcentage
        if (promo.TypePromotion == "pourcentage" && promo.PourcentageRabais.HasValue)
        {
            prixApresPromotion = articlePrixOriginal * (1 - (promo.PourcentageRabais.Value / 100.0));
        }

        return prixApresPromotion;
    }

    private bool EstEligiblePourPromotion(AfficherPanierVM article, Promotions promotion)
    {
        // Vérifie si la promotion est active en fonction de la date
        // if (DateTime.Now < promotion.DateDebut || DateTime.Now > promotion.DateFin)
        // {
        //     return false;
        // }

        // Vérifie si l'article correspond aux critères spécifiques de la promotion
        return EstEligiblePourPromotionSpecifique(article, promotion);
    }

    private bool EstEligiblePourPromotionSpecifique(AfficherPanierVM article, Promotions promotion)
    {
        // Vérifie si l'article correspond à la catégorie spécifiée dans la promotion
        if (promotion.CategorieId != null)
        {
            var categorieCorrespond =
                article.Livre.Categories?.Any(c => c.CategorieId == promotion.CategorieId) ?? false;
            if (!categorieCorrespond)
            {
                return false;
            }
        }

        // Vérifie si l'article correspond à l'auteur spécifié dans la promotion
        if (promotion.AuteurId != null)
        {
            var auteurCorrespond = article.LivreAuteurs?.Any(la => la.AuteurId == promotion.AuteurId) ?? false;
            if (!auteurCorrespond)
            {
                return false;
            }
        }

        // Vérifie si l'article correspond à la maison d'édition spécifiée dans la promotion
        if (promotion.MaisonEditionId != null && article.Livre.MaisonEditionId != promotion.MaisonEditionId)
        {
            return false;
        }

        // Si toutes les vérifications sont passées ou si aucun critère n'est spécifié, l'article est éligible
        return true;
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
}

}