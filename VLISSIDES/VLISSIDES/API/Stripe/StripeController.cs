using Microsoft.AspNetCore.Mvc;

namespace VLISSIDES.API.Stripe
{
    public class StripeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
