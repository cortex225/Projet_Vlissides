using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                DateDebut = p.DateDebut,
                DateFin = p.DateFin,
                Image = p.Image,
            }).ToList();
            return View(vm);
        }

        [Route("2147186/GestionPromotions/AjouterPromotion")]
        public IActionResult AjouterPromotion() =>
            PartialView("PartialViews/Modals/Promotions/_AjouterPromotionPartial", new AjouterPromotionVM(
            null,
            _context.Auteurs.ToList(),
            _context.Categories.ToList(),
            _context.MaisonEditions.ToList(),
            new() { "Promotion par pourcentage", "Promotion de type \"2 pour 1" }
            ));


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
                    vm.ImageUrl = _config.GetValue<string>("ImageUrl") + fileName;
                    var path = Path.Combine(wwwRootPath + _config.GetValue<string>("ImageUrl"), fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await vm.CoverPhoto.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    vm.ImageUrl = "/img/CouvertureLivre/livredefault.png";
                }

                var id = Guid.NewGuid().ToString();


                _context.Promotions.Add(new Promotions
                {
                    Id = id,
                    Image = vm.ImageUrl,
                    Nom = vm.Nom,
                    Description = vm.Description,
                    CodePromo = vm.CodePromo,
                    DateDebut = vm.DateDebut,
                    DateFin = vm.DateFin,
                    Auteur = _context.Auteurs.First(a => a.NomAuteur.Equals(vm.Auteur),
                    MaisonEdition = _context.MaisonEditions.First(me => me.Nom.Equals(vm.MaisonEdition),
                    Categorie = _context.Categories.First(c => c.Nom.Equals(vm.Categorie),
                    TypePromotion = vm.TypePromotion,
                    LivresAcheter = vm.LivresAcheter,
                    LivresGratuits = vm.LivresGratuits,
                    PourcentageRabais = vm.PourcentageRabais
                });
                _context.SaveChanges();

                return Ok();
            }
            return PartialView("PartialViews/Modals/Promotions/_AjouterPromotionPartial", vm);
        }

        [Route("2147186/GestionPromotions/ModifierPromotion")]
        public IActionResult ModifierPromotion(string id) => PartialView("PartialViews/Modals/Promotions/_AjouterPromotionPartial", new AjouterPromotionVM(
            _context.Promotions.Find(id),
            _context.Auteurs.ToList(),
            _context.Categories.ToList(),
            _context.MaisonEditions.ToList(),
            new() { "Promotion par pourcentage", "Promotion de type \"2 pour 1" }
            ));

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
                    vm.ImageUrl = _config.GetValue<string>("ImageUrl") + fileName;
                    var path = Path.Combine(wwwRootPath + _config.GetValue<string>("ImageUrl"), fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await vm.CoverPhoto.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    vm.ImageUrl = "/img/CouvertureLivre/livredefault.png";
                }

                Promotions? maPromo = _context.Promotions.Find(vm.Id);

                if (maPromo != null)
                {
                    maPromo.Image = vm.ImageUrl;
                    maPromo.Nom = vm.Nom;
                    maPromo.Description = vm.Description;
                    maPromo.CodePromo = vm.CodePromo;
                    maPromo.DateDebut = vm.DateDebut;
                    maPromo.DateFin = vm.DateFin;
                    maPromo.Auteur = await _context.Auteurs.FirstAsync(a => a.NomAuteur.Equals(vm.Auteur));
                    maPromo.MaisonEdition = await _context.MaisonEditions.FirstAsync(me => me.Nom.Equals(vm.MaisonEdition));
                    maPromo.Categorie = await _context.Categories.FirstAsync(c => c.Nom.Equals(vm.Categorie));
                    maPromo.TypePromotion = vm.TypePromotion;
                    maPromo.LivresAcheter = vm.LivresAcheter;
                    maPromo.LivresGratuits = vm.LivresGratuits;
                    maPromo.PourcentageRabais = vm.PourcentageRabais;
                }

                _context.SaveChanges();

                return Ok();
            }
            return PartialView("PartialViews/Modals/Promotions/_AjouterPromotionPartial", new AjouterPromotionVM(
            _context.Promotions.Find(vm.Id),
            _context.Auteurs.ToList(),
            _context.Categories.ToList(),
            _context.MaisonEditions.ToList(),
            new() { "Promotion par pourcentage", "Promotion de type \"2 pour 1" }
            ));
        }

        // POST: Livre/Delete/5
        [HttpDelete]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Promotions.Any(p => p.Id.Equals(id))) return NotFound(id + " n'existe pas.");
            else _context.Promotions.Remove(await _context.Promotions.FindAsync(id));

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Pour montrer la partial view de confirmation de suppression
        [HttpGet]
        public async Task<IActionResult> ShowDeleteConfirmation(string id)
        {
            if (_context.Promotions.Any(p => p.Id.Equals(id))) return NotFound(id + " n'existe pas.");

            return PartialView("PartialViews/Modals/Promotions/_SupprimerPromotionPartial", await _context.Promotions.FindAsync(id));
        }
    }
}
