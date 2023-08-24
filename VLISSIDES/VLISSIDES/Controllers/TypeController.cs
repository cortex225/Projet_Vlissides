using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Viewmodels.Type;

namespace VLISSIDES.Controllers
{
    public class TypeController : Controller
    {
        public IActionResult Index()
        {
            return View(new TypeIndexViewModel());
        }
        public IActionResult Ajouter()
        {
            return View(new TypeAjouterViewModel());
        }
        public IActionResult Retirer()
        {
            return View(new TypeRetirerViewModel());
        }
        public IActionResult Detail()
        {
            return View(new TypeDetailViewModel());
        }
    }
}
