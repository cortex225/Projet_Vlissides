using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionComptes;

namespace VLISSIDES.Controllers
{
    [Authorize(Roles = RoleName.ADMIN)]
    public class GestionComptesController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GestionComptesController(SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
        IConfiguration config, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index() => View(_context.Membres.Select(m => new GestionComptesMembreVM(m)).ToList());
        #region Lister les comptes
        public IActionResult ShowMembres(string? motCle)
        {
            var Membres = _context.Membres.Select(m => new GestionComptesMembreVM(m)).ToList();
            if (motCle != null && motCle != "")
            {
                Membres = Membres
                    .Where(membre => Regex.IsMatch(membre.Nom, ".*" + motCle + ".*", RegexOptions.IgnoreCase))
                    .ToList();
            }

            return PartialView("PartialViews/GestionComptes/_ListeMembrePartial", Membres);
        }
        public IActionResult ShowEmployes()
        {
            var Employes = _context.Employes.Select(e => new GestionComptesEmployeVM(e)).ToList();
            return PartialView("PartialViews/GestionComptes/_ListeEmployePartial", Employes);
        }
        public IActionResult ShowAdmins()
        {
            //Il y a seulement un admin
            var Admin = _context.Users.Where(u => u.Id == "0").Select(u => new GestionComptesAdminVM(u)).ToList();
            return PartialView("PartialViews/GestionComptes/_ListeAdminPartial", Admin);
        }
        #endregion
        #region Ajouter Employe
        public IActionResult ShowAjouterEmploye() => PartialView("PartialViews/Modals/Comptes/_AjouterEmployePartial",
            new GestionComptesAjouterEmployeVM());
        [HttpPost]
        public async Task<IActionResult> AjouterEmploye(GestionComptesAjouterEmployeVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Password != vm.PasswordConfirmed)
                {
                    ModelState.AddModelError("PasswordConfirmed", "Le mot de passe confirmé ne correspond pas au mot de passe");
                    return PartialView("PartialViews/Modals/Comptes/_AjouterEmployePartial", vm);
                }
                if (_context.Users.FirstOrDefault(u => u.UserName == vm.Username) != null)
                {

                    ModelState.AddModelError("Username", "Le nom d'utilisateur existe déjà");
                    return PartialView("PartialViews/Modals/Comptes/_AjouterEmployePartial", vm);

                }
                if (_context.Users.FirstOrDefault(u => u.Email == vm.Email) != null)
                {
                    ModelState.AddModelError("Email", "L'adresse courriel existe déjà");
                    return PartialView("PartialViews/Modals/Comptes/_AjouterEmployePartial", vm);
                }
                var Employe = new Employe()
                {
                    Id = Guid.NewGuid().ToString(),
                    NoEmploye = "E" + DateTime.Now.ToString("MM/dd/yyyy") + (_context.Employes.Count() + 1),
                    Nom = vm.Nom,
                    Prenom = vm.Prenom,
                    UserName = vm.Username,
                    Email = vm.Email,
                    PhoneNumber = vm.Telephone,
                    NormalizedUserName = vm.Username.ToUpper(),
                    NormalizedEmail = vm.Email.ToUpper(),

                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };
                var result = await _userManager.CreateAsync(Employe, vm.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(Employe, RoleName.EMPLOYE);
                    return Ok();
                }
                else
                {
                    ModelState.AddModelError("Password", "Mot de passe faible :  Veuillez avoir minimum 6 caractères minuscules et majuscules, au moins un chiffre et un caractère spécial");
                    return PartialView("PartialViews/Modals/Comptes/_AjouterEmployePartial", vm);
                }

            }

            return PartialView("PartialViews/Modals/Comptes/_AjouterEmployePartial", vm);
        }
        #endregion
        public async Task<IActionResult> ShowModifierCompteMembre(string id)
        {
            var user = await _context.Membres.FindAsync(id);
            if (user == null) return NotFound("Le membre à l'identifiant " + id + " n'a pas été trouvé.");

            return PartialView("PartialViews/Modals/Comptes/_ModifierCompteMembrePartial",
                new GestionComptesModifierVM(user));
        }
        public async Task<IActionResult> ShowModifierCompteEmploye(string id)
        {
            var user = await _context.Employes.FindAsync(id);
            if (user == null) return NotFound("L'employe à l'identifiant " + id + " n'a pas été trouvé.");
            return PartialView("PartialViews/Modals/Comptes/_ModifierCompteEmployePartial", new GestionComptesModifierVM(user));
        }
        [HttpPost]
        public async Task<IActionResult> ModifierCompteMembre(GestionComptesModifierVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Password != vm.PasswordConfirmed)
                {
                    ModelState.AddModelError("PasswordConfirmed", "Le mot de passe confirmé ne correspond pas au mot de passe");
                    return PartialView("PartialViews/Modals/Comptes/_ModifierCompteMembrePartial", vm);
                }
                var user = _context.Users.FirstOrDefault(u => u.Id == vm.Id);
                if (user == null)
                {
                    return NotFound();
                }
                if (user.UserName != vm.Username)
                {
                    if (_context.Users.FirstOrDefault(u => u.UserName == vm.Username) != null)
                    {

                        ModelState.AddModelError("Username", "Le nom d'utilisateur existe déjà");
                        return PartialView("PartialViews/Modals/Comptes/_ModifierCompteMembrePartial", vm);

                    }
                }
                if (user.Email != vm.Email)
                {
                    if (_context.Users.FirstOrDefault(u => u.Email == vm.Email) != null)
                    {
                        ModelState.AddModelError("Email", "L'adresse courriel existe déjà");
                        return PartialView("PartialViews/Modals/Comptes/_ModifierCompteMembrePartial", vm);
                    }

                }

                //Modification du mot de passe si applicable
                if (vm.Password != null && vm.PasswordConfirmed != null)
                {
                    if (Regex.Match(vm.Password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{6,}$").Success)
                    {
                        await _userManager.RemovePasswordAsync(user);
                        await _userManager.AddPasswordAsync(user, vm.Password);
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Mot de passe faible :  Veuillez avoir minimum 6 caractères minuscules et majuscules, au moins un chiffre et un caractère spécial");
                        return PartialView("PartialViews/Modals/Comptes/_ModifierCompteMembrePartial", vm);
                    }


                }
                //Modification
                user.Nom = vm.Nom;
                user.Prenom = vm.Prenom;
                user.UserName = vm.Username;
                user.NormalizedUserName = vm.Username.ToUpper();
                user.NormalizedEmail = vm.Email.ToUpper();
                user.Email = vm.Email;
                user.PhoneNumber = vm.Telephone;
                //Sauvegarde les changements
                await _context.SaveChangesAsync();

                return Ok();
            }
            return PartialView("PartialViews/Modals/Comptes/_ModifierCompteMembrePartial", vm);
        }
        [HttpPost]
        public async Task<IActionResult> ModifierCompteEmploye(GestionComptesModifierVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Password != vm.PasswordConfirmed)
                {
                    ModelState.AddModelError("PasswordConfirmed", "Le mot de passe confirmé ne correspond pas au mot de passe");
                    return PartialView("PartialViews/Modals/Comptes/_ModifierCompteEmployePartial", vm);
                }
                var user = _context.Users.FirstOrDefault(u => u.Id == vm.Id);
                if (user == null)
                {
                    return NotFound();
                }
                if (user.UserName != vm.Username)
                {
                    if (_context.Users.FirstOrDefault(u => u.UserName == vm.Username) != null)
                    {

                        ModelState.AddModelError("Username", "Le nom d'utilisateur existe déjà");
                        return PartialView("PartialViews/Modals/Comptes/_ModifierCompteEmployePartial", vm);

                    }
                }
                if (user.Email != vm.Email)
                {
                    if (_context.Users.FirstOrDefault(u => u.Email == vm.Email) != null)
                    {
                        ModelState.AddModelError("Email", "L'adresse courriel existe déjà");
                        return PartialView("PartialViews/Modals/Comptes/_ModifierCompteEmployePartial", vm);
                    }

                }

                //Modification du mot de passe si applicable
                if (vm.Password != null && vm.PasswordConfirmed != null)
                {
                    if (Regex.Match(vm.Password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{6,}$").Success)
                    {
                        await _userManager.RemovePasswordAsync(user);
                        await _userManager.AddPasswordAsync(user, vm.Password);
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Mot de passe faible :  Veuillez avoir minimum 6 caractères minuscules et majuscules, au moins un chiffre et un caractère spécial");
                        return PartialView("PartialViews/Modals/Comptes/_ModifierCompteEmployePartial", vm);
                    }


                }
                //Modification
                user.Nom = vm.Nom;
                user.Prenom = vm.Prenom;
                user.UserName = vm.Username;
                user.NormalizedUserName = vm.Username.ToUpper();
                user.NormalizedEmail = vm.Email.ToUpper();
                user.Email = vm.Email;
                user.PhoneNumber = vm.Telephone;
                //Sauvegarde les changements
                await _context.SaveChangesAsync();
                return Ok();
            }
            return PartialView("PartialViews/Modals/Comptes/_ModifierCompteEmployePartial", vm);
        }
        #region Confirmation de supprimer
        public async Task<IActionResult> ShowDeleteConfirmationMembre(string id)
        {
            var user = await _context.Membres.FindAsync(id);
            if (user == null) return NotFound("Le membre à l'identifiant " + id + " n'a pas été trouvé.");

            var userCourant = _userManager.FindByIdAsync(_userManager.GetUserId(HttpContext.User)).Result;
            var vm = new GestionComptesDeleteVM(user);
            if (user == userCourant)
            {
                return PartialView("PartialViews/Modals/Comptes/_ErreurCompteUtilisePartial", vm);
            }


            return PartialView("PartialViews/Modals/Comptes/_DeleteMembrePartial", vm);
        }
        public async Task<IActionResult> ShowDeleteConfirmationEmploye(string id)
        {
            var user = await _context.Employes.FindAsync(id);
            if (user == null) return NotFound("L'employe à l'identifiant " + id + " n'a pas été trouvé.");

            return PartialView("PartialViews/Modals/Comptes/_DeleteEmployePartial", new GestionComptesDeleteVM(user));
        }
        public async Task<IActionResult> ShowDeleteConfirmationAdmin(string id)
        {

            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("L'utilisateur à l'identifiant " + id + " n'a pas été trouvé.");

            return PartialView("PartialViews/Modals/Comptes/_DeleteAdminPartial", new GestionComptesDeleteVM(user));
        }
        #endregion
        [HttpDelete]
        public async Task<IActionResult> SupprimerCompte(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("L'utilisateur à l'identifiant " + id + " n'a pas été trouvé.");

            await _userManager.DeleteAsync(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
        public async Task<IActionResult> ShowBanMembre(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("L'utilisateur à l'identifiant " + id + " n'a pas été trouvé.");
            return PartialView("PartialViews/Modals/Comptes/_BanMemberPartial", new GestionComptesBanVM(user));
        }
        public async Task<IActionResult> ShowUnbanMembre(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound("L'utilisateur à l'identifiant " + id + " n'a pas été trouvé.");
            return PartialView("PartialViews/Modals/Comptes/_UnbanMemberPartial", new GestionComptesBanVM(user));
        }
        [HttpPost]
        public async Task<IActionResult> BanMembre(string id)
        {
            var user = await _context.Membres.FindAsync(id);
            if (user == null) return NotFound("Le membre à l'identifiant " + id + " n'a pas été trouvé.");
            if (user.IsBanned)
            {
                user.IsBanned = false;

            }
            else
            {
                user.IsBanned = true;

                Console.WriteLine(await _userManager.GetSecurityStampAsync(user));


                await _userManager.UpdateSecurityStampAsync(user);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
