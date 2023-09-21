using Microsoft.AspNetCore.Mvc.Rendering;

namespace VLISSIDES.ViewModels.Categories
{
    public class CategoriesAjouterVM
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public List<SelectListItem>? CategoriesParents { get; set; }
        public string? ParentId { get; set; }
    }
}
