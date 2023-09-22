using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Categories;

namespace VLISSIDES.Controllers
{
    public class GestionCategoriesController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GestionCategoriesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
            IConfiguration config)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
        }
        public ActionResult Index()
        {
            var vm = new CategoriesIndexVM();
            var liste = _context.Categories.Include(c => c.Livres)
                .OrderBy(c => c.Nom).ToList();
            vm.ListeCategories = liste;
            return View(vm);
        }
        public ActionResult Ajouter()
        {
            var vm = new CategoriesAjouterVM();
            vm.CategoriesParents = _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Nom,
                Value = c.Id
            }).ToList();
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ajouter(CategoriesAjouterVM vm)
        {
            if (ModelState.IsValid)
            {
                var categorie = new Categorie()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nom = vm.Nom,
                    Description = vm.Description,

                };
                if (vm.ParentId != null)
                {
                    var cParent = _context.Categories.FirstOrDefault(c => c.Id == vm.ParentId);
                    if (cParent != null)
                        categorie.Parent = cParent;
                }
                _context.Categories.Add(categorie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }
        public IActionResult Modifier(string id)
        {
            var categorie = _context.Categories.FirstOrDefault(c => c.Id == id);
            var vm = new CategoriesModifierVM()
            {
                Id = categorie.Id,
                Nom = categorie.Nom,
                Description = categorie.Description,
                CategoriesParents = _context.Categories.Select(c => new SelectListItem
                {
                    Text = c.Nom,
                    Value = c.Id
                }).ToList()
            };
            if (categorie.Parent != null)
            {
                vm.ParentId = categorie.Parent.Id;
            }
            return PartialView("", vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modifier(CategoriesModifierVM vm)
        {
            if (ModelState.IsValid)
            {
                var categorie = await _context.Categories.FirstOrDefaultAsync(c => c.Id == vm.Id);

                if (categorie != null)
                {
                    //Changement de données
                    categorie.Nom = vm.Nom;
                    categorie.Description = vm.Description;
                    //Parent de la sous-catégorie
                    if (categorie.Parent != null)
                    {
                        if (vm.ParentId != null &&
                            vm.ParentId != categorie.Parent.Id)
                        {
                            categorie.Parent = _context.Categories.FirstOrDefault(c => c.Id == vm.ParentId);
                        }
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

            }
            return View(vm);
        }
        public async Task<IActionResult> ShowDeleteConfirmation(string id)
        {
            if (id == null) return NotFound();

            var categorie = await _context.Categories.FindAsync(id);
            if (categorie == null) return NotFound();

            return PartialView("PartialViews/Modals/Categories/_DeleteCategoriesPartial", categorie);
        }
        [HttpPost]
        public async Task<IActionResult> SupprimerCategorie(string id)
        {
            if (_context.Categories == null) return Problem("Entity set 'ApplicationDbContext.Categories' is null.");
            var categorie = await _context.Categories.FindAsync(id);
            if (categorie != null)
            {
                _context.Categories.Remove(categorie);
                await _context.SaveChangesAsync();

            }
            //var categorie = _context.Categories.FirstOrDefault(c => c.Id == id);
            //if (categorie == null) { return NotFound(); }

            //_context.Livres.Where(l => l.CategorieId == categorie.Id)
            //    .ToList().ForEach(l => l.CategorieId = null);
            //_context.Categories.Remove(categorie);
            //_context.SaveChanges();
            return Ok();
        }
    }
}
