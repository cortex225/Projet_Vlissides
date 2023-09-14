using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.MaisonEditions;

namespace VLISSIDES.Controllers
{
    public class MaisonEditionsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MaisonEditionsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
        IConfiguration config)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
        }
        public ActionResult Index()
        {
            return View("Index");
        }
        public PartialViewResult Ajouter()
        {
            var vm = new MaisonEditionsAjouterVM();
            return PartialView(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ajouter(MaisonEditionsAjouterVM vm)
        {
            if (ModelState.IsValid)
            {
                var maisonEdition = new MaisonEdition()
                {
                    Id = "Id" + (_context.MaisonEditions.Count() + 1).ToString(),
                    Nom = vm.Nom,
                };
                _context.MaisonEditions.Add(maisonEdition);
                return Ok();
            }
            return View(vm);
        }
    }
}
