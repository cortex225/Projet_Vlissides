using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Viewmodels;

namespace VLISSIDES.Controllers
{
    public class AuteurController : Controller
    {
        public IActionResult Index()
        {
            return View(new IndexAuteurViewModel());
        }
        public IActionResult Ajouter()
        {
            return View(new AjouterAuteurViewModel());
        }
        public IActionResult Retirer()
        {
            return View(new RetirerAuteurViewModel());
        }
    }
}
