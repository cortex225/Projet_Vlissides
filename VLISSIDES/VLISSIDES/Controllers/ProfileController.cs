﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Profile;

namespace VLISSIDES.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = _userManager.FindByIdAsync(userId).Result;

            var vm = new ProfileIndexVM
            {
                ProfileModifierInformationVM = new ProfileModifierInformationVM
                {
                    Prenom = user.Prenom,
                    Nom = user.Nom,
                    NomUtilisateur = user.UserName,
                    DateNaissance = user.DateNaissance,
                    Courriel = user.Email,
                    Id = user.Id,
                    Telephone = user.PhoneNumber
                }
            };
            return View(vm);
        }
        [Route("2167594/Profile/ModifierInformation")]
        [Route("{controller}/{action}")]
        public IActionResult ModifierInformation()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = _userManager.FindByIdAsync(userId).Result;


            var vm = new ProfileModifierInformationVM
            {
                Prenom = user.Prenom,
                Nom = user.Nom,
                NomUtilisateur = user.UserName,
                DateNaissance = user.DateNaissance,
                Courriel = user.Email,
                Id = user.Id,
                Telephone = user.PhoneNumber
            };
            return PartialView("PartialViews/Profile/_ProfilePartial", vm);
        }
        [HttpPost]
        [Route("2167594/Profile/ModifierInformation")]
        [Route("{controller}/{action}")]
        public IActionResult ModifierInformation(ProfileModifierInformationVM vm)
        {
            var indexVM = new ProfileIndexVM { ProfileModifierInformationVM = vm };
            if (_context.Users.FirstOrDefault(u => u.UserName == vm.NomUtilisateur) != null)
            {
                ModelState.AddModelError("NomUtilisateur", "Le nom d'utilisateur est déjà pris");
            }
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == vm.Id);
                var userM = _userManager.Users.FirstOrDefault(u => u.Id == vm.Id);

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


                    _context.SaveChanges();

                }

                return View("Index", indexVM);
            }

            return View("Index", indexVM);
        }
        [Route("2167594/Profile/ModifierPassword")]
        [Route("{controller}/{action}")]
        public IActionResult ModifierPassword()
        {
            var vm = new ProfileModifierPasswordVM()
            {
                Id = _userManager.GetUserId(HttpContext.User)
            };
            return PartialView("PartialViews/Profile/_ModifierPasswordPartial", vm);
        }
        [HttpPost]
        [Route("2167594/Profile/ModifierPassword")]
        [Route("{controller}/{action}")]
        public IActionResult ModifierPassword(ProfileModifierPasswordVM vm)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == vm.Id);
                var passswordVerificationResult = new PasswordHasher<ApplicationUser>().VerifyHashedPassword(user, user.PasswordHash, vm.Password);
                if (passswordVerificationResult == PasswordVerificationResult.Failed)
                {
                    ModelState.AddModelError("Password", "Mot de passe actuel erroné");
                }
                if (vm.NewPassword != vm.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "La confirmation du mot de passe n'est pas correcte");
                }
                if (ModelState.IsValid)
                {
                    user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, vm.NewPassword);
                    _context.SaveChanges();

                }

            }
            return PartialView("PartialViews/Profile/_ModifierPasswordPartial", vm);
        }
        public IActionResult ModifierAdresses()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            //var user = _userManager.FindByIdAsync(userId).Result;
            var user = _context.Users.Include(x => x.AdressePrincipale).FirstOrDefault(u => u.Id == userId);
            ProfileModifierAdressesVM vm;
            if (user.AdressePrincipale != null)
            {
                vm = new ProfileModifierAdressesVM
                {
                    Id = user.Id,
                    //AdressePrincipale = user.AdressePrincipale,
                    NoCivique = user.AdressePrincipale.NoCivique,
                    Rue = user.AdressePrincipale.Rue,
                    CodePostal = user.AdressePrincipale.CodePostal,
                    Pays = user.AdressePrincipale.Pays,
                    Province = user.AdressePrincipale.Province,
                    Ville = user.AdressePrincipale.Ville,


                };
                if (user.AdressePrincipale.NoApartement != null)
                {
                    vm.NoApartement = user.AdressePrincipale.NoApartement;
                }
            }
            else
            {
                vm = new ProfileModifierAdressesVM() { Id = user.Id };
            }

            if (user.AdressesLivraison != null)
            {
                vm.AdressesDeLivraison = user.AdressesLivraison.ToList();
            }

            return PartialView("PartialViews/Profile/_ProfileAdressesPartial", vm);
        }
        [HttpPost]
        public IActionResult ModifierAdresses(ProfileModifierAdressesVM vm)
        {
            if (ModelState.IsValid)
            {
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
                        NoApartement = vm.NoApartement,
                        CodePostal = vm.CodePostal,
                        Ville = vm.Ville,
                        Province = vm.Province,
                        Pays = vm.Pays,

                    };
                    user.AdressePrincipaleId = id;
                    _context.SaveChanges();
                }
                else
                {
                    user.AdressePrincipale.NoCivique = vm.NoCivique;
                    user.AdressePrincipale.Rue = vm.Rue;
                    user.AdressePrincipale.NoApartement = vm.Rue;
                    user.AdressePrincipale.CodePostal = vm.CodePostal;
                    user.AdressePrincipale.Ville = vm.Ville;
                    user.AdressePrincipale.Province = vm.Province;
                    user.AdressePrincipale.Pays = vm.Pays;


                    _context.SaveChanges();
                }
            }

            return PartialView("PartialViews/Profile/_ProfileAdressesPartial", vm);
        }
    }
}
