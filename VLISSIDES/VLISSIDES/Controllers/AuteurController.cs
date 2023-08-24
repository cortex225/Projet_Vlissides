namespace VLISSIDES.Controllers
{
    public class AuteurController : Controller
    {
        public IActionResult Index()
        {
            return View(new AuteurIndexViewModel());
        }
        public IActionResult Ajouter()
        {
            return View(new AuteurAjouterViewModel());
        }
        public IActionResult Retirer()
        {
            return View(new AuteurRetirerViewModel());
        }
        public IActionResult Detail()
        {
            return View(new AuteurDetailViewModel());
        }
    }
}
