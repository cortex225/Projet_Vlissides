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
            Id = l.Id,
            Image = l.Couverture,
            Titre = l.Titre,
            //ListAuteur = _context.Auteurs.Select(a => new SelectList{
            //    if (!((List<Auteur>)l.Auteur).Any())
            //        {
            //            ((List<Auteur>)l.Auteur).ForEach(auteur => Auteurs += auteur.NomComplet + ", ");
            //            Auteurs.Remove(Auteurs.Length - 2, 2);
            //        }
            //}).ToListAsync(),
            Quantite = l.NbExemplaires
        }).Take(10).ToListAsync();
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
                vm.CoverImageUrl = "/img/CouvertureLivre/" + fileName;
                var path = Path.Combine(wwwRootPath + "/img/CouvertureLivre/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await vm.CoverPhoto.CopyToAsync(fileStream);
                }
            }
            else
            {
                vm.CoverImageUrl = "/img/CouvertureLivre/livredefault.png";
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

    //Modifie le nombre du livre selectionné

    [HttpPost]
    public async Task<IActionResult> ModifierLivreQuantite(string id, int quantite)
    {

        var livre = await _context.Livres.FindAsync(id);
        if (livre == null) return BadRequest();
        livre.NbExemplaires = quantite;
        await _context.SaveChangesAsync();
        return Ok();
    }
}