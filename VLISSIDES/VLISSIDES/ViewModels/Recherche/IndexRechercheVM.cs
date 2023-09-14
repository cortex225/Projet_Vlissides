using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Recherche
{
    public class IndexRechercheVM
    {
        public string? MotRecherche { get; set; }
        public List<Livre> ResultatRecherche { get; set; } = new List<Livre>();
    }
}
