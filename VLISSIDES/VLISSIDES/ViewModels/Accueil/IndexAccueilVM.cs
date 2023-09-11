namespace VLISSIDES.ViewModels.Accueil
{
    public class IndexAccueilVM
    {
        public List<_ServiceCardVM> Services { get; set; }
        public List<_EventCardVM> Evenements { get; set; }
        public List<_LivreCardVM> Vedettes { get; set; }
        public List<_LivreCardVM> Recommendations { get; set; }
        public List<string> Categories { get; set; }
        public List<_LivreCardVM> LivreCategories { get; set; }

        public IndexAccueilVM(List<_ServiceCardVM> services = default!, List<_EventCardVM> evenement = default!,
            List<_LivreCardVM> vedettes = default!, List<_LivreCardVM> recommendations = default!,
            List<string> categories = default!, List<_LivreCardVM> livreCatégories = default!)
        {
            Services = services;
            Evenements = evenement;
            Vedettes = vedettes;
            Recommendations = recommendations;
            Categories = categories;
            LivreCategories = livreCatégories;
        }
    }
}
