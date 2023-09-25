using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace VLISSIDES.ViewModels.Categories
{
    public class CategoriesModifierVM
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        [DisplayName("Sous catégorie de")] public string? ParentId { get; set; }
        public List<SelectListItem>? CategoriesParents { get; set; }
        [DisplayName("Est une sous catégorie?")] public bool ASousCategorie { get; set; }
    }
}
