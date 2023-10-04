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
        public IActionResult ModifierInformation()
        {
            var userId = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
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
            return View(vm);
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
                    _context.SaveChanges();

                }


                return PartialView("PartialViews/Profile/_ProfilePartial", vm);
            }
            return PartialView("PartialViews/Profile/_ProfilePartial", vm);
        }
        public IActionResult ModifierPassword()
        {
            var vm = new ProfilePasswordVM()
            {
                Id = _userManager.GetUserId(HttpContext.User)
            };
            return PartialView("PartialViews/Profile/_ModifierPasswordPartial", vm);
        }
        [HttpPost]
        [Route("2167594/Profile/ModifierPassword")]
        [Route("{controller}/{action}")]
        public IActionResult ModifierPassword(ProfilePasswordVM vm)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == vm.Id);
            }
        }
    }
}
