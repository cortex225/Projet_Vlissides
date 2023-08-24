using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VLISSIDES.Viewmodels;
using VLISSIDES.Viewmodels.Accueil;

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
        return View(new AccueilIndexViewModel());
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