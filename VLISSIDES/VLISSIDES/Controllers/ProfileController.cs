using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Profile;

namespace VLISSIDES.Controllers;
[Authorize(Roles = RoleName.EMPLOYE + ", " + RoleName.ADMIN + ", " + RoleName.MEMBRE)]
public class ProfileController : Controller
{
    private readonly IConfiguration _config;


    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
        IConfiguration config,
        IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _config = config;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index() => View(
        new ProfileIndexVM(_userManager.FindByIdAsync(_userManager.GetUserId(HttpContext.User)).Result));

    [Route("2167594/Profile/ModifierInformation")]
    [Route("{controller}/{action}")]
    public IActionResult ModifierInformation() => PartialView("PartialViews/Profile/_ProfilePartial",
        new ProfileModifierInformationVM(_userManager.FindByIdAsync(_userManager.GetUserId(HttpContext.User)).Result));

    [HttpPost]
    [Route("2167594/Profile/ModifierInformation")]
    [Route("{controller}/{action}")]
    public async Task<IActionResult> ModifierInformation(ProfileModifierInformationVM vm)
    {
        var indexVM = new ProfileIndexVM(vm);
        var userId = _userManager.GetUserId(HttpContext.User);
        var userCourant = await _userManager.FindByIdAsync(userId);
        if (userCourant.UserName != vm.NomUtilisateur)
            if (await _context.Users.FirstOrDefaultAsync(u => u.UserName == vm.NomUtilisateur) != null)
                ModelState.AddModelError("NomUtilisateur", "Le nom d'utilisateur est déjà pris");

        if (ModelState.IsValid)
        {
            if (!Regex.Match(vm.Telephone, "^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$").Success)
            {
                ModelState.AddModelError("Telephone", "Le numéro de téléphone doit avoir le format : 123-456-7890");
                return View("Index", indexVM);
            }
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == vm.Id);
            var userM = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == vm.Id);

            if (user != null)
            {
                user.Prenom = vm.Prenom;
                user.Nom = vm.Nom;
                user.PhoneNumber = vm.Telephone;
                user.DateNaissance = vm.DateNaissance;
                user.Email = vm.Courriel;
                user.NormalizedEmail = vm.Courriel.ToUpper();
                user.UserName = vm.NomUtilisateur;
                user.NormalizedUserName = vm.NomUtilisateur.ToUpper();
                userM.UserName = vm.NomUtilisateur;

                if (vm.CoverPhoto != null)
                {
                    var wwwRootPath = _webHostEnvironment.WebRootPath;
                    var fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
                    var extension = Path.GetExtension(vm.CoverPhoto.FileName);
                    fileName += DateTime.Now.ToString("yyyymmssfff") + extension;
                    vm.CoverImageUrl = _config.GetValue<string>("ImageUrl") + fileName;
                    var path = Path.Combine(wwwRootPath + _config.GetValue<string>("ImageUrl"), fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await vm.CoverPhoto.CopyToAsync(fileStream);
                    }
                }

                userM.CoverImageUrl = vm.CoverImageUrl;

                await _context.SaveChangesAsync();
            }

            return View("Index", indexVM);
        }

        return View("Index", indexVM);
    }

    [Route("2167594/Profile/ModifierPassword")]
    [Route("{controller}/{action}")]
    public IActionResult ModifierPassword() => PartialView("PartialViews/Profile/_ModifierPasswordPartial",
        new ProfileModifierPasswordVM(_userManager.GetUserId(HttpContext.User)));

    [HttpPost]
    [Route("2167594/Profile/ModifierPassword")]
    [Route("{controller}/{action}")]
    public IActionResult ModifierPassword(ProfileModifierPasswordVM vm)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == vm.Id);
            var passswordVerificationResult =
                new PasswordHasher<ApplicationUser>().VerifyHashedPassword(user, user.PasswordHash, vm.MotDePasse);
            if (passswordVerificationResult == PasswordVerificationResult.Failed)
                ModelState.AddModelError("Password", "Mot de passe actuel erroné");

            if (vm.NouveauMotDePasse != vm.MotDePasseConfirme)
                ModelState.AddModelError("ConfirmPassword", "La confirmation du mot de passe n'est pas correcte");

            if (ModelState.IsValid)
            {
                user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, vm.NouveauMotDePasse);
                _context.SaveChanges();
            }
        }

        return PartialView("PartialViews/Profile/_ModifierPasswordPartial", vm);
    }

    public IActionResult ModifierAdresses() =>
        PartialView("PartialViews/Profile/_ProfileAdressesPartial",
            new ProfileModifierAdressesVM(_context.Users.Include(x => x.AdressePrincipale)
                .Include(x => x.AdressesLivraison)
                .FirstOrDefault(u => u.Id == _userManager.GetUserId(HttpContext.User)))
            );

    [HttpPost]
    public IActionResult ModifierAdressePrincipale(ProfileModifierAdressesVM vm)
    {
        if (ModelState.IsValid)
        {
            if (!Regex.Match(vm.CodePostal, "^[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] [0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]$").Success)
            {
                ModelState.AddModelError("CodePostal", "Le code postal doit avoir le format : A2A 2A2");
                return PartialView("PartialViews/Profile/_ProfileAdressesPartial", vm);
            }
            var user = _context.Users.Include(u => u.AdressePrincipale)
                .FirstOrDefault(u => u.Id == vm.Id);
            if (user.AdressePrincipale == null)
            {
                var id = Guid.NewGuid().ToString();
                user.AdressePrincipale = new Adresse
                {
                    Id = id,
                    NoCivique = vm.NoCivique,
                    Rue = vm.Rue,
                    NoApartement = vm.NoApartement != null ? vm.NoApartement : null,
                    CodePostal = vm.CodePostal,
                    Ville = vm.Ville,
                    Province = vm.Province,
                    Pays = vm.Pays
                };
                user.AdressePrincipaleId = id;
                _context.SaveChanges();
            }
            else
            {
                user.AdressePrincipale.NoCivique = vm.NoCivique;
                user.AdressePrincipale.Rue = vm.Rue;
                user.AdressePrincipale.NoApartement = vm.NoApartement != null ? vm.NoApartement : null;
                user.AdressePrincipale.CodePostal = vm.CodePostal;
                user.AdressePrincipale.Ville = vm.Ville;
                user.AdressePrincipale.Province = vm.Province;
                user.AdressePrincipale.Pays = vm.Pays;


                _context.SaveChanges();
            }
        }

        return PartialView("PartialViews/Profile/_ProfileAdressesPartial", vm);
    }

    [HttpPost]
    public async Task<IActionResult> EnleverAdressesLivraison(string? id)
    {
        var adresse = await _context.Adresses.FindAsync(id);
        if (adresse == null) return NotFound("L'adresse à l'identifiant " + id + " n'a pas été trouvé.");

        _context.Adresses.Remove(adresse);
        _context.SaveChanges();
        return PartialView("PartialViews/Profile/_ProfileAdressesPartial",
            new ProfileModifierAdressesVM(
                _context.Users.Include(x => x.AdressePrincipale)
                .Include(x => x.AdressesLivraison)
                .FirstOrDefault(u => u.Id == _userManager.GetUserId(HttpContext.User)))
            );
    }
}