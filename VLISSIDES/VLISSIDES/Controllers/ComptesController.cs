using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Viewmodels;

namespace VLISSIDES.Controllers
{
    public class ComptesController : Controller
    {
        public IActionResult Profile()
        {
            return View(new ProfileViewModel());
        }
    }
}
