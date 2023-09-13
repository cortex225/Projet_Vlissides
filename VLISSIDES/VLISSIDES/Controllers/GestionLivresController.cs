using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionLivres;
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
    public async Task<IActionResult> Inventaire()
    {
        var livres = await _context.Livres.Include(l => l.Auteur).Include(l => l.MaisonEdition).Select(l => new GestionLivresAfficherVM()
        {
            Image = l.Couverture,
            Titre = l.Titre,
            //ListAuteur = _context.,
            //ListEditeur = _context.MaisonEditions
            //.Select(m => new SelectListItem
            //{

            //}),
            Quantite = l.NbExemplaires
        }).ToListAsync();
        return View(livres);
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

    // GET: Livre/Ajouter
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
        vm.SelectLangues = _context.Langues.Select(x => new SelectListItem
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


        if (ModelState.IsValid)
        {
            //Sauvegarder l'image dans root
            if (vm.CoverPhoto != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
                string extension = Path.GetExtension(vm.CoverPhoto.FileName);
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
                vm.CoverImageUrl = "/2167594/img/CouvertureLivre/livredefault.png";
            }
            //Types de livres
            List<TypeLivre> listeType = new List<TypeLivre>();
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
                Id = "Id" + (_context.Livres.Count() + 1).ToString(),
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
                CategorieId = vm.CategorieId,
                LangueId = vm.LangueId
            };

            _context.Livres.Add(livre);
            Console.Write("1");
            _context.SaveChanges();
            Console.Write("2");

            return RedirectToAction("Inventaire");


        }
        return BadRequest();
    }
    public IActionResult Modifier(string id)
    {
        var livre = _context.Livres
            .Include(l => l.Auteur)
            .Include(l => l.TypesLivre)
            .Include(l => l.Langues)
            .Include(l => l.Categories)
            .FirstOrDefault(x => x.Id == id);
        if (livre == null)
        {
            return NotFound();
        }
        ModifierVM vm = new ModifierVM()
        {
            Id = livre.Id,
            ISBN = livre.ISBN,
            Auteurs = livre.Auteur,
            DatePublication = livre.DatePublication,
            NbExemplaires = livre.NbExemplaires,
            NbPages = livre.NbPages,
            Prix = livre.Prix,
            Resume = livre.Resume,
            Titre = livre.Titre,
            CategorieId = livre.CategorieId,
            LangueId = livre.LangueId,
            AuteurId = livre.AuteurId,
            CoverImageUrl = livre.Couverture


        };
        //Remplir les checkbox types 
        if (livre.TypesLivre.Count == 0)
        {
            vm.Neuf = false;
            vm.Numerique = false;
        }
        else
        {
            vm.Neuf = livre.TypesLivre.Contains(_context.TypeLivres.FirstOrDefault(x => x.Id == "1")) ? true : false;
            vm.Numerique = livre.TypesLivre.Contains(_context.TypeLivres.FirstOrDefault(x => x.Id == "2")) ? true : false;
        }
        //Populer les selectList
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
        vm.SelectLangues = _context.Langues.Select(x => new SelectListItem
        {
            Text = x.Nom,
            Value = x.Id
        }).ToList();
        return View(vm);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Modifier(ModifierVM vm)
    {
        if (ModelState.IsValid)
        {
            //Si nouvelle photo
            if (vm.CoverPhoto != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
                string extension = Path.GetExtension(vm.CoverPhoto.FileName);
                fileName += DateTime.Now.ToString("yyyymmssfff") + extension;
                vm.CoverImageUrl = _config.GetValue<string>("ImageUrl") + fileName;
                var path = Path.Combine(wwwRootPath + _config.GetValue<string>("ImageUrl"), fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await vm.CoverPhoto.CopyToAsync(fileStream);
                }
            }
            //Types de livres
            List<TypeLivre> listeType = new List<TypeLivre>();
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

            var livre = await _context.Livres
            .Include(l => l.Auteur)
            .Include(l => l.TypesLivre)
            .Include(l => l.Langues)
            .Include(l => l.Categories)
            .FirstOrDefaultAsync(x => x.Id == vm.Id);

            //Changement des données
            livre.ISBN = vm.ISBN;
            livre.Titre = vm.Titre;
            livre.Resume = vm.Resume;
            livre.NbExemplaires = vm.NbExemplaires;
            livre.NbPages = vm.NbPages;
            livre.AuteurId = vm.AuteurId;
            livre.CategorieId = vm.CategorieId;
            livre.LangueId = vm.LangueId;
            livre.TypesLivre = listeType.ToList();
            livre.Couverture = vm.CoverImageUrl;
            livre.MaisonEditionId = vm.MaisonEditionId;
            livre.Prix = vm.Prix;
            livre.DatePublication = vm.DatePublication;

            await _context.SaveChangesAsync();
            return RedirectToAction("Inventaire");
        }
        return View(vm);
    }
    // GET: Livre/Delete/5
    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null || _context.Livres == null) return NotFound();

        var livre = await _context.Livres
            .Include(l => l.Auteur)
            .Include(l => l.MaisonEdition)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (livre == null) return NotFound();
        _context.Livres.Remove(livre);
        _context.SaveChanges();

        return Ok();
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