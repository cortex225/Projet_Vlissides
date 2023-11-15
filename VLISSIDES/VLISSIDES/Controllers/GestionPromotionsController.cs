using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stripe;
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
                Rabais = (decimal)p.PourcentageRabais
            }).ToList();
            return View(vm);
        }

        [Route("2147186/GestionPromotions/AjouterPromotion")]
        public IActionResult AjouterPromotion()
        {
            var vm = new AjouterPromotionVM();

            vm.action = "Ajouter";

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

                // Création de la promotion dans Stripe
                await CreerPromotionStripe(vm);

                _context.Promotions.Add(promo);
                _context.SaveChanges();

                return Ok();
            }

            var VM = new AjouterPromotionVM();

            VM.action = "Ajouter";

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



        private async Task CreerPromotionStripe(AjouterPromotionVM vm)
        {


            switch (vm.TypePromotion)
            {
                case "pourcentage":
                    await CreerCouponPourcentage(vm);
                    break;
                case "2pour1":
                    await CreerPromotion2Pour1(vm);
                    break;
                default:
                    // Gérer les autres types de promotions ou les erreurs
                    break;
            }
        }

        private async Task CreerCouponPourcentage(AjouterPromotionVM vm)
        {
            var metadata = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(vm.CategorieId))
            {
                metadata.Add("CategorieId", vm.CategorieId);
            }
            if (!string.IsNullOrEmpty(vm.AuteurId))
            {
                metadata.Add("AuteurId", vm.AuteurId);
            }
            if (!string.IsNullOrEmpty(vm.MaisonEditionId))
            {
                metadata.Add("MaisonEditionId", vm.MaisonEditionId);
            }
            var options = new CouponCreateOptions
            {
                Name = vm.Nom,
                PercentOff = vm.PourcentageRabais,
                Currency = "cad",
                Metadata = metadata,

            };

            var service = new CouponService();
            var coupon = await service.CreateAsync(options);
            await CreerCodePromotionnelStripe(coupon.Id, vm.CodePromo);
        }

        private async Task CreerPromotion2Pour1(AjouterPromotionVM vm)
        {
            var metadata = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(vm.CategorieId))
            {
                metadata.Add("CategorieId", vm.CategorieId);
            }
            if (!string.IsNullOrEmpty(vm.AuteurId))
            {
                metadata.Add("AuteurId", vm.AuteurId);
            }
            if (!string.IsNullOrEmpty(vm.MaisonEditionId))
            {
                metadata.Add("MaisonEditionId", vm.MaisonEditionId);
            }


            var options = new CouponCreateOptions
            {
                Name = vm.Nom,
                Metadata = metadata,
                AmountOff = 100,
                Currency = "cad"


            };

            var service = new CouponService();
            var coupon2Pour1 = await service.CreateAsync(options);
            await CreerCodePromotionnelStripe(coupon2Pour1.Id, vm.CodePromo);
        }

        private async Task CreerCodePromotionnelStripe(string couponId, string codePromo)
        {
            var options = new PromotionCodeCreateOptions
            {
                Coupon = couponId,
                Code = codePromo,
                Active = true,
            };

            var service = new PromotionCodeService();
            await service.CreateAsync(options);
        }



        [Route("2147186/GestionPromotions/ModifierPromotion")]
        public IActionResult ModifierPromotion(string id)
        {
            Promotions promo = _context.Promotions.Find(id);

            var vm = new AjouterPromotionVM();

            vm.action = "Modifier";

            vm.Id = id;
            vm.CoverImageUrl = promo.Image;
            vm.Nom = promo.Nom;
            vm.Description = promo.Description;
            vm.CodePromo = promo.CodePromo;
            vm.DateDebut = promo.DateDebut;
            vm.DateFin = promo.DateFin;
            vm.AuteurId = promo.AuteurId;
            vm.MaisonEditionId = promo.MaisonEditionId;
            vm.CategorieId = promo.CategorieId;
            vm.TypePromotion = promo.TypePromotion;
            vm.LivresAcheter = promo.LivresAcheter;
            vm.LivresGratuits = promo.LivresGratuits;
            vm.PourcentageRabais = promo.PourcentageRabais;

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
        [Route("2147186/GestionPromotions/ModifierPromotion")]
        [Route("{controller}/{action}")]
        public async Task<IActionResult> ModifierPromotion(AjouterPromotionVM vm)
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

                Promotions? maPromo = _context.Promotions.Find(vm.Id);

                if (maPromo != null)
                {
                    maPromo.Image = vm.CoverImageUrl;
                    maPromo.Nom = vm.Nom;
                    maPromo.Description = vm.Description;
                    maPromo.CodePromo = vm.CodePromo;
                    maPromo.DateDebut = vm.DateDebut;
                    maPromo.DateFin = vm.DateFin;
                    maPromo.AuteurId = vm.AuteurId;
                    maPromo.MaisonEditionId = vm.MaisonEditionId;
                    maPromo.CategorieId = vm.CategorieId;
                    maPromo.TypePromotion = vm.TypePromotion;
                    maPromo.LivresAcheter = vm.LivresAcheter;
                    maPromo.LivresGratuits = vm.LivresGratuits;
                    maPromo.PourcentageRabais = vm.PourcentageRabais;
                }

                _context.SaveChanges();

                return Ok();
            }

            Promotions promo = _context.Promotions.Find(vm.Id);

            var VM = new AjouterPromotionVM();

            VM.action = "Modifier";

            VM.Id = promo.Id;
            VM.CoverImageUrl = promo.Image;
            VM.Nom = promo.Nom;
            VM.Description = promo.Description;
            VM.CodePromo = promo.CodePromo;
            VM.DateDebut = promo.DateDebut;
            VM.DateFin = promo.DateFin;
            VM.AuteurId = promo.AuteurId;
            VM.MaisonEditionId = promo.MaisonEditionId;
            VM.CategorieId = promo.CategorieId;
            VM.TypePromotion = promo.TypePromotion;
            VM.LivresAcheter = promo.LivresAcheter;
            VM.LivresGratuits = promo.LivresGratuits;
            VM.PourcentageRabais = promo.PourcentageRabais;

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

        // POST: Livre/Delete/5
        [HttpDelete]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Promotions == null) return Problem("Entity set 'ApplicationDbContext.Promotions'  is null.");
            var promo = await _context.Promotions.FindAsync(id);
            if (promo != null) _context.Promotions.Remove(promo);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            /*
            if (id == null || _context.Promotions == null) return NotFound();

            var promo = _context.Promotions.FirstOrDefault(m => m.Id == id);
            if (promo == null) return NotFound();
            _context.Promotions.Remove(promo);
            _context.SaveChanges();
            */
        }

        //Pour montrer la partial view de confirmation de suppression
        [HttpGet]
        public async Task<IActionResult> ShowDeleteConfirmation(string id)
        {
            if (id == null) return NotFound();

            var promo = await _context.Promotions.FindAsync(id);
            if (promo == null) return NotFound();

            return PartialView("PartialViews/Modals/Promotions/_SupprimerPromotionPartial", promo);
        }
    }
}
