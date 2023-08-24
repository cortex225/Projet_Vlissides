using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Viewmodels.MaisonEdittion;

namespace VLISSIDES.Controllers
{
    public class MaisonEditionController : Controller
    {
        public IActionResult Index()
        {
            return View(new IndexMaisonEditionViewModel());
        }
        public IActionResult Ajouter()
        {
            return View(new AjouterMaisonEditionViewModel());
        }
        public IActionResult Retirer()
        {
            return View(new RetirerMaisonEditionViewModel());
        }
    }
}
