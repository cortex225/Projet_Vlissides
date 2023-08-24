using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Viewmodels.commande;

namespace VLISSIDES.Controllers
{
    public class CommandeController : Controller
    {
        public IActionResult Index()
        {
            return View(new CommandeIndexViewModel());
        }
        public IActionResult Ajouter()
        {
            return View(new CommandeAjouterViewModel());
        }
        public IActionResult Retirer()
        {
            return View(new CommandeRetirerViewModel());
        }
        public IActionResult Detail()
        {
            return View(new CommandeDetailViewModel());
        }
    }
}
