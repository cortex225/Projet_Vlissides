using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using VLISSIDES.Data;
using VLISSIDES.Interfaces;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Accueil;
using VLISSIDES.ViewModels.Compte;

namespace VLISSIDES.Controllers;

public class CompteController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IUserEmailStore<ApplicationUser> _emailStore;
    private readonly ILogger<ApplicationUser> _logger;
    private readonly ISendGridEmail _sendGridEmail;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserStore<ApplicationUser> _userStore;

    public CompteController(
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


    [AllowAnonymous]
    [Route("Identity/Account/Login", Order = -1)]
    [Route("Identity/Account/AccessDenied", Order = -1)]
    [Route("{controller}/{action}", Order = -2)]
    public IActionResult Login(string? returnUrl = null)
    {
        var vm = new LoginVM();
        vm.ReturnUrl = returnUrl;
        returnUrl = returnUrl ?? Url.Content("~/"); //Permet de retourner en arrière sans le cache

        return View(vm);
    }

    // POST: /Compte/Login
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    [Route("Identity/Account/Login", Order = -1)]
    [Route("Identity/Account/AccessDenied", Order = -1)]
    [Route("{controller}/{action}", Order = -2)]
    public async Task<ActionResult> Login(LoginVM vm, string? returnUrl = null)
    {
        if (ModelState.IsValid)
        {
            // Essayer de trouver l'utilisateur par son nom d'utilisateur
            var user = await _userManager.FindByNameAsync(vm.EmailOrUserName);

            // Si l'utilisateur n'est pas trouvé, essayer de trouver l'utilisateur par son e-mail
            if (user == null) user = await _userManager.FindByEmailAsync(vm.EmailOrUserName);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Tentative de connexion non valide.");
                return View(vm);
            }

            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError(string.Empty, "L'email est encore a être confirmer.");
                return View(vm);
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, vm.Password, vm.RememberMe, false);

            if (result.Succeeded)
            {
                _logger.LogInformation("L'utilisateur est connecté.");
                if (vm.RememberMe)
                {
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddDays(3)
                    };
                    await _signInManager.SignInAsync(user, authProperties);
                }
                else
                {
                    await _signInManager.SignInAsync(user, false);
                }

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                return RedirectToAction("Index", "Accueil");
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning("L'utilisateur est barré.");
                return RedirectToAction("Index", "Accueil", new MessageVM(
                    "Bloqué!",
                    "Le compte au quel vous essayé de vous connecter est bloqué."));
            }

            ModelState.AddModelError(string.Empty, "Tentative de connexion non valide.");
            return View(vm);
        }

        ModelState.AddModelError(string.Empty, "Tentative de connexion non valide.");
        return View(vm);
    }


    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Register(string? returnUrl = null)
    {
        var vm = new RegisterVM();
        vm.ReturnUrl = returnUrl;
        // Populate Department list
        return View(vm);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterVM vm, string? returnUrl = null)
    {
        // Vérifie si l'état du modèle est valide.
        if (ModelState.IsValid)
        {
            // L'utilisateur doit accepter les conditions générales pour s'inscrire.
            // Si les conditions ne sont pas acceptées, ajoutez une erreur de modèle et retournez la vue.
            if (!vm.Conditions)
            {
                ModelState.AddModelError(nameof(vm.Conditions),
                    "Vous devez accepter les conditions générales d'utilisation.");
                return View(vm);
            }

            // Si l'URL de retour est null, redirigez vers la page d'accueil.
            returnUrl ??= Url.Content("~/");

            // Vérifie si l'utilisateur existe déjà.
            var userExists = await _userManager.FindByEmailAsync(vm.Email);
            if (userExists != null)
            {
                ModelState.AddModelError(nameof(vm.Email), "Cet utilisateur existe déjà.");
                return View(vm);
            }

            // Créez un nouvel utilisateur en fonction du type.
            ApplicationUser user;
            string role;

            user = new Membre
            {
                NoMembre = "M" + DateTime.Now.ToString("MM/dd/yyyy") + (_context.Membres.Count() + 1),
                UserName = vm.UserName,
                Email = vm.Email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                NormalizedEmail = vm.Email.ToUpper(),
                NormalizedUserName = vm.UserName.ToUpper(),
                Nom = vm.FirstName,
                Prenom = vm.LastName,
                PhoneNumber = vm.Phone,
                DateAdhesion = DateTime.Now,
                DateNaissance = vm.DateNaissance,

            };

            user.CoverImageUrl = "/img/UserPhoto/DefaultUser.png";
            user.EmailConfirmed = false;
            role = RoleName.MEMBRE;

            //user.AdressePrincipale.Rue = "RueTest";
            //user.AdressePrincipale.Ville = "VilleTest";
            //user.AdressePrincipale.Province = "ProvinceTest";
            //user.AdressePrincipale.Pays = "PaysTest";
            //user.AdressePrincipale.CodePostal = "CodePostalTest";
            var stripeCustomerId = await CreateStripeCustomer(user.Email, $"{user.Prenom} {user.Nom}" /*, user.AdressePrincipale.Rue, user.AdressePrincipale.Ville, user.AdressePrincipale.Province, user.AdressePrincipale.CodePostal, user.AdressePrincipale.Pays*/);
            // Stocker l'ID de client Stripe dans votre base de données
            ((Membre)user).StripeCustomerId = stripeCustomerId;

            //Stocker l'ID de client Stripe dans un claim pour l'utiliser plus tard
            var claim = new Claim("StripeCustomerId", stripeCustomerId);

            var result = await _userManager.CreateAsync(user, vm.Password);
            // Si l'utilisateur est créé avec succès, connectez-vous.
            if (result.Succeeded)
            {
                //Générer l'email de confirmatuion et l'envoyer
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action(
                    "ConfirmEmail", "Compte",
                    new { userId = user.Id, code },
                    Request.Scheme);

                // Récupérer l'URL complète du logo à partir de l'application
                var logoUrl =
                    Url.Content("http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");

                await _sendGridEmail.SendEmailAsync(user.Email,
                    "\"La Fourmie Aillée- Demande de confirmer ton incription",
                    "<div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>" +
                    "<img src='" + logoUrl +
                    "' alt='Logo Fourmie Aillée' style='width:250px;height:auto; display: block; margin: 0 auto;'>\n" +
                    "<h2 style='color: #444;'>Cher membre,</h2>\n" +
                    "<p>Nous avons reçu une demande d'inscription. Pour continuer ce processus, veuillez cliquer sur le bouton ci-dessous.</p>\n" +
                    "<p style='text-align: center; margin: 20px 0;'><a href='" + callbackUrl +
                    "' style='background-color: #007BFF; color: white; padding: 10px 20px; text-decoration: none; border-radius: 3px;'>Confirmer l'inscription</a></p>\n" +
                    "<p>Si vous n'avez pas demandé cette inscription, veuillez ignorer ce message ou contacter notre support client pour plus d'assistance.</p>\n" +
                    "<p style='color: #666; border-top: 1px solid #ddd; padding-top: 10px;'>Cordialement<br></p>" +
                    "</div>");
                // Ajouter le rôle à l'utilisateur
                await _userManager.AddToRoleAsync(user, role);

                // Stocker le code de réinitialisation dans la session
                HttpContext.Session.SetString("inscriptionCode", code);
                HttpContext.Session.SetString("userId", user.Id);
                return Ok(
                    "Votre requête a été soumise avec succès, veuillez vérifier votre boîte de réception pour confirmer votre incsription.");
            }

            // Sinon, affichez les erreurs.
            foreach (var error in result.Errors) ModelState.AddModelError("", error.Description);
        }

        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest") return PartialView("_RegisterForm", vm);

        // Retourne la vue avec le modèle d'inscription si l'état du modèle est invalide.
        return View(vm);
    }

    [HttpGet]
    public IActionResult ConfirmEmail(string userid, string code)
    {
        var user = _context.Users.First(user => user.Id == userid);
        if (user == null) return BadRequest();
        if (_userManager.ConfirmEmailAsync(user, code).IsFaulted) return BadRequest();
        user.EmailConfirmed = true;
        _signInManager.SignInAsync(user, false);
        return RedirectToAction("Login", "Compte");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Compte");
    }

    [Authorize(Roles = RoleName.ADMIN + "," + RoleName.MEMBRE)]
    public async Task<ActionResult> RecuperationMDP(string id)
    {
        var user = new ApplicationUser();

        if (string.IsNullOrEmpty(id)) return NotFound();

        user = await _userManager.FindByIdAsync(id);

        if (user == null) return NotFound();

        var vm = new FindPWD();

        vm.Id = _userManager.GetUserId(User);
        if (id != vm.Id) return Content("Vous ne pouvez pas modifier le mot de passe des autres!");


        return View(vm);
    }


    [HttpGet]
    public IActionResult ForgotPassword()
    {
        ForgotPasswordVM vm = new ForgotPasswordVM();
        vm.Email = "";
        return View(vm);
    }

    //ForgotPassword: Cette méthode vérifie d'abord si le modèle est valide. Si le modèle est invalide, elle retourne la vue avec le modèle invalide. Sinon, elle trouve l'utilisateur correspondant à l'adresse e-mail fournie, génère un code de réinitialisation de mot de passe, envoie un e-mail contenant le code
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
    {
        if (!ModelState.IsValid)
            // Si le modèle n'est pas valide, afficher la vue avec le modèle invalide
            return View(model);

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty,
                "Il y a un problème avec l'adresse courriel ou cet utilisateur n'existe pas.");
            return BadRequest("Il y a un problème avec l'adresse courriel ou cet utilisateur n'existe pas.");
        }

        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        var callbackUrl = Url.Action("ResetPassword", "Compte", new { userId = user.Id, code },
            HttpContext.Request.Scheme); //Ici je passe le code de réinitialisation en paramètre de l'URL

        // Récupérer l'URL complète du logo à partir de l'application
        var logoUrl = Url.Content("http://ivoxcommunication.com/v2/wp-content/uploads/2023/09/Logo_sans_fond.png");

        await _sendGridEmail.SendEmailAsync(
            model.Email,
            "La Fourmie Aillée- Demande de réinitialisation de votre mot de passe",
            "<div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>" +
            "<img src='" + logoUrl +
            "' alt='Logo Fourmie Aillée' style='width:250px;height:auto; display: block; margin: 0 auto;'>\n" +
            "<h2 style='color: #444;'>Cher utilisateur,</h2>\n" +
            "<p>Nous avons reçu une demande de réinitialisation de votre mot de passe pour votre compte . Pour continuer ce processus, veuillez cliquer sur le bouton ci-dessous.</p>\n" +
            "<p style='text-align: center; margin: 20px 0;'><a href='" + callbackUrl +
            "' style='background-color: #007BFF; color: white; padding: 10px 20px; text-decoration: none; border-radius: 3px;'>Réinitialiser le mot de passe</a></p>\n" +
            "<p>Si vous n'avez pas demandé cette réinitialisation, veuillez ignorer ce message ou contacter notre support client pour plus d'assistance.</p>\n" +
            "<p style='color: #666; border-top: 1px solid #ddd; padding-top: 10px;'>Cordialement<br></p>" +
            "</div>"
        );
        // Stocker le code de réinitialisation dans la session
        HttpContext.Session.SetString("resetCode", code);

        return Ok(
            "Votre requête a été soumise avec succès, veuillez vérifier votre boîte de réception pour réinitialiser votre mot de passe.");
    }


    [HttpGet]
    public IActionResult ResetPassword(string code = null)
    {
        var resetCode = HttpContext.Session.GetString("resetCode");
        if (resetCode == null || resetCode != code)
            // Si le code est invalide, afficher la vue d'erreur
            return RedirectToAction("Index", "Accueil", new MessageVM(
                "Bloqué!",
                "Le code de réinitialisation de mot de passe est invalide."));

        // Si le code est valide, stocker la valeur de resetCode dans ViewBag pour la récupérer dans le post
        ViewBag.ResetCode = resetCode;

        // Afficher la vue de réinitialisation de mot de passe
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordVM model, string? resetCode)
    {
        if (!ModelState.IsValid)
            // Si le modèle n'est pas valide, afficher la vue avec le modèle invalide
            return View(model);

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid request");
            return View(model);
        }

        // Récupérer la valeur de resetCode depuis la session
        var code = HttpContext.Session.GetString("resetCode");

        // Réinitialiser le mot de passe de l'utilisateur avec le code de réinitialisation et le nouveau mot de passe
        if (code != null)
        {
            var result = await _userManager.ResetPasswordAsync(user, code, model.Password);
            if (result.Succeeded)
            {
                // Supprimer la valeur de resetCode de la session
                HttpContext.Session.Remove("resetCode");

                // Stocker un message de confirmation de réinitialisation de mot de passe dans TempData
                TempData["ResetPasswordConfirmation"] = true;

                // Rediriger vers la page de connexion
                return RedirectToAction("Login", "Compte");
            }

            // Si la réinitialisation du mot de passe a échoué, ajouter les erreurs à ModelState
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
        }

        // Afficher la vue avec le modèle invalide
        return View(model);
    }


    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public IActionResult ExternalLogin(string provider, string returnurl = null)
    {
        var redirect = Url.Action("ExternalLoginCallback", "Compte", new { returnurl });
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirect);
        return Challenge(properties, provider);
    }

    [HttpGet]
    public async Task<IActionResult> ExternalLoginCallback(string returnurl = null, string remoteError = null)
    {
        //If there is an error in the external login, return a message
        if (remoteError != null)
        {
            ModelState.AddModelError(string.Empty, "Error from external provider");
            return RedirectToAction("Index", "Accueil", new MessageVM(
                "Échec de connection externe",
                remoteError));
        }

        //Get the external login info
        var info = await _signInManager.GetExternalLoginInfoAsync();
        //If there is no login info, redirect to the sign in page
        if (info == null) return RedirectToAction("Login");
        //Try to sign in the user using the login info
        var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
        //If the sign in is successful, update the external authentication tokens and redirect to the return url
        if (result.Succeeded)
        {
            await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
            return LocalRedirect(returnurl);
        }

        //Si l'utilisateur n'a pas de compte, montrez-lui la page ExternalLoginConfirmation
        ViewData["ReturnUrl"] = returnurl;
        ViewData["ProviderDisplayName"] = info.ProviderDisplayName;
        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        return View("ExternalLoginConfirmation", new ExternalLoginVM { Email = email });
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginVM vm, string? returnurl = null)
    {
        returnurl = returnurl ?? Url.Content("~/");

        if (ModelState.IsValid)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Tentative de connexion non valide.");
                return View(vm);
            }

            var user = new ApplicationUser { UserName = vm.Email, Email = vm.Email };
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                //await _userManager.AddToRoleAsync(user, RoleName.Admin);
                result = await _userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                    return
                        LocalRedirect(
                            returnurl); //va saisir l'url et elle va etre redirigée de cette façon au lieu de la retourner comme une vue
                }
            }

            ModelState.AddModelError("Email", "Cet utilisateur existe déjà.");
        }

        ViewData["ReturnUrl"] = returnurl;
        return View(vm);
    }

    public async Task<string> CreateStripeCustomer(string email, string name)
    {
        var options = new CustomerCreateOptions
        {
            Email = email,
            Name = name,
            //Address = new AddressOptions
            //{
            //    Line1 = line1,
            //    City = city,
            //    State = state,
            //    PostalCode = postalCode,
            //    Country = country
            //}
        };

        var service = new CustomerService();
        var customer = await service.CreateAsync(options);
        return customer.Id;
    }
}