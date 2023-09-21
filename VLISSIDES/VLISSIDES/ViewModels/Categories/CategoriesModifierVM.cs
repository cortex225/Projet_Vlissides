using Microsoft.AspNetCore.Mvc.Rendering;

namespace VLISSIDES.ViewModels.Categories
{
    public class CategoriesModifierVM
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string? ParentId { get; set; }
        public List<SelectListItem>? CategoriesParents { get; set; }
    }
}
