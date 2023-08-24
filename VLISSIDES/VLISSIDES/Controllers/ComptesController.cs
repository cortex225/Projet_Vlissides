using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Viewmodels.Compte;

namespace VLISSIDES.Controllers
{
    public class ComptesController : Controller
    {
        public IActionResult Profile()
        {
            return View(new ProfileViewModel());
        }
        public IActionResult Creer()
        {
            return View(new CreerCompteViewModel());
        }
        public IActionResult Supprimer()
        {
            return View(new SupprimerCompteViewModel());
        }
    }
}
