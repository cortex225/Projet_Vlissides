﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Panier;

namespace VLISSIDES.Controllers;

public class PanierController : Controller
{
    private readonly IConfiguration _config;
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IWebHostEnvironment _webHostEnvironment;

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

        var listeArticleVm = new List<AfficherPanierVM>();

        // Parcourir chaque article du panier
        foreach (var a in _context.LivrePanier.Where(a => a.UserId == currentUserId).Include(a => a.Livre)
            .ThenInclude(l => l.LivreTypeLivres).ThenInclude(ltl => ltl.TypeLivre))
            listeArticleVm.Add(new AfficherPanierVM(a));

        // Calculer le prix total du panier
        var prixtotal = listeArticleVm.Sum(item =>
            item.Quantite != null ? item.Quantite * item.PrixApresPromotion : item.PrixApresPromotion);

        var panier = new PanierVM(listeArticleVm, prixtotal);

        //Préselectionner le don si l'utilisateur à déjà choisi un organisation auparavant
        Don? don = _context.Dons.FirstOrDefault(d => d.UserId == currentUserId);
        if (don != null)
        {
            switch (don.Nom)
            {
                case "Vent Verdure et Plantation":
                    panier.PremierChoixDon = true;

                    break;
                case "Écosystème et Pérennité":
                    panier.DeuxiemeChoixDon = true;
                    break;
                case "Un arbre à la fois":
                    panier.TroisiemeChoixDon = true;
                    break;
            }
        }
        await NbArticles();

        // Retourner la vue avec le ViewModel du panier
        return View(panier);
    }


    [HttpDelete]
    [ValidateAntiForgeryToken]
    [Route("/Panier/SupprimerPanier")]
    public async Task<IActionResult> SupprimerPanier(string id)
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.FindByIdAsync(userId);

        await _context.Entry(user)
            .Collection(u => u.Panier)
            .LoadAsync();

        foreach (var p in user.Panier)
            if (p.Id == id)
            {
                _context.LivrePanier.Remove(p);
                await _context.SaveChangesAsync();

                break;
            }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> AfficherFacture()
    {
        var currentUserId = _userManager.GetUserId(HttpContext.User);
        var articles = _context.LivrePanier.Where(a => a.UserId == currentUserId).ToList();

        var groupedArticles = articles
            .GroupBy(a => new { a.LivreId, a.TypeId })
            .Select(group => new
            {
                LivreId = group.Key.LivreId,
                TypeId = group.Key.TypeId,
                QuantiteTotale = group.Sum(a => a.Quantite ?? 1),
                PrixApresPromotionTotal = group.Sum(a => a.PrixApresPromotion ?? _context.LivreTypeLivres
                    .FirstOrDefault(lt => lt.LivreId == a.LivreId && lt.TypeLivreId == a.TypeId)?.Prix ?? 0)
            });

        var listeArticleVM = new List<AfficherPanierVM>();
        foreach (var group in groupedArticles)
        {
            var livre = _context.Livres.FirstOrDefault(l => l.Id == group.LivreId);
            var typeLivre = _context.TypeLivres.FirstOrDefault(t => t.Id == group.TypeId);

            listeArticleVM.Add(new AfficherPanierVM(new()
            {
                Livre = livre,
                TypeLivre = typeLivre,
                Quantite = group.QuantiteTotale,
                PrixApresPromotion = group.PrixApresPromotionTotal,
                PrixOriginal = _context.LivreTypeLivres
                    .FirstOrDefault(lt => lt.LivreId == group.LivreId && lt.TypeLivreId == group.TypeId)?.Prix!
            }));
        }

        var prixtotal = listeArticleVM.Sum(item =>
            item.Quantite != null ? item.Quantite * item.PrixApresPromotion : item.PrixApresPromotion);

        var panier = new PanierVM(listeArticleVM, prixtotal);
        //Préselectionner le don si l'utilisateur à déjà choisi un organisation auparavant
        Don? don = _context.Dons.FirstOrDefault(d => d.UserId == currentUserId);
        if (don != null)
        {
            switch (don.Nom)
            {
                case "Vent Verdure et Plantation":
                    panier.PremierChoixDon = true;

                    break;
                case "Écosystème et Pérennité":
                    panier.DeuxiemeChoixDon = true;
                    break;
                case "Un arbre à la fois":
                    panier.TroisiemeChoixDon = true;
                    break;
            }
        }
        return PartialView("PartialViews/Panier/_FacturePartial", panier);
    }

    [HttpPost]
    public ActionResult ModifierQuantite(string id, int quantite)
    {
        var article = _context.LivrePanier.FirstOrDefault(lp => lp.Id == id);
        var livre = _context.Livres.Find(article.LivreId);

        if (quantite > livre.NbExemplaires)
            // Informe l'utilisateur qu'il précommandera le surplus
            return Content(
                "La quantité demandée n'est pas disponible en stock. Voulez-vous précommander le surplus ?");

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
        var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.FindByIdAsync(userId);

        var type = await _context.TypeLivres.FindAsync(vm.TypeId);

        var livre = await _context.Livres.FindAsync(vm.LivreId);

        if (vm.Quantitee > livre.NbExemplaires)
            // Informe l'utilisateur qu'il précommandera le surplus
            return Content(
                "La quantité demandée n'est pas disponible en stock. Voulez-vous précommander le surplus ?");


        var currentUserId = _userManager.GetUserId(HttpContext.User);
        var article = _context.LivrePanier.Where(a => a.UserId == currentUserId).ToList();


        var lp = new LivrePanier();

        if (livre != null && type != null && user != null)
        {
            await _context.Entry(user)
                .Collection(u => u.Panier)
                .LoadAsync();

            lp.Id = Guid.NewGuid().ToString();
            lp.LivreId = livre.Id;
            lp.TypeId = type.Id;
            lp.TypeLivre = type;
            lp.Quantite = vm.Quantitee;
            lp.UserId = user.Id;
            lp.PrixOriginal = _context.LivreTypeLivres
                .FirstOrDefault(lt => lt.LivreId == livre.Id && lt.TypeLivreId == type.Id).Prix;


            var siExiste = false;

            if (user.Panier == null) user.Panier = new List<LivrePanier>();

            foreach (var livrePanier in user.Panier)
                if (livrePanier.LivreId == vm.LivreId)
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
                            if (livre.NbExemplaires > vm.Quantitee + livrePanier.Quantite)
                            {
                                livrePanier.Quantite += vm.Quantitee;
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

            if (!siExiste)
            {
                _context.LivrePanier.Add(lp);
                await _context.SaveChangesAsync();
            }
        }

        //Set le nombre d'articles dans le panier
        await NbArticles();

        return RedirectToAction("Recherche/Details?id=" + vm.LivreId);
    }

    //Pour montrer la partial view de confirmation de suppression
    [HttpGet]
    public async Task<IActionResult> ShowDeleteConfirmation(string id)
    {
        if (id == null) return NotFound();

        var livreP = await _context.LivrePanier.Include(lp => lp.Livre).FirstOrDefaultAsync(lp => lp.Id == id);
        if (livreP == null) return NotFound();

        var vm = new SupprPanierConfirmationVM(livreP.Id, livreP.Livre.Titre);


        return PartialView("PartialViews/Modals/Panier/_DeletePanierConfirmation", vm);
    }


    [HttpPost]
    public async Task<IActionResult> ValiderCodePromo(string codePromo)
    {
        var currentUserId = _userManager.GetUserId(HttpContext.User);
        var utilisateur = _context.Users.Find(currentUserId);
        var promotion = _context.Promotions.FirstOrDefault(p => p.CodePromo == codePromo);


        // Vérifie si le code promo existe
        if (promotion == null) return Json(new { success = false, message = "Code promo invalide ou expiré." });



        // Vérifie si c'est le mois d'anniversaire de l'utilisateur
        if (DateTime.Now.Month != utilisateur.DateNaissance?.Month && promotion.CodePromo == "BIRTHDAY")
            return Json(new
            {
                success = false,
                message = "Ce code promo est uniquement valide durant votre mois d'anniversaire."
            });
        // Vérifie si la promo a déjà été utilisée cette année
        if (utilisateur.DerniereUtilisationPromoAnniversaire.HasValue &&
            utilisateur.DerniereUtilisationPromoAnniversaire.Value.Year == DateTime.Now.Year &&
            promotion.CodePromo == "BIRTHDAY")
            return Json(new
            { success = false, message = "Vous avez déjà utilisé ce code promo cette année." });




        var panierVM = new PanierVM(_context.LivrePanier
                .Where(a => a.UserId == currentUserId)
                .Select(a => new AfficherPanierVM(new()
                {
                    Id = a.Id,
                    Livre = _context.Livres.FirstOrDefault(l => l.Id == a.LivreId)!,
                    TypeLivre = _context.TypeLivres.FirstOrDefault(t => t.Id == a.TypeId)!,
                    PrixOriginal = _context.LivreTypeLivres
                        .FirstOrDefault(lt => lt.LivreId == a.LivreId && lt.TypeLivreId == a.TypeId)!.Prix,
                    Quantite = a.Quantite
                })));

        // Vérifie si une promotion a déjà été appliquée
        if (panierVM.PromotionAppliquee)
        {
            return Json(new { success = false, message = "Une promotion a déjà été appliquée à ce panier." });
        }

        decimal prixTotal = 0;

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
                    //Calcule le prix après promotion
                    article.PrixApresPromotion = CalculerPrixApresPromotion(article.PrixOriginal, promotion);


                }
                else
                    article.PrixApresPromotion = article.PrixOriginal;

                prixTotal += article.PrixApresPromotion * (article.Quantite ?? 1);
            }
        }

        panierVM.PrixTotal = panierVM.ListeArticles.Sum(a => a.PrixApresPromotion * (a.Quantite ?? 1));
        panierVM.Promotion = promotion.Nom;

        foreach (var articleVM in panierVM.ListeArticles)
        {
            var articleBD = _context.LivrePanier.FirstOrDefault(a => a.Id == articleVM.Id);
            if (articleBD != null)
            {
                articleBD.PrixApresPromotion = (decimal)articleVM.PrixApresPromotion;
                _context.Update(articleBD);
            }
        }

        // Si la promotion est appliquée avec succès, marquez-la comme appliquée
        panierVM.PromotionAppliquee = true;
        // Mettre à jour la dernière utilisation
        utilisateur.DerniereUtilisationPromoAnniversaire = DateTime.Now;
        _context.Update(utilisateur);
        await _context.SaveChangesAsync();

        return Json(new
        { success = true, nouveauTotal = prixTotal, isValid = true, message = "Code promo appliqué avec succès." });
    }

    private void AppliquerPromotionDeuxPourUn(PanierVM panierVM, Promotion promo)
    {
        if (!promo.LivresAcheter.HasValue || !promo.LivresGratuits.HasValue) return;
        // Récupérer tous les articles éligibles pour la promotion
        var articlesEligibles = panierVM.ListeArticles
            .Where(a => EstEligiblePourPromotion(a, promo))
            .SelectMany(a => Enumerable.Repeat(a, a.Quantite ?? 1))
            .OrderBy(a => a.PrixOriginal)
            .ToList();

        // Initialisez PrixApresPromotion pour tous les articles éligibles
        foreach (var article in articlesEligibles) article.PrixApresPromotion = article.PrixOriginal;

        var nombreTotalArticles = articlesEligibles.Count;
        var tailleGroupe = promo.LivresAcheter.Value + promo.LivresGratuits.Value;
        var nombreDeGroupes = nombreTotalArticles / tailleGroupe;
        var nombreArticlesGratuits = nombreDeGroupes * promo.LivresGratuits.Value;

        // Appliquer la promotion aux articles gratuits
        for (var i = 0; i < nombreArticlesGratuits; i++) articlesEligibles[i].PrixApresPromotion = 0;
    }


    private decimal CalculerPrixApresPromotion(decimal articlePrixOriginal, Promotion promo)
    {
        var prixApresPromotion = articlePrixOriginal;

        // Si la promotion est une réduction en pourcentage
        if (promo.TypePromotion == "pourcentage" && promo.PourcentageRabais.HasValue)
            prixApresPromotion = articlePrixOriginal * (decimal)(1 - promo.PourcentageRabais.Value / 100.0);

        return prixApresPromotion;
    }

    private bool EstEligiblePourPromotion(AfficherPanierVM article, Promotion promotion)
    {
        // Vérifie si la promotion est active en fonction de la date
        // if (DateTime.Now < promotion.DateDebut || DateTime.Now > promotion.DateFin)
        // {
        //     return false;
        // }

        // Vérifie si l'article correspond aux critères spécifiques de la promotion
        return EstEligiblePourPromotionSpecifique(article, promotion);
    }

    private bool EstEligiblePourPromotionSpecifique(AfficherPanierVM article, Promotion promotion)
    {
        // Vérifie si l'article correspond à la catégorie spécifiée dans la promotion
        if (promotion.CategorieId != null)
        {
            var categorieCorrespond =
                article.CategoriesIds?.Any(c => c == promotion.CategorieId) ?? false;
            if (!categorieCorrespond) return false;
        }

        // Vérifie si l'article correspond à l'auteur spécifié dans la promotion
        if (promotion.AuteurId != null)
        {
            var auteurCorrespond = article.AuteursIds?.Any(la => la == promotion.AuteurId) ?? false;
            if (!auteurCorrespond) return false;
        }

        // Vérifie si l'article correspond à la maison d'édition spécifiée dans la promotion
        if (promotion.MaisonEditionId != null && article.MaisonEditionId != promotion.MaisonEditionId)
            return false;
        // Si toutes les vérifications sont passées ou si aucun critère n'est spécifié, l'article est éligible
        return true;

    }

    [HttpGet]
    public async Task<int> NbArticles()
    {
        var currentUserId = _userManager.GetUserId(HttpContext.User);
        var nbArticles = await _context.LivrePanier
            .Where(a => a.UserId == currentUserId)
            .SumAsync(a => a.Quantite ?? 1);
        return nbArticles;
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
                    };
                    _context.Dons.Add(don);
                    _context.SaveChanges();
                    break;
                case "2":
                    don = new Don()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Nom = "Écosystème et Pérennité",
                        Montant = 5.00,
                        UserId = currentUserId,
                    };
                    _context.Dons.Add(don);
                    _context.SaveChanges();
                    break;
                case "3":
                    don = new Don()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Nom = "Un arbre à la fois",
                        Montant = 5.00,
                        UserId = currentUserId,
                    };
                    _context.Dons.Add(don);
                    _context.SaveChanges();
                    break;
                default:
                    don = null;
                    break;
            }

        }
        else
        {//Modification quand don n'est pas nulle
            switch (numero)
            {
                case "1": don.Nom = "Vent Verdure et Plantation"; break;
                case "2": don.Nom = "Écosystème et Pérennité"; break;
                case "3": don.Nom = "Un arbre à la fois"; break;
                default: _context.Dons.Remove(don); break;
            }
            _context.SaveChanges();
        }
        return RedirectToAction("Index", "Paiement");
    }
}
