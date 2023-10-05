using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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


                return RedirectToAction("Index");
            }
            return View(vm);
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
            var user = _userManager.FindByIdAsync(userId).Result;


            return PartialView();
        }
    }
}
