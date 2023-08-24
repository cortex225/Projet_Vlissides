using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VLISSIDES.Viewmodels.Home;

namespace VLISSIDES.Controllers;

public class AccueilController : Controller
{
    private readonly ILogger<AccueilController> _logger;

    public AccueilController(ILogger<AccueilController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
<<<<<<< HEAD:VLISSIDES/VLISSIDES/Controllers/AccueilController.cs
        return View();
=======
        return View(new IndexHomeViewModel());
>>>>>>> d1890f2edabbc786ad1625f00c8076abfccef5e5:VLISSIDES/VLISSIDES/Controllers/HomeController.cs
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}