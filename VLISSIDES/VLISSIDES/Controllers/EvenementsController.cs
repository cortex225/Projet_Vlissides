using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Evenements;

namespace VLISSIDES.Controllers
{
    public class EvenementsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EvenementsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, IConfiguration config, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var evenements = _context.Evenements.Include(e => e.Reservations).Select(e => new EvenementsIndexVM
            {
                Id = e.Id,
                Nom = e.Nom,
                Description = e.Description,
                DateDebut = e.DateDebut,
                DateFin = e.DateFin,
                Image = e.Image,
                Lieu = e.Lieu,
                NbPlaces = e.Reservations == null ? e.NbPlaces.ToString() + "/" + e.NbPlaces.ToString() : (e.NbPlaces - e.Reservations.Count).ToString() + "/" + e.NbPlaces.ToString(),
                NbPlacesMembre = e.Reservations == null ? e.NbPlacesMembre.ToString() + "/" + e.NbPlacesMembre.ToString() : (e.NbPlacesMembre - e.Reservations.Count()).ToString() + "/" + e.NbPlacesMembre.ToString(),
                Prix = e.Prix,
            }
            ).ToList();
            return View(evenements);
        }


    }
}
