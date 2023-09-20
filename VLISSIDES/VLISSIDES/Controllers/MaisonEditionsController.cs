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
            var vm = new MaisonEditionsIndexVM();
            vm.MaisonEditionsAjouterVM = new MaisonEditionsAjouterVM() { Nom = "" };
            return View(vm);
        }
        //public PartialViewResult Ajouter()
        //{
        //    var vm = new MaisonEditionsAjouterVM() { Nom = "" };
        //    return PartialView(vm);
        //}
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Ajouter([FromForm] MaisonEditionsIndexVM vm)
        {
            //if (vm.MaisonEditionsAjouterVM.Nom == null || vm.MaisonEditionsAjouterVM.Nom == string.Empty)
            //{
            //    ModelState.AddModelError(string.Empty, "Nom vide");
            //}
            if (ModelState.IsValid)
            {

                var maisonEdition = new MaisonEdition()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nom = vm.MaisonEditionsAjouterVM.Nom,

                };
                _context.MaisonEditions.Add(maisonEdition);
                _context.SaveChanges();
                return Ok();
            }
            return View();
        }
    }
}
