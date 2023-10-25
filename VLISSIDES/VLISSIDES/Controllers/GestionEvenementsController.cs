using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Models;

namespace VLISSIDES.Controllers
{
    [Authorize(Roles = RoleName.EMPLOYE + ", " + RoleName.ADMIN)]
    public class GestionEvenementsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
