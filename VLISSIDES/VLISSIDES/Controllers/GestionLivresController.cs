using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionLivres;

namespace VLISSIDES.Controllers;

public class GestionLivresController : Controller
{
    private readonly ApplicationDbContext _context;

    public GestionLivresController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Livre
    public async Task<IActionResult> Inventaire()
    {
        var livres = await _context.Livres.Include(l => l.Auteur).Include(l => l.MaisonEdition).Select(l => new GestionLivresAfficherVM()
        {
            Image = l.Couverture,
            Titre = l.Titre,
            Auteur = "",
            Editeur = "",
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

    // GET: Livre/Create
    public IActionResult Create()
    {
        ViewData["AuteurId"] = new SelectList(_context.Set<Auteur>(), "Id", "Id");
        ViewData["MaisonEditionId"] = new SelectList(_context.MaisonEditions, "Id", "Id");
        return View();
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