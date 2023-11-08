using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionPromotions;
using VLISSIDES.ViewModels.Livres;

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

        [Route("2147186/GestionPromotions/AjouterPromotion")]
        public IActionResult AjouterPromotion()
        {
            var vm = new AjouterPromotionVM();
            //Populer les listes déroulantes
            vm.SelectListAuteurs = _context.Auteurs.Select(x => new SelectListItem
            {
                Text = x.NomAuteur,
                Value = x.Id
            }).ToList();
            vm.SelectListMaisonEditions = _context.MaisonEditions.Select(x => new SelectListItem
            {
                Text = x.Nom,
                Value = x.Id
            }).ToList();
            vm.SelectListCategories = _context.Categories.Select(x => new SelectListItem
            {
                Text = x.Nom,
                Value = x.Id
            }).ToList();
            return PartialView("PartialViews/Modals/Promotions/_AjouterPromotionPartial", vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("2147186/GestionPromotions/AjouterPromotion")]
        [Route("{controller}/{action}")]
        public async Task<IActionResult> AjouterPromotion(AjouterPromotionVM vm)
        {


            return PartialView("PartialViews/Modals/Promotions/_AjouterPromotionPartial");
        }
    }
}
