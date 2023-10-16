using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Checkout;
using VLISSIDES.Data;
using VLISSIDES.Interfaces;
using VLISSIDES.Models;

namespace VLISSIDES.Controllers;

public class GestionCommandeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IUserEmailStore<ApplicationUser> _emailStore;
    private readonly ILogger<ApplicationUser> _logger;
    private readonly ISendGridEmail _sendGridEmail;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserStore<ApplicationUser> _userStore;
    
    public GestionCommandeController(
        SignInManager<ApplicationUser> signInManager,
        ILogger<ApplicationUser> logger,
        UserManager<ApplicationUser> userManager,
        ApplicationDbContext context,
        IUserStore<ApplicationUser> userStore,
        IEmailSender emailSender,
        RoleManager<IdentityRole> roleManager,
        ISendGridEmail sendGridEmail
        )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
        _context = context;
        _userStore = userStore;
        _sendGridEmail = sendGridEmail;
    }

    [HttpPost]
    public async Task<IActionResult> AjouterAuPanier(string livreId, int quantite, string typeLivreId)
    {
        var userId = User.Identity.Name; // Assurez-vous que l'utilisateur est connecté

        try
        {
            // Trouver ou créer une commande (panier) pour l'utilisateur
            var commande = await _context.Commandes
                .Include(c => c.LivreCommandes)
                .ThenInclude(lc => lc.Livre)
                .FirstOrDefaultAsync(c =>
                    c.MembreId == userId && c.StatutCommandeId == "1"); // Assumer que "1" est l'ID pour "En attente"

            if (commande == null)
            {
                commande = new Commande
                {
                    MembreId = userId,
                    DateCommande = DateTime.Now,
                    StatutCommandeId = "1", // En attente
                    LivreCommandes = new List<LivreCommande>()
                };
                _context.Commandes.Add(commande);
            }

            // Trouver le livre et le prix basé sur le type de livre
            var livre = await _context.Livres
                .Include(l => l.LivreTypeLivres)
                .FirstOrDefaultAsync(l => l.Id == livreId);

            var prix = livre.LivreTypeLivres.FirstOrDefault(lt => lt.TypeLivreId == typeLivreId)?.Prix ?? 0;

            // Ajouter le livre à la commande
            var livreCommande = new LivreCommande
            {
                LivreId = livreId,
                Quantite = quantite,
                PrixParArticle = prix
            };
            commande.LivreCommandes.Add(livreCommande);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return View("Error");
        }

        return RedirectToAction("Index", "Accueil");
    }

    [HttpPost]
    public async Task<IActionResult> CreateCheckoutSession()
    {
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string>
            {
                "card",
            },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = 2000, // montant en centimes
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Nom du produit",
                        },
                    },
                    Quantity = 1,
                },
            },
            Mode = "payment",
            SuccessUrl = Url.Action("Success", "GestionCommande", null, Request.Scheme),
            CancelUrl = Url.Action("Cancel", "GestionCommande", null, Request.Scheme),
        };

        var service = new SessionService();
        Session session = await service.CreateAsync(options);

        return Json(new { id = session.Id });
    }

    public IActionResult Success()
    {
        // Gérez le succès du paiement ici (ex. mise à jour de la commande)
        return View();
    }

    public IActionResult Cancel()
    {
        // Gérez l'annulation du paiement ici
        return View();
    }



}