using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Viewmodels.MaisonEdition;

namespace VLISSIDES.Controllers
{
    public class MaisonEditionController : Controller
    {
        public IActionResult Index()
        {
            return View(new MaisonEditionIndexViewModel());
        }
        public IActionResult Ajouter()
        {
            return View(new MaisonEditionAjouterViewModel());
        }
        public IActionResult Retirer()
        {

            return View(new MaisonEditionRetirerViewModel());
        }

    }
}
