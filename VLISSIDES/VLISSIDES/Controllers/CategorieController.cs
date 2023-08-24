using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Viewmodels.Categorie;

namespace VLISSIDES.Controllers
{
    public class CategorieController : Controller
    {
        public IActionResult Index()
        {
            return View(new CategorieIndexViewModel());
        }
        public IActionResult Ajouter()
        {
            return View(new CategorieAjouterViewModel());
        }
        public IActionResult Retirer()
        {
            return View(new CategorieRetirerViewModel());
        }
        public IActionResult Detail()
        {
            return View(new CategorieDetailViewModel());
        }
    }
}
