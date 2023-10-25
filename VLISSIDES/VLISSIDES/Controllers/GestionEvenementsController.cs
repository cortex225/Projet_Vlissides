using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.GestionEvenements;

namespace VLISSIDES.Controllers
{
    [Authorize(Roles = RoleName.EMPLOYE + ", " + RoleName.ADMIN)]
    public class GestionEvenementsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GestionEvenementsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
        IConfiguration config)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
        }
        public IActionResult Index()
        {
            var evenements = _context.Evenements.Select(e => new GestionEvenementsIndexVM
            {
                Id = e.Id,
                Nom = e.Nom,
                Description = e.Description,
                DateDebut = e.DateDebut,
                DateFin = e.DateFin,
                Image = e.Image,
                Lieu = e.Lieu,
                NbPlaces = e.NbPlaces,
                NbPlacesMembre = e.NbPlacesMembre,
                Prix = e.Prix,
            }).ToList();
            return View(evenements);
        }
        public IActionResult AfficherEvenements()
        {
            var evenements = _context.Evenements.Select(e => new GestionEvenementsIndexVM
            {
                Id = e.Id,
                Nom = e.Nom,
                Description = e.Description,
                DateDebut = e.DateDebut,
                DateFin = e.DateFin,
                Image = e.Image,
                Lieu = e.Lieu,
                NbPlaces = e.NbPlaces,
                NbPlacesMembre = e.NbPlacesMembre,
                Prix = e.Prix,
            }).ToList();
            return PartialView("PartialViews/GestionEvenements/_ListeEvenementsPartial", evenements);
        }
        public IActionResult AjouterEvenement()
        {
            var vm = new GestionEvenementsAjouterVM();
            return PartialView("PartialViews/Modals/Evenements/_AjouterEvenementsPartial", vm);
        }
        [HttpPost]
        public async Task<IActionResult> AjouterEvenement(GestionEvenementsAjouterVM vm)
        {
            if (ModelState.IsValid)
            {

                var evenement = new Evenement()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nom = vm.Nom,
                    Description = vm.Description,
                    DateDebut = vm.DateDebut,
                    DateFin = vm.DateFin,
                    Image = vm.Image,
                    Lieu = vm.Lieu,
                    NbPlaces = vm.NbPlaces,
                    NbPlacesMembre = vm.NbPlacesMembre,
                    Prix = vm.Prix,

                };
                if (vm.CoverPhoto != null)
                {
                    var wwwRootPath = _webHostEnvironment.WebRootPath;
                    var fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
                    var extension = Path.GetExtension(vm.CoverPhoto.FileName);
                    fileName = fileName + "_" + Guid.NewGuid().ToString() +
                               extension; // Utilisation de Guid pour un nom de fichier unique
                    var folderPath =
                        Path.Combine(wwwRootPath, "img",
                            "EvenementImages"); // Chemin du dossier où l'image sera sauvegardée
                    var fullPath = Path.Combine(folderPath, fileName); // Chemin complet du fichier

                    // Sauvegarder l'image
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await vm.CoverPhoto.CopyToAsync(fileStream);
                    }

                    evenement.Image =
                        "/img/EvenementImages/" + fileName;
                }
                else
                {
                    evenement.Image = "/img/Couvertures/livredefault.png";
                }
                _context.Evenements.Add(evenement);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return PartialView("PartialViews/Modals/Evenements/_AjouterEvenementsPartial", vm);
        }

        public IActionResult ShowSupprimerEvenement(string id)
        {
            var evenement = _context.Evenements.FirstOrDefault(e => e.Id == id);
            var vm = new GestionEvenementSupprimerVM()
            {
                Id = evenement.Id,
                Nom = evenement.Nom
            };
            return PartialView("PartialViews/Modals/Evenements/_SupprimerEvenementPartial", vm);
        }
        [HttpPost]
        public IActionResult SupprimerEvenement(string id)
        {
            var evenement = _context.Evenements.FirstOrDefault(e => e.Id == id);
            if (evenement == null)
            {
                return NotFound();
            }
            _context.Evenements.Remove(evenement);
            _context.SaveChanges();
            return Ok();
        }
    }
}
