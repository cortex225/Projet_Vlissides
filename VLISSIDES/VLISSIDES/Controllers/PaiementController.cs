namespace VLISSIDES.Controllers
{
    public class PaiementController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ApplicationUser> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PaiementController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            RoleManager<IdentityRole> roleManager,
            ILogger<ApplicationUser> logger,
            ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor,
            IWebHostEnvironment webHostEnvironment,
            IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
            _roleManager = roleManager;
            _logger = logger;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
        }
        public IActionResult Index()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            var adresse = _context.Adresses.Where(a => a.UtilisateurPrincipalId == currentUserId || a.UtilisateurLivraisonId == currentUserId);

            var listAdresse = new ProfileModifierAdressesVM
            {
                AdressesDeLivraison = adresse.ToList()
            };

            var adresseVM = new StripePaiementVM
            {
                Adresse = listAdresse
            };

            return View(adresseVM);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "Panier");
        }
        [Route("Paiement/Success")]
        public IActionResult Success()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCheckoutSession(StripePaiementVM model)
        {

            // Récupère l'identifiant de l'utilisateur connecté
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var StripeCustomerId = _context.Membres.Where(m => m.Id == userId).FirstOrDefault().StripeCustomerId;

            // Récupere les données de LivrePanier basées sur l'identifiant de l'utilisateur
            var panierItems = _context.LivrePanier
                .Where(lp => lp.UserId == userId)
                .Include(lp => lp.Livre).ThenInclude(livre => livre.LivreTypeLivres).ThenInclude(livretypelivre => livretypelivre.TypeLivre)
                .ToList();
            //Tax livre

            var taxLivreOptions = new TaxRateCreateOptions
            {
                DisplayName = "TPS",
                Inclusive = false,
                Percentage = 5,
            };
            var taxLivreService = new TaxRateService();
            var taxLivreRate = taxLivreService.Create(taxLivreOptions);


            var lineItems = panierItems.Select(item =>
            {
                // Récupére l'URL de l'image du livre
                var imgLivreUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{item.Livre.Couverture}";
                var encodedImgLivreUrl = Uri.EscapeUriString(imgLivreUrl); // Encodez l'URL de l'image du livre pour qu'elle soit utilisable dans Stripe

                ViewBag.encodedImgLivreUrl = encodedImgLivreUrl;


                // Crée et retourne un SessionLineItemOptions pour chaque livre dans le panier
                return new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Livre.LivreTypeLivres.FirstOrDefault().Prix) * 100,
                        Currency = "cad",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Livre.Titre,
                            Images = new List<string> { encodedImgLivreUrl },
                        },

                    },
                    Quantity = item.Quantite,

                };
            }).ToList();
            var don = _context.Dons.FirstOrDefault(d => d.UserId == userId);
            var taxDonOptions = new TaxRateCreateOptions
            {
                DisplayName = "Don",
                Inclusive = true,
                Percentage = 0,
            };
            var taxDonService = new TaxRateService();
            var taxDonRate = taxDonService.Create(taxDonOptions);
            if (don != null)
            {
                lineItems.Add(new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(don.Montant) * 100,
                        Currency = "cad",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = don.Nom,

                        }
                    },
                    Quantity = 1,
                    TaxRates = new List<string> { taxDonRate.Id }

                });
            }


            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",
                Customer = StripeCustomerId,
                AllowPromotionCodes = true,

                BillingAddressCollection = "required",// Demande à Stripe de collecter l'adresse de facturation du client
                ShippingAddressCollection = new SessionShippingAddressCollectionOptions
                {
                    AllowedCountries = new List<string> { "CA", "US" }, // Limite les adresses de livraison aux États-Unis et au Canada

                },
                CustomerUpdate = new SessionCustomerUpdateOptions
                {
                    Address = "auto", // Met à jour l'adresse du client lorsqu'il passe une commande
                    Name = "auto", // Met à jour le nom du client lorsqu'il passe une commande
                    Shipping = "auto", // Met à jour les informations d'expédition du client lorsqu'il passe une commande

                },
                Metadata = new Dictionary<string, string>
                {
                    { "type", "livre" }, // Ici, vous indiquez que le type d'achat est "livre"

                },
                InvoiceCreation = new SessionInvoiceCreationOptions
                {
                    Enabled = true,// Créez une facture pour chaque session de paiement
                },
                AutomaticTax = new SessionAutomaticTaxOptions
                {
                    Enabled = true, // Activez le calcul automatique des taxes
                },

                SuccessUrl = Url.Action("Success", "Paiement", null, Request.Scheme),
                CancelUrl = Url.Action("Cancel", "Paiement", null, Request.Scheme),
            };




            var service = new SessionService();
            Session session = service.Create(options);

            return Json(new { id = session.Id });
        }

        public Adresse AdresseSelection(string id)
        {
            var adresse = _context.Adresses.FirstOrDefault(a => a.Id == id);

            return adresse;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnregistrerAdresse(ProfileModifierAdressesVM vm)
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            if (ModelState.IsValid)
            {
                var adresse = new Adresse
                {
                    UtilisateurLivraisonId = currentUserId,
                    NoApartement = vm.NoApartement,
                    NoCivique = vm.NoCivique,
                    Rue = vm.Rue,
                    Ville = vm.Ville,
                    Province = vm.Province,
                    Pays = vm.Pays,
                    CodePostal = vm.CodePostal,
                };
                _context.Adresses.Add(adresse);
                await _context.SaveChangesAsync(); // Utiliser la version asynchrone pour sauvegarder les changements
                return Json(new
                { success = true, message = "Adresse enregistrée avec succès." }); // Renvoyer une réponse JSON
            }

            // Si le modèle n'est pas valide, renvoyer les erreurs de validation
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, message = "Erreur de validation.", errors = errors });
        }

    }
}
