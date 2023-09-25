using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.MaisonEditions;

namespace VLISSIDES.Controllers;

public class MaisonEditionsController : Controller
{
    private readonly IConfiguration _config;
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public MaisonEditionsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
        IConfiguration config)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        _config = config;
    }

    public ActionResult Index()
    {
        var vm = new MaisonEditionsIndexVM();
        vm.MaisonEditionsAjouterVM = new MaisonEditionsAjouterVM { Nom = "" };
        var liste = _context.MaisonEditions.Include(me => me.Livres)
            .OrderBy(me => me.Nom).ToList();
        vm.ListeMaisonEditions = liste;
        return View(vm);
    }
    public async Task<IActionResult> AfficherListe()
    {
        var vm = new MaisonEditionsIndexVM();
        vm.MaisonEditionsAjouterVM = new MaisonEditionsAjouterVM { Nom = "" };
        var liste = _context.MaisonEditions.Include(me => me.Livres)
            .OrderBy(me => me.Nom).ToList();
        vm.ListeMaisonEditions = liste;
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

            var maisonEdition = new MaisonEdition()
            {
                Id = Guid.NewGuid().ToString(),
                Nom = vm.MaisonEditionsAjouterVM.Nom,

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
        _context.Livres.Where(l => l.MaisonEditionId == maisonEdition.Id)
            .ToList().ForEach(l => l.MaisonEditionId = null);
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

