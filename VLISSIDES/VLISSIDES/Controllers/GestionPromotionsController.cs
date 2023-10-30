using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionPromotions;

namespace VLISSIDES.Controllers

{
    [Authorize(Roles = RoleName.EMPLOYE + ", " + RoleName.ADMIN)]
    public class GestionPromotionsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GestionPromotionsController(IConfiguration config, ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _config = config;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {

            var vm = _context.Promotions.Select(p => new GestionPromotionsIndexVM
            {
                Id = p.Id,
                Description = p.Description,
                Rabais = p.Rabais,
                DateDebut = p.DateDebut,
                DateFin = p.DateFin,
                Livres = p.Livres,
                Image = p.Image,
            }).ToList();
            return View(vm);
        }
    }
}
