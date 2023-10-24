using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionComptes;

namespace VLISSIDES.Controllers
{
    public class GestionComptesController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GestionComptesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
        IConfiguration config, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            var Membres = _context.Membres.Select(m => new GestionComptesMembreVM
            {
                Id = m.Id,
                Nom = m.UserName,
                Courriel = m.Email
            }).ToList();

            return View(Membres);
        }
        public IActionResult ShowMembres(string? motCle)
        {
            var Membres = _context.Membres.Select(m => new GestionComptesMembreVM
            {
                Id = m.Id,
                Nom = m.UserName,
                Courriel = m.Email
            }).ToList();
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
            var Employes = _context.Employes.Select(e => new GestionComptesEmployeVM
            {
                Id = e.Id,
                Nom = e.UserName,
                Courriel = e.Email
            }).ToList();
            return PartialView("PartialViews/GestionComptes/_ListeEmployePartial", Employes);
        }
        public IActionResult ShowAdmins()
        {
            //Il y a seulement un admin
            var Admin = _context.Users.Where(u => u.Id == "0").Select(u => new GestionComptesAdminVM
            {
                Id = u.Id,
                Nom = u.UserName,
                Courriel = u.Email
            }).ToList();
            return PartialView("PartialViews/GestionComptes/_ListeAdminPartial", Admin);
        }
        #region Confirmation de supprimer
        public IActionResult ShowDeleteConfirmationMembre(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            var userCourant = _userManager.FindByIdAsync(_userManager.GetUserId(HttpContext.User)).Result;
            var vm = new GestionComptesDeleteVM { Id = user.Id, Nom = user.UserName };
            if (user == userCourant)
            {
                return PartialView("PartialViews/Modals/Comptes/_ErreurCompteUtilisePartial", vm);
            }


            return PartialView("PartialViews/Modals/Comptes/_DeleteMembrePartial", vm);
        }
        public IActionResult ShowDeleteConfirmationEmploye(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            var vm = new GestionComptesDeleteVM { Id = user.Id, Nom = user.UserName };

            return PartialView("PartialViews/Modals/Comptes/_DeleteEmployePartial", vm);
        }
        public IActionResult ShowDeleteConfirmationAdmin(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            var vm = new GestionComptesDeleteVM { Id = user.Id, Nom = user.UserName };

            return PartialView("PartialViews/Modals/Comptes/_DeleteAdminPartial", vm);
        }
        #endregion
        [HttpPost]
        public IActionResult SupprimerCompte(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();
            else
            {
                //_context.Users.Remove(user);
                _userManager.DeleteAsync(user);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
