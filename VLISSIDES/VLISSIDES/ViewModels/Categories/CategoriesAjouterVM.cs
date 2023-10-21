using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VLISSIDES.ViewModels.Categories;

public class CategoriesAjouterVM
{
    public string Nom { get; set; }
    public string Description { get; set; }
    public List<SelectListItem>? CategoriesParents { get; set; }
    [DisplayName("Sous catégorie de")] public string? ParentId { get; set; }

    [DisplayName("Est une sous catégorie?")]
    public bool ASousCategorie { get; set; }
}