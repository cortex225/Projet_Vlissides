using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VLISSIDES.Data;
using VLISSIDES.Models;
using VLISSIDES.ViewModels.LivreUtilisateur;
using VLISSIDES.ViewModels.Panier;

namespace VLISSIDES.Controllers
{
    public class LivreUtilisateurController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LivreUtilisateurController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment,
            IConfiguration config, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _config = config;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index(string? id)
        {
            List<LivreUtilisateurIndexVM> vm = new List<LivreUtilisateurIndexVM>();

            Random random = new Random();
            List<string> idsLivres = _context.Livres
                .Select(l => l.Id)
                .AsEnumerable()
                .OrderBy(x => random.Next())
                .Take(12)
                .ToList();

            List<Livre> listLivres = _context.Livres
                .Where(l => idsLivres.Contains(l.Id))
                .ToList();

            foreach (Livre l in listLivres)
            {
                vm.Add(new LivreUtilisateurIndexVM { Id = l.Id, Titre = l.Titre, Couverture = l.Couverture });
            }

            /*
            vm.Add(new LivreUtilisateurIndexVM { Id = "id1", Titre = "Mathématiques pour l'informatique", Couverture = "https://img.chasse-aux-livres.fr/v7/_am1_/51MiRkVHPQL.jpg?w=170&h=200&func=bound&org_if_sml=1" });
            vm.Add(new LivreUtilisateurIndexVM { Id = "id2", Titre = "Les superpouvoirs des livres", Couverture = "https://images.renaud-bray.com/images/PG/4041/4041312-gf.jpg?404=404RB.gif" });
            vm.Add(new LivreUtilisateurIndexVM { Id = "id3", Titre = "The language of fire", Couverture = "https://i.pinimg.com/236x/37/a9/98/37a99839a447357ee6d3d4b9c991d864.jpg" });
            vm.Add(new LivreUtilisateurIndexVM { Id = "id4", Titre = "Maria Chapdelaine", Couverture = "https://images.renaud-bray.com/images/PG/1490/1490368-gf.jpg?404=404RB.gif" });
            vm.Add(new LivreUtilisateurIndexVM { Id = "id5", Titre = "Jamais plus", Couverture = "https://bettierosebooks.files.wordpress.com/2017/05/jamais-plus-893786.jpg" });
            */

            ListLivreUtilisateurIndexVM VM = new ListLivreUtilisateurIndexVM()
            {
                listVM = vm,
                livreSelectionneId = id
            };

            return View(VM);
        }

        [HttpPost]
        [Route("/LivreUtilisateur/SelectLivre")]
        public async Task<IActionResult> SelectLivre(string? id)
        {
            return RedirectToAction("/LivreUtilisateur/Index?id=" + id);
        }
    }
}
