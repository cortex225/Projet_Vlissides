using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionLivres;
using VLISSIDES.ViewModels.Livres;

namespace VLISSIDES.Controllers;

[Authorize(Roles = RoleName.EMPLOYE + ", " + RoleName.ADMIN)]
public class GestionLivresController : Controller
{
    private readonly IConfiguration _config;
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public GestionLivresController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
        IConfiguration config)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        _config = config;
    }

    // GET: Livre
    public async Task<IActionResult> Inventaire(string? motCles, string? criteres, int page = 1)
    {
        //Récuppérer les mot clés et les critères de recherches
        List<string> listMotCles = new List<string>();
        if (motCles != null)
        {
            listMotCles = motCles.Split('|').ToList();
        }

        List<string> listCriteres = new List<string>();
        if (criteres != null)
        {
            listCriteres = criteres.Split('|').ToList();
        }

        var itemsPerPage = 10;
        var totalItems = await _context.Livres.CountAsync();

        var categories = _context.Categories.ToList();
        var langues = _context.Langues.ToList();
        var typesLivres = _context.TypeLivres.ToList();

        //Prendre tous les livres
        List<Livre> livres = await _context.Livres
            .Include(l => l.Auteur)
            .Include(l => l.Categorie)
            .Include(l => l.Langues)
            .Include(l => l.Evaluations)
            .Include(l => l.MaisonEdition)
            .Include(l => l.LivreTypeLivres)
            .OrderByDescending(l => l.DateAjout)
            .ToListAsync();

        //Appliquer les critères de recherche si il y a lieu
        if (listCriteres.Count > 0 || listMotCles.Count > 0)
        {
            for (int i = 0; i < listMotCles.Count(); ++i)
            {
                switch (listCriteres[i])
                {
                    default:
                        livres = livres
                        .Where(livre => Regex.IsMatch(livre.Titre, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase))
                        .ToList();
                        break;
                    case "titre":
                        livres = livres
                        .Where(livre => Regex.IsMatch(livre.Titre, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase))
                        .ToList();
                        break;
                    case "auteur":
                        livres = livres
                        .Where(livre => Regex.IsMatch(livre.Auteur.NomAuteur, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase))
                        .ToList();
                        break;
                    case "categorie":
                        livres = livres
                        .Where(livre => Regex.IsMatch(livre.Categorie.Nom, listMotCles[i], RegexOptions.IgnoreCase))
                        .ToList();
                        break;
                    case "maisonEdition":
                        livres = livres
                        .Where(livre =>
                            livre.MaisonEdition != null &&
                            Regex.IsMatch(livre.MaisonEdition.Nom, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase))
                        .ToList();
                        break;
                    case "langue":
                        livres = livres
                        .Where(livre => livre.Langues.Any(langue => Regex.IsMatch(langue.Nom, listMotCles[i], RegexOptions.IgnoreCase)))
                        .ToList();
                        break;
                    case "typeLivre":
                        livres = livres
                        .Where(livre => livre.LivreTypeLivres.Any(type => Regex.IsMatch(type.TypeLivre.Nom, ".*" + listMotCles[i] + ".*", RegexOptions.IgnoreCase)))
                        .ToList();
                        break;
                    case "prixMin":
                        decimal prixMinD;
                        if (decimal.TryParse(listMotCles[i], out prixMinD))
                        {
                            livres = livres
                                .Where(objet => objet.LivreTypeLivres.FirstOrDefault().Prix >= prixMinD)
                                .ToList();
                        }
                        break;

                    case "prixMax":
                        decimal prixMaxD;
                        if (decimal.TryParse(listMotCles[i], out prixMaxD))
                        {
                            livres = livres
                                .Where(objet => objet.LivreTypeLivres.FirstOrDefault().Prix <= prixMaxD)
                                .ToList();
                        }
                        break;
                }
            }
        }  

        var livresVM = livres
            .Skip((page - 1) * itemsPerPage) // Dépend de la page en cours
            .Take(itemsPerPage)
            .Select(l => new GestionLivresAfficherVM
            {
                Id = l.Id,
                Image = l.Couverture,
                Titre = l.Titre,
                ISBN = l.ISBN,
                Categorie = _context.Categories.Where(c=>c.Id == l.CategorieId).FirstOrDefault()?.Nom,
                LivreTypeLivres = _context.LivreTypeLivres.Where(lt => lt.LivreId == l.Id).Include(t => t.TypeLivre).ToList(),
                Quantite = l.NbExemplaires,
            }).ToList();

        //ViewBag qui permet de savoir sur quelle page on est et le nombre de pages total
        //Math.Ceiling permet d'arrondir au nombre supérieur
        // ReSharper disable once HeapView.BoxingAllocation
        ViewBag.CurrentPage = page;
        // ReSharper disable once HeapView.BoxingAllocation
        ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);

        GestionLivresInventaireVM vm = new GestionLivresInventaireVM
        {
            ListeLivres = livresVM,
            ListeCategories = categories,
            ListeLangue = langues,
            ListeTypeLivres = typesLivres
            
        };
        return View(vm);
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

    // GET: C
    public IActionResult Ajouter()
    {
        var vm = new AjouterVM();
        //Populer les listes déroulantes
        vm.SelectListAuteurs = _context.Auteurs.Select(x => new SelectListItem
        {
            Text = x.NomAuteur,
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
        return PartialView("PartialViews/Modals/InventaireLivres/_AjouterPartial", vm);
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
                var wwwRootPath = _webHostEnvironment.WebRootPath;
                var fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
                var extension = Path.GetExtension(vm.CoverPhoto.FileName);
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
                vm.CoverImageUrl = "/img/CouvertureLivre/livredefault.png";
            }
            var id = Guid.NewGuid().ToString();
            //Types de livres
            var listeType = new List<LivreTypeLivre>();
            if (vm.Neuf)
            {
                //var neuf = _context.TypeLivres.FirstOrDefault(x => x.Id == "1");
                listeType.Add(new LivreTypeLivre()
                {
                    LivreId = id,
                    TypeLivreId = "1",
                    Prix = vm.PrixNeuf
                });
            }

            if (vm.Numerique)
            {
                //var numerique = _context.TypeLivres.FirstOrDefault(x => x.Id == "2");
                listeType.Add(new LivreTypeLivre()
                {
                    LivreId = id,
                    TypeLivreId = "2",
                    Prix = vm.PrixNumerique
                });


            }
            var livre = new Livre
            {
                Id = id,
                Titre = vm.Titre,
                Resume = vm.Resume,
                NbExemplaires = vm.NbExemplaires,
                NbPages = vm.NbPages,
                ISBN = vm.ISBN,
                AuteurId = vm.AuteurId,
                MaisonEditionId = vm.MaisonEditionId,
                Couverture = vm.CoverImageUrl,
                LivreTypeLivres = listeType,
                DatePublication = vm.DatePublication,
                DateAjout = DateTime.Now,
                CategorieId = vm.CategorieId,
                LangueId = vm.LangueId,
                TypeLivreId = vm.TypeLivreId
            };

            _context.Livres.Add(livre);
            Console.Write("1");
            _context.SaveChanges();
            Console.Write("2");

            return RedirectToAction("Inventaire");


        }
        return View( vm);
    }
    public IActionResult Modifier(string id)
    {
        var livre = _context.Livres
            .Include(l => l.Auteur)
            .Include(l => l.LivreTypeLivres)
            .Include(l => l.Langues)
            .Include(l => l.Categorie)
            .FirstOrDefault(x => x.Id == id);
        if (livre == null) return NotFound();
        var vm = new ModifierVM
        {
            Id = livre.Id,
            ISBN = livre.ISBN,
            Auteur = livre.Auteur,
            DatePublication = livre.DatePublication,
            NbExemplaires = livre.NbExemplaires,
            NbPages = livre.NbPages,
            Resume = livre.Resume,
            Titre = livre.Titre,
            CategorieId = livre.CategorieId,
            LangueId = livre.LangueId,
            AuteurId = livre.AuteurId,
            CoverImageUrl = livre.Couverture
        };
        //Remplir les checkbox types 
        if (livre.LivreTypeLivres.Count == 0)
        {
            vm.Neuf = false;
            vm.Numerique = false;
        }
        else
        {
            if (livre.LivreTypeLivres.Contains(_context.LivreTypeLivres.FirstOrDefault(x => x.TypeLivreId == "1")))
            {
                vm.Neuf = true;
                vm.PrixNeuf = livre.LivreTypeLivres.FirstOrDefault(x => x.TypeLivreId == "1").Prix;
            }
            else
                vm.Neuf = false;
            if (livre.LivreTypeLivres.Contains(_context.LivreTypeLivres.FirstOrDefault(x => x.TypeLivreId == "2")))
            {
                vm.Numerique = true;
                vm.PrixNumerique = livre.LivreTypeLivres.FirstOrDefault(x => x.TypeLivreId == "2").Prix;
            }
            else vm.Numerique = false;

        }

        //Populer les selectList
        vm.SelectListAuteurs = _context.Auteurs.Select(x => new SelectListItem
        {
            Text = x.NomAuteur,
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
        return PartialView("PartialViews/Modals/InventaireLivres/_EditPartial", vm);
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
                var wwwRootPath = _webHostEnvironment.WebRootPath;
                var fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
                var extension = Path.GetExtension(vm.CoverPhoto.FileName);
                fileName += DateTime.Now.ToString("yyyymmssfff") + extension;
                vm.CoverImageUrl = _config.GetValue<string>("ImageUrl") + fileName;
                var path = Path.Combine(wwwRootPath + _config.GetValue<string>("ImageUrl"), fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await vm.CoverPhoto.CopyToAsync(fileStream);
                }
            }

            //Types de livres
            var listeType = new List<LivreTypeLivre>();
            if (vm.Neuf)
            {
                listeType.Add(new LivreTypeLivre()
                {
                    LivreId = vm.Id.ToString(),
                    TypeLivreId = "1",
                    Prix = vm.PrixNeuf
                });
            }

            if (vm.Numerique)
            {
                listeType.Add(new LivreTypeLivre()
                {
                    LivreId = vm.Id.ToString(),
                    TypeLivreId = "2",
                    Prix = vm.PrixNumerique
                });
            }

            var livre = await _context.Livres
                .Include(l => l.Auteur)
                .Include(l => l.LivreTypeLivres)
                .Include(l => l.Langues)
                .Include(l => l.Categorie)
                .FirstOrDefaultAsync(x => x.Id == vm.Id);

            //Changement des donn�es
            livre.ISBN = vm.ISBN;
            livre.Titre = vm.Titre;
            livre.Resume = vm.Resume;
            livre.NbExemplaires = vm.NbExemplaires;
            livre.NbPages = vm.NbPages;
            livre.AuteurId = vm.AuteurId;
            livre.CategorieId = vm.CategorieId;
            livre.LangueId = vm.LangueId;
            livre.LivreTypeLivres = listeType;
            livre.Couverture = vm.CoverImageUrl;
            livre.MaisonEditionId = vm.MaisonEditionId;
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

    //Pour montrer la la partial view de confirmation de suppression
    [HttpGet]
    public async Task<IActionResult> ShowDeleteConfirmation(string id)
    {
        if (id == null) return NotFound();

        var livre = await _context.Livres.FindAsync(id);
        if (livre == null) return NotFound();

        return PartialView("PartialViews/Modals/InventaireLivres/_DeleteInventairePartial", livre);
    }


    private bool LivreExists(string id)
    {
        return (_context.Livres?.Any(e => e.Id == id)).GetValueOrDefault();
    }

    //Modifie le nombre du livre selectionn�

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