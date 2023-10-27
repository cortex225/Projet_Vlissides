using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels;
using VLISSIDES.ViewModels.MaisonEditions;

namespace VLISSIDES.Controllers;
[Authorize(Roles = RoleName.EMPLOYE + ", " + RoleName.ADMIN)]
public class GestionMaisonEditionsController : Controller
{
    private readonly IConfiguration _config;
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public GestionMaisonEditionsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
        IConfiguration config)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        _config = config;
    }

    public async Task<IActionResult> Index(string? motCle, int page = 1)
    {
        var itemsPerPage = 10;
        var totalItems = await _context.MaisonEditions.CountAsync();

        var vm = new MaisonEditionsIndexVM();
        vm.MaisonEditionsAjouterVM = new MaisonEditionsAjouterVM { Nom = "" };
        var editions = _context.MaisonEditions.Include(me => me.Livres)
            .OrderBy(me => me.Nom)
            .Skip((page - 1) * itemsPerPage) // Dépend de la page en cours
            .Take(itemsPerPage)
            .ToList();

        if (motCle != null && motCle != "")
            editions = editions
                .Where(maison => Regex.IsMatch(maison.Nom, ".*" + motCle + ".*", RegexOptions.IgnoreCase))
                .Skip((page - 1) * itemsPerPage) // Dépend de la page en cours
                .Take(itemsPerPage)
                .ToList();

        //ViewBag qui permet de savoir sur quelle page on est et le nombre de pages total
        //Math.Ceiling permet d'arrondir au nombre supérieur
        // ReSharper disable once HeapView.BoxingAllocation
        ViewBag.CurrentPage = page;
        // ReSharper disable once HeapView.BoxingAllocation
        ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);

        vm.MaisonEditionsAfficherVM = editions.Select(e => new MaisonEditionsAfficherVM() { Id = e.Id, Nom = e.Nom, Livres = e.Livres.Select(l => l.Titre).ToList() }).ToList();
        return View(vm);
    }

    public async Task<IActionResult> AfficherListe(string? motCle, int page = 1)
    {
        var itemsPerPage = 10;
        var totalItems = await _context.MaisonEditions.CountAsync();

        var vm = new MaisonEditionsIndexVM();
        vm.MaisonEditionsAjouterVM = new MaisonEditionsAjouterVM { Nom = "" };
        var editions = _context.MaisonEditions.Include(me => me.Livres)
            .OrderBy(me => me.Nom)
            .Skip((page - 1) * itemsPerPage) // Dépend de la page en cours
            .Take(itemsPerPage)
            .ToList();
        if (motCle != null && motCle != "")
            editions = editions.Where(maison => Regex.IsMatch(maison.Nom, ".*" + motCle + ".*", RegexOptions.IgnoreCase))
                .Skip((page - 1) * itemsPerPage) // Dépend de la page en cours
                .Take(itemsPerPage)
                .ToList();

        //ViewBag qui permet de savoir sur quelle page on est et le nombre de pages total
        //Math.Ceiling permet d'arrondir au nombre supérieur
        // ReSharper disable once HeapView.BoxingAllocation
        ViewBag.CurrentPage = page;
        // ReSharper disable once HeapView.BoxingAllocation
        ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);


        vm.MaisonEditionsAfficherVM = editions.Select(e => new MaisonEditionsAfficherVM() { Id = e.Id, Nom = e.Nom, Livres = e.Livres.Select(l => l.Titre).ToList() }).ToList();
        return PartialView("PartialViews/GestionMaisonEdition/_ListeMaisonEditionPartial", vm);
    }

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public ActionResult Ajouter([FromForm] MaisonEditionsIndexVM vm)
    {
        //if (vm.MaisonEditionsAjouterVM.Nom == null || vm.MaisonEditionsAjouterVM.Nom == string.Empty)
        //{
        //    ModelState.AddModelError(string.Empty, "Nom vide");
        //}
        if (ModelState.IsValid)
        {
            var maisonEdition = new MaisonEdition
            {
                Id = Guid.NewGuid().ToString(),
                Nom = vm.MaisonEditionsAjouterVM.Nom
            };
            _context.MaisonEditions.Add(maisonEdition);
            _context.SaveChanges();
            return Ok();
        }

        return View();
    }

    [HttpPost]
    public ActionResult ModifierMaison(string id, string nom)
    {
        if (ModelState.IsValid)
        {
            var maisonEdition = _context.MaisonEditions.FirstOrDefault(me => me.Id == id);
            maisonEdition.Nom = nom;
            _context.SaveChanges();
            return Ok();
        }

        return View();
    }

    [HttpPost]
    public ActionResult SupprimerMaison(string id)
    {
        var maisonEdition = _context.MaisonEditions.FirstOrDefault(me => me.Id == id);
        //Si la maison d'édition n'est pas trouvé
        if (maisonEdition == null)
            return NotFound();
        //Enlever la maison d'édition pour chaque livre
        _context.Livres.Where(l => l.MaisonEdition.Id == maisonEdition.Id)
            .ToList().ForEach(l => l.MaisonEdition = null);
        _context.MaisonEditions.Remove(maisonEdition);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> ShowDeleteConfirmation(string id)
    {
        if (id == null) return NotFound();

        var maisonEdition = await _context.MaisonEditions.FindAsync(id);
        if (maisonEdition == null) return NotFound();

        return PartialView("PartialViews/Modals/MaisonEditions/_DeleteMaisonEditionPartial", maisonEdition);
    }
}