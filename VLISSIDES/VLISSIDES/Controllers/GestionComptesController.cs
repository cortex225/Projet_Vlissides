using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public GestionComptesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
        IConfiguration config, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
            _userManager = userManager;
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
        public IActionResult ShowMembres()
        {
            var Membres = _context.Membres.Select(m => new GestionComptesMembreVM
            {
                Id = m.Id,
                Nom = m.UserName,
                Courriel = m.Email
            }).ToList();
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
    }
}
