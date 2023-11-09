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
                DateDebut = p.DateDebut,
                DateFin = p.DateFin,
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
            if (ModelState.IsValid)
            {
                //Sauvegarder l'image dans root
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
                else
                {
                    vm.CoverImageUrl = "/img/CouvertureLivre/livredefault.png";
                }

                var id = Guid.NewGuid().ToString();

                Promotions promo = new Promotions
                {
                    Id = id,
                    Image = vm.CoverImageUrl,
                    Nom = vm.Nom,
                    Description = vm.Description,
                    CodePromo = vm.CodePromo,
                    DateDebut = vm.DateDebut,
                    DateFin = vm.DateFin,
                    AuteurId = vm.AuteurId,
                    MaisonEditionId = vm.MaisonEditionId,
                    CategorieId = vm.CategorieId,
                    TypePromotion = vm.TypePromotion,
                    LivresAcheter = vm.LivresAcheter,
                    LivresGratuits = vm.LivresGratuits,
                    PourcentageRabais = vm.PourcentageRabais
                };

                _context.Promotions.Add(promo);
                _context.SaveChanges();

                return Ok();
            }

            var VM = new AjouterPromotionVM();
            //Populer les listes déroulantes
            VM.SelectListAuteurs = _context.Auteurs.Select(x => new SelectListItem
            {
                Text = x.NomAuteur,
                Value = x.Id
            }).ToList();
            VM.SelectListMaisonEditions = _context.MaisonEditions.Select(x => new SelectListItem
            {
                Text = x.Nom,
                Value = x.Id
            }).ToList();
            VM.SelectListCategories = _context.Categories.Select(x => new SelectListItem
            {
                Text = x.Nom,
                Value = x.Id
            }).ToList();
            return PartialView("PartialViews/Modals/Promotions/_AjouterPromotionPartial", VM);
        }
    }
}
