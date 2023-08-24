using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Viewmodels;
using VLISSIDES.Viewmodels.StatutCommande;

namespace VLISSIDES.Controllers
{
    public class StatutCommandeController : Controller
    {
        public IActionResult Index()
        {
            return View(new StatutCommandeIndexViewModel());
        }
        public IActionResult Ajouter()
        {
            return View(new StatutCommandeAjouterViewModel());
        }
        public IActionResult Retirer()
        {
            return View(new StatutCommandeRetirerViewModel());
        }
        public IActionResult Detail()
        {
            return View(new StatutCommandeDetailViewModel());
        }
    }
}
