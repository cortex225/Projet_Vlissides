using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Viewmodels;

namespace VLISSIDES.Controllers
{
    public class LivreController : Controller
    {
        public IActionResult Index()
        {
            return View(new LivreIndexViewModel());
        }
        public IActionResult Ajouter()
        {
            return View(new LivreAjouterViewModel());
        }
        public IActionResult Retirer()
        {
            return View(new LivreRetirerViewModel());
        }
        public IActionResult Detail()
        {
            return View(new LivreDetailViewModel());
        }
    }
}
