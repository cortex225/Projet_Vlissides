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
            //Supprimer automatiquement les evenements trop vieux
            var evenementsSupprime = _context.Evenements.Where(e => e.DateFin.AddDays(7) < DateTime.Now);
            _context.Evenements.RemoveRange(evenementsSupprime);
            _context.SaveChanges();
            //La liste à afficher
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
            var vm = new GestionEvenementsAjouterVM()
            {
                DateDebut = DateTime.Now,
                DateFin = DateTime.Now,
            };
            return PartialView("PartialViews/Modals/Evenements/_AjouterEvenementsPartial", vm);
        }
        [HttpPost]
        public async Task<IActionResult> AjouterEvenement(GestionEvenementsAjouterVM vm)
        {
            decimal prix = 0;
            if (vm.Prix != null)
            {
                if (!decimal.TryParse(vm.Prix, out prix))
                {
                    ModelState.AddModelError("Prix", "Le prix est invalide");
                }
            }


            if (ModelState.IsValid)
            {
                if (vm.DateDebut < DateTime.Now)
                {
                    ModelState.AddModelError("DateDebut", "La date de début est invalide");
                    return PartialView("PartialViews/Modals/Evenements/_AjouterEvenementsPartial", vm);
                }
                if (vm.DateFin < vm.DateDebut)
                {
                    ModelState.AddModelError("DateFin", "La date de fin est invalide");
                    return PartialView("PartialViews/Modals/Evenements/_AjouterEvenementsPartial", vm);
                }
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
                    Prix = prix,

                };
                //if (vm.CoverPhoto != null)
                //{
                //    var wwwRootPath = _webHostEnvironment.WebRootPath;
                //    var fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
                //    var extension = Path.GetExtension(vm.CoverPhoto.FileName);
                //    fileName = fileName + "_" + Guid.NewGuid().ToString() +
                //               extension; // Utilisation de Guid pour un nom de fichier unique
                //    var folderPath =
                //        Path.Combine(wwwRootPath, _config.GetValue<string>("ImageUrl")); // Chemin du dossier où l'image sera sauvegardée
                //    var fullPath = Path.Combine(folderPath, fileName); // Chemin complet du fichier

                //    // Sauvegarder l'image
                //    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                //    {
                //        await vm.CoverPhoto.CopyToAsync(fileStream);
                //    }

                //    evenement.Image =
                //        "/img/EvenementImages/" + fileName;
                //}
                //else
                //{
                //    evenement.Image = "/img/Couvertures/livredefault.png";
                //}
                if (vm.CoverPhoto != null)
                {
                    var wwwRootPath = _webHostEnvironment.WebRootPath;
                    var fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
                    var extension = Path.GetExtension(vm.CoverPhoto.FileName);
                    fileName += DateTime.Now.ToString("yyyymmssfff") + extension;
                    vm.Image = _config.GetValue<string>("ImageUrl") + fileName;
                    var path = Path.Combine(wwwRootPath + _config.GetValue<string>("ImageUrl"), fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await vm.CoverPhoto.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    vm.Image = "/2147186/img/CouvertureLivre/livredefault.png";
                }
                evenement.Image = vm.Image;
                _context.Evenements.Add(evenement);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return PartialView("PartialViews/Modals/Evenements/_AjouterEvenementsPartial", vm);
        }

        public IActionResult ModifierEvenement(string id)
        {
            var evenement = _context.Evenements.FirstOrDefault(e => e.Id == id);
            var vm = new GestionEvenementsModifierVM()
            {
                Id = id,
                Nom = evenement.Nom,
                Description = evenement.Description,
                DateDebut = evenement.DateDebut,
                DateFin = evenement.DateFin,
                Image = evenement.Image,
                Lieu = evenement.Lieu,
                NbPlaces = evenement.NbPlaces,
                NbPlacesMembre = evenement.NbPlacesMembre,
                Prix = evenement.Prix.ToString(),
            };
            return PartialView("PartialViews/Modals/Evenements/_ModifierEvenementsPartial", vm);
        }
        [HttpPost]
        public async Task<IActionResult> ModifierEvenement(GestionEvenementsModifierVM vm)
        {
            decimal prix = 0;
            if (vm.Prix != null)
            {
                if (!decimal.TryParse(vm.Prix, out prix))
                {
                    ModelState.AddModelError("Prix", "Le prix est invalide");
                }
            }

            if (ModelState.IsValid)
            {
                if (vm.DateDebut < DateTime.Now)
                {
                    ModelState.AddModelError("DateDebut", "La date de début est invalide");
                    return PartialView("PartialViews/Modals/Evenements/_ModifierEvenementsPartial", vm);
                }
                if (vm.DateFin < vm.DateDebut)
                {
                    ModelState.AddModelError("DateFin", "La date de fin est invalide");
                    return PartialView("PartialViews/Modals/Evenements/_ModifierEvenementsPartial", vm);
                }
                var evenement = _context.Evenements.FirstOrDefault(e => e.Id == vm.Id);
                if (evenement != null)
                {
                    //Modifications
                    evenement.Nom = vm.Nom;
                    evenement.Description = vm.Description;
                    evenement.DateDebut = vm.DateDebut;
                    evenement.DateFin = vm.DateFin;
                    evenement.Lieu = vm.Lieu;
                    evenement.NbPlaces = vm.NbPlaces;
                    evenement.NbPlacesMembre = vm.NbPlacesMembre;
                    evenement.Prix = prix;
                    //Si nouvelle photo
                    //if (vm.CoverPhoto != null)
                    //{
                    //    var wwwRootPath = _webHostEnvironment.WebRootPath;
                    //    var fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
                    //    var extension = Path.GetExtension(vm.CoverPhoto.FileName);
                    //    fileName = fileName + "_" + Guid.NewGuid().ToString() +
                    //               extension; // Utilisation de Guid pour un nom de fichier unique
                    //    var folderPath =
                    //        Path.Combine(wwwRootPath, "img",
                    //            "EvenementImages"); // Chemin du dossier où l'image sera sauvegardée
                    //    var fullPath = Path.Combine(folderPath, fileName); // Chemin complet du fichier

                    //    // Sauvegarder l'image
                    //    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    //    {
                    //        await vm.CoverPhoto.CopyToAsync(fileStream);
                    //    }

                    //    evenement.Image =
                    //        "/img/EvenementImages/" + fileName;
                    //}
                    if (vm.CoverPhoto != null)
                    {
                        var wwwRootPath = _webHostEnvironment.WebRootPath;
                        var fileName = Path.GetFileNameWithoutExtension(vm.CoverPhoto.FileName);
                        var extension = Path.GetExtension(vm.CoverPhoto.FileName);
                        fileName += DateTime.Now.ToString("yyyymmssfff") + extension;
                        vm.Image = _config.GetValue<string>("ImageUrl") + fileName;
                        var path = Path.Combine(wwwRootPath + _config.GetValue<string>("ImageUrl"), fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await vm.CoverPhoto.CopyToAsync(fileStream);
                        }
                        evenement.Image = vm.Image;
                    }

                    //Sauvegarder
                    await _context.SaveChangesAsync();
                    return Ok();
                }


            }
            return PartialView("PartialViews/Modals/Evenements/_ModifierEvenementsPartial", vm);
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
