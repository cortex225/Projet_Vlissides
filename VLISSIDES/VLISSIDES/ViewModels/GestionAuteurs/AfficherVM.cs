using Microsoft.AspNetCore.Mvc.Rendering;

namespace VLISSIDES.ViewModels.GestionAuteurs
{
    public class AfficherVM
    {
        public string Id;
        public string Nom;
        public List<SelectListItem> ListLivre;
    }
}
