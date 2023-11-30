using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.LivreUtilisateur;

namespace VLISSIDES.Controllers;

public class LivreUtilisateurController : Controller
{
    private readonly IConfiguration _config;
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public LivreUtilisateurController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
        IConfiguration config, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        _config = config;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IActionResult> Index(string? id)
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.FindByIdAsync(userId);

        var userCommandes = _context.Commandes
            .Include(c => c.LivreCommandes)
            .ThenInclude(lc => lc.Livre)
            .ThenInclude(l => l.Evaluations)
            .Where(c => c.MembreId == userId)
            .ToList();

        var vm = new List<LivreUtilisateurIndexVM>();

        foreach (var c in userCommandes)
            foreach (var l in c.LivreCommandes)
            {
                var siDejaDansListe = false;

                foreach (var lu_vm in vm)
                    if (lu_vm.Id == l.Livre.Id)
                        siDejaDansListe = true;

                if (!siDejaDansListe)
                {
                    double? eval = null;
                    if (l.Livre.Evaluations != null)
                        foreach (var e in l.Livre.Evaluations)
                            if (e.MembreId == userId)
                            {
                                eval = e.Note;
                                vm.Add(new LivreUtilisateurIndexVM(l.Livre, e, c));
                                break;
                            }

                }
            }

        var VM = new ListLivreUtilisateurIndexVM(vm, id);

        return View(VM);
    }

    [HttpPost]
    [Route("/LivreUtilisateur/SelectLivre")]
    public async Task<IActionResult> SelectLivre(string? id)
    {
        return RedirectToAction("/LivreUtilisateur/Index?id=" + id);
    }

    [HttpPost]
    [Route("/LivreUtilisateur/Noter")]
    public async Task<IActionResult> Noter(string id, int? note)
    {
        var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var l = await _context.Livres
            .Include(l => l.Evaluations)
            .FirstOrDefaultAsync(livre => livre.Id == id);
        Evaluation? eval = null;

        //Chercher si il y a déja une évaluation
        if (l != null)
            if (l.Evaluations != null)
                foreach (var evaluation in l.Evaluations)
                    if (evaluation.MembreId == userId)
                    {
                        eval = evaluation;
                        break;
                    }

        if (note == null) //Supprimer évaluation
        {
            if (eval != null)
            {
                _context.Evaluations.Remove(eval);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("/LivreUtilisateur/Index");
        }

        if (eval != null) //Modifier évaluation
        {
            //eval.DateEvaluation = DateTime.Now;
            //eval.Note = (int)note;

            _context.Evaluations.Remove(eval);

            var e = new Evaluation
            {
                Id = Guid.NewGuid().ToString(),
                Note = (int)note,
                DateEvaluation = DateTime.Now,
                LivreId = id,
                MembreId = userId
            };
            await _context.Evaluations.AddAsync(e);
            await _context.SaveChangesAsync();
            return RedirectToAction("/LivreUtilisateur/Index");
        }
        else //Créer une nouvelle évaluation
        {
            var e = new Evaluation
            {
                Id = Guid.NewGuid().ToString(),
                Note = (int)note,
                DateEvaluation = DateTime.Now,
                LivreId = id,
                MembreId = userId
            };
            await _context.Evaluations.AddAsync(e);
            await _context.SaveChangesAsync();

            return RedirectToAction("/LivreUtilisateur/Index");
        }
    }
}