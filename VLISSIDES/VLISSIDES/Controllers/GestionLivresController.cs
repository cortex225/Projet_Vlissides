using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.Livres;

namespace VLISSIDES.Controllers;

public class GestionLivresController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IConfiguration _config;

    public GestionLivresController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, IConfiguration config)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        _config = config;
    }

    // GET: Livre
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Livres.Include(l => l.Auteur).Include(l => l.MaisonEdition);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: Livre/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null || _context.Livres == null) return NotFound();

        var livre = await _context.Livres
            .Include(l => l.Auteur)
            .Include(l => l.MaisonEdition)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (livre == null) return NotFound();

        return View(livre);
    }

    // GET: Livre/Create
    public IActionResult Ajouter()
    {
        AjouterVM vm = new AjouterVM { };
        //Populer les listes déroulantes
        vm.SelectListAuteurs = _context.Auteurs.Select(x => new SelectListItem
        {
            Text = x.Prenom + " " + x.Nom,
            Value = x.Id
        }).ToList();
        vm.SelectMaisonEditions = _context.MaisonEditions.Select(x => new SelectListItem
        {
            Text = x.Nom,
            Value = x.Id
        }).ToList();
        vm.SelectListCategories = _context.Categories.Select(x => new SelectListItem
        {
            Text = x.Nom,
            Value = x.Id
        }).ToList();
        return View(vm);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Ajouter(AjouterVM vm)
    {

        //Sauvegarder l'image dans root
        if (vm.CoverPhoto != null)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
            string extension = Path.GetExtension(vm.CoverPhoto.FileName);
            fileName += DateTime.Now.ToString("yyyymmssfff") + extension;
            vm.CoverImageUrl = Path.Combine(wwwRootPath + "/img/CouvertureLivre/", fileName);
            using (var fileStream = new FileStream(vm.CoverImageUrl, FileMode.Create))
            {
                await vm.CoverPhoto.CopyToAsync(fileStream);
            }
        }
        else
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            vm.CoverImageUrl = wwwRootPath + "/img/CouvertureLivre/livredefault.png";
        }


        if (ModelState.IsValid)
        {
            //Types de livres
            List<TypeLivre> listeType = null;
            if (vm.Neuf)
            {
                var neuf = _context.TypeLivres.FirstOrDefault(x => x.Id == "1");
                listeType.Add(neuf);
            }
            if (vm.Numerique)
            {
                var numerique = _context.TypeLivres.FirstOrDefault(x => x.Id == "2");
                listeType.Add(numerique);
            }

            var livre = new Livre()
            {
                Titre = vm.Titre,
                Resume = vm.Resume,
                NbExemplaires = vm.NbExemplaires,
                NbPages = vm.NbPages,
                Prix = vm.Prix,
                ISBN = vm.ISBN,
                AuteurId = vm.AuteurId,
                MaisonEditionId = vm.MaisonEditionId,
                Couverture = vm.CoverImageUrl,
                TypesLivre = listeType,
                DatePublication = vm.DatePublication,
                DateAjout = DateTime.Now,
                CategorieId = vm.CategorieId
            };

            _context.Livres.Add(livre);
            _context.SaveChanges();
            return View();

        }
        return BadRequest();


    }
    // GET: Livre/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null || _context.Livres == null) return NotFound();

        var livre = await _context.Livres
            .Include(l => l.Auteur)
            .Include(l => l.MaisonEdition)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (livre == null) return NotFound();

        return View(livre);
    }

    // POST: Livre/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        if (_context.Livres == null) return Problem("Entity set 'ApplicationDbContext.Livres'  is null.");
        var livre = await _context.Livres.FindAsync(id);
        if (livre != null) _context.Livres.Remove(livre);

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LivreExists(string id)
    {
        return (_context.Livres?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}