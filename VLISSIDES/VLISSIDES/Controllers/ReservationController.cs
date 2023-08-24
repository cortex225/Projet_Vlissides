using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Viewmodels.Reservation;

namespace VLISSIDES.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View(new ReservationIndexViewModel());
        }
        public IActionResult Ajouter()
        {
            return View(new ReservationAjouterViewModel());
        }
        public IActionResult Retirer()
        {
            return View(new ReservationRetirerViewModel());
        }
        public IActionResult Detail()
        {
            return View(new ReservationDetailViewModel());
        }
    }
}
