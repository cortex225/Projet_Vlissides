using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Categories;

namespace VLISSIDES.Controllers;

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

    public async Task<ActionResult> Index(string? motCle, int page = 1)
    {
        var itemsPerPage = 10;
        var totalItems = await _context.Categories.CountAsync();

        var vm = new CategoriesIndexVM();
        var liste = _context.Categories.Include(c => c.Livres).ThenInclude(lc => lc.Livre).Include(c => c.Enfants)
            .OrderBy(c => c.Nom)
            .Skip((page - 1) * itemsPerPage) // Dépend de la page en cours
            .Take(itemsPerPage)
            .ToList();

        if (motCle != null && motCle != "")
            liste = liste
                .Where(categorie => Regex.IsMatch(categorie.Nom, ".*" + motCle + ".*", RegexOptions.IgnoreCase))
                .Skip((page - 1) * itemsPerPage) // Dépend de la page en cours
                .Take(itemsPerPage)
                .ToList();

        //ViewBag qui permet de savoir sur quelle page on est et le nombre de pages total
        //Math.Ceiling permet d'arrondir au nombre supérieur
        // ReSharper disable once HeapView.BoxingAllocation
        ViewBag.CurrentPage = page;
        // ReSharper disable once HeapView.BoxingAllocation
        ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);

        return View(liste.Select(c => new CategoriesIndexVM()
        {
            Id = c.Id,
            Nom = c.Nom,
            Description = c.Description,
            Enfants = c.Enfants.Select(e => e.Nom).ToList(),
            Livres = c.Livres.Select(l => l.Livre.Titre).ToList()
        }).ToList());
    }

    //[Route("2167594/GestionCategories/Ajouter")]
    //[Route("{controller}/{action}")]
    public ActionResult ShowAjouter()
    {
        var vm = new CategoriesAjouterVM();
        vm.CategoriesParents = _context.Categories.Select(c => new SelectListItem
        {
            Text = c.Nom,
            Value = c.Id
        }).ToList();
        return PartialView("PartialViews/Modals/Categories/_AjouterCategoriesPartial", vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Route("2167594/GestionCategories/Ajouter")]
    //[Route("{controller}/{action}")]
    public async Task<IActionResult> Ajouter(CategoriesAjouterVM vm)
    {
        if (ModelState.IsValid)
        {
            var categorie = new Categorie
            {
                Id = Guid.NewGuid().ToString(),
                Nom = vm.Nom,
                Description = vm.Description
            };
            if (vm.ASousCategorie)
            {
                var cParent = _context.Categories.FirstOrDefault(c => c.Id == vm.ParentId);
                if (cParent != null)
                    categorie.Parent = cParent;
            }

            _context.Categories.Add(categorie);
            _context.SaveChanges();
            return Ok();
        }

        return PartialView("PartialViews/Modals/Categories/_AjouterCategoriesPartial", vm);
    }

    //[Route("2167594/GestionCategories/Modifier")]
    //[Route("{controller}/{action}")]
    public IActionResult Modifier(string id)
    {
        var categorie = _context.Categories.Include(c => c.Parent).FirstOrDefault(c => c.Id == id);
        var vm = new CategoriesModifierVM
        {
            Id = categorie.Id,
            Nom = categorie.Nom,
            Description = categorie.Description,
            CategoriesParents = _context.Categories.Select(c => new SelectListItem
            {
                Selected = c.Parent.Equals(categorie.Parent),
                Text = c.Nom,
                Value = c.Id
            }).ToList(),
            ParentId = null,
            ASousCategorie = false
        };
        if (categorie.Parent != null)
        {
            vm.ParentId = categorie.Parent.Id;
            vm.ASousCategorie = true;
        }
        else
        {
            vm.ParentId = null;
            vm.ASousCategorie = false;
        }

        return PartialView("PartialViews/Modals/Categories/_ModifierCategoriesPartial", vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Route("2167594/GestionCategories/Modifier")]
    //[Route("{controller}/{action}")]
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
                if (vm.ASousCategorie)
                {
                    if (categorie.Parent != null)
                    {
                        if (vm.ParentId != categorie.Parent.Id)
                            categorie.Parent = _context.Categories.FirstOrDefault(c => c.Id == vm.ParentId);
                    }
                    else
                    {
                        categorie.Parent = _context.Categories.FirstOrDefault(c => c.Id == vm.ParentId);
                    }
                }
                else
                {
                    categorie.Parent = null;
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }

        return PartialView("PartialViews/Modals/Categories/_ModifierCategoriesPartial", vm);
    }

    [HttpPost]
    [Route("2167594/GestionCategories/ModifierNomCategorie")]
    [Route("{controller}/{action}")]
    public ActionResult ModifierNomCategorie(string id, string nom)
    {
        if (ModelState.IsValid)
        {
            var categorie = _context.Categories.FirstOrDefault(c => c.Id == id);
            categorie.Nom = nom;
            _context.SaveChanges();
        }

        return View();
    }

    public async Task<IActionResult> ShowDeleteConfirmation(string id)
    {
        if (id == null) return NotFound();

        var categorie = await _context.Categories.FindAsync(id);
        if (categorie == null) return NotFound();

        return PartialView("PartialViews/Modals/Categories/_DeleteCategoriesPartial", categorie);
    }

    [HttpPost]
    [Route("2167594/GestionCategories/SupprimerCategorie")]
    [Route("{controller}/{action}")]
    public ActionResult SupprimerCategorie(string id)
    {
        if (_context.Categories == null) return Problem("Entity set 'ApplicationDbContext.Categories' is null.");
        var categorie = _context.Categories.Include(c => c.Livres).ThenInclude(lc => lc.Livre).Include(c => c.Enfants)
            .FirstOrDefault(c => c.Id == id);
        if (categorie != null)
        {
            var enfants = _context.Categories.Where(c => c.Enfants.Contains(categorie)).ToList();
            enfants.ForEach(e => e.Enfants.Remove(categorie));
            _context.Categories.Remove(categorie);
            _context.SaveChanges();
        }

        return Ok();
    }
}