using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionAuteurs;

namespace VLISSIDES.Controllers;

[Authorize(Roles = RoleName.EMPLOYE + ", " + RoleName.ADMIN)]
public class GestionAuteursController : Controller
{
    private readonly IConfiguration _config;
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public GestionAuteursController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
        IConfiguration config)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        _config = config;
    }

    public async Task<IActionResult> Index(string? motCle, int page = 1)
    {
        var itemsPerPage = 10;
        var totalItems = await _context.Auteurs.CountAsync();

        var vm = new AuteursIndexVM();
        vm.AuteursAjouterVM = new AuteursAjouterVM { NomAuteur = "" };
        var auteurs = _context.Auteurs.Include(a => a.Livres).ThenInclude(la => la.Livre)
            .Include(la => la.Livres)
            .Skip((page - 1) * itemsPerPage) // Dépend de la page en cours
            .Take(itemsPerPage)
            .ToList();

        if (motCle != null && motCle != "")
            auteurs = auteurs
                .Where(auteur => Regex.IsMatch(auteur.NomAuteur, ".*" + motCle + ".*", RegexOptions.IgnoreCase))
                .Skip((page - 1) * itemsPerPage) // Dépend de la page en cours
                .Take(itemsPerPage)
                .ToList();


        //ViewBag qui permet de savoir sur quelle page on est et le nombre de pages total
        //Math.Ceiling permet d'arrondir au nombre supérieur
        // ReSharper disable once HeapView.BoxingAllocation
        ViewBag.CurrentPage = page;
        // ReSharper disable once HeapView.BoxingAllocation
        ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);


        vm.AuteursAfficherVM = auteurs.Select(a => new AuteursAfficherVM
            { Id = a.Id, Nom = a.NomAuteur, Livres = a.Livres.Select(l => l.Livre.Titre).ToList() }).ToList();

        return View(vm);
    }

    public async Task<IActionResult> AfficherLivre(List<Livre> listLivre)
    {
        return Json(listLivre);
    }

    public async Task<IActionResult> AfficherListe(string? motCle, int page = 1)
    {
        var itemsPerPage = 10;
        var totalItems = await _context.Auteurs.CountAsync();

        var auteurs = _context.Auteurs.Include(a => a.Livres).ThenInclude(la => la.Livre).Include(la => la.Livres)
            .OrderBy(a => a.NomAuteur)
            .Skip((page - 1) * itemsPerPage) // Dépend de la page en cours
            .Take(itemsPerPage)
            .ToList();
        if (motCle != null && motCle != "")
            auteurs = auteurs
                .Where(auteur => Regex.IsMatch(auteur.NomAuteur, ".*" + motCle + ".*", RegexOptions.IgnoreCase))
                .Skip((page - 1) * itemsPerPage) // Dépend de la page en cours
                .Take(itemsPerPage)
                .ToList();

        //ViewBag qui permet de savoir sur quelle page on est et le nombre de pages total
        //Math.Ceiling permet d'arrondir au nombre supérieur
        // ReSharper disable once HeapView.BoxingAllocation
        ViewBag.CurrentPage = page;
        // ReSharper disable once HeapView.BoxingAllocation
        ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);

        return PartialView("PartialViews/GestionAuteurs/_ListeAuteursPartial",
            auteurs.Select(a => new AuteursAfficherVM
                { Id = a.Id, Nom = a.NomAuteur, Livres = a.Livres.Select(l => l.Livre.Titre).ToList() }).ToList());
    }

    //AJOUTER
    //================
    //================
    //================
    [HttpPost]
    public ActionResult Ajouter([FromForm] AuteursIndexVM vm)
    {
        if (ModelState.IsValid)
        {
            var auteur = new Auteur
            {
                Id = Guid.NewGuid().ToString(),
                NomAuteur = vm.AuteursAjouterVM.NomAuteur
            };
            _context.Auteurs.Add(auteur);
            _context.SaveChanges();
            return Ok();
        }

        return View(vm);
    }

    [HttpPost]
    public ActionResult ModifierAuteur(string id, string nom)
    {
        if (ModelState.IsValid)
        {
            var auteur = _context.Auteurs.FirstOrDefault(a => a.Id == id);
            auteur.NomAuteur = nom;
            _context.SaveChanges();
            return Ok();
        }

        return View();
    }

    [HttpPost]
    public ActionResult SupprimerAuteur(string id)
    {
        var auteur = _context.Auteurs.FirstOrDefault(me => me.Id == id);
        //Si l'auteur n'est pas trouvé
        if (auteur == null)
            return NotFound();
        //Enlever l'auteur pour chaque livre
        _context.Livres.Where(l => l.LivreAuteurs.Any(a => a.AuteurId.Contains(auteur.Id)))
            .ToList().ForEach(l => l.LivreAuteurs = null);
        _context.Auteurs.Remove(auteur);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> ShowDeleteConfirmation(string id)
    {
        if (id == null) return NotFound();

        var auteur = await _context.Auteurs.FindAsync(id);
        if (auteur == null) return NotFound();

        return PartialView("PartialViews/Modals/Auteurs/_DeleteAuteurPartial", auteur);
    }
}