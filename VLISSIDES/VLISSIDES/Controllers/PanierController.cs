using Microsoft.AspNetCore.Mvc;

namespace VLISSIDES.Controllers
{
    public class PanierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
