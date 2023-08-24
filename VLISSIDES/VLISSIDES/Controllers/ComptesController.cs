using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Viewmodels.Compte;

namespace VLISSIDES.Controllers
{
    public class ComptesController : Controller
    {
        public IActionResult Profile()
        {
            return View(new CompteProfileViewModel());
        }
        public IActionResult Ajouter()
        {
            return View(new CompteAjouterViewModel());
        }
        public IActionResult Retirer()
        {
            return View(new CompteRetirerViewModel());
        }
        public IActionResult Detail()
        {
            return View(new CompteDetailViewModel());
        }
    }
}
