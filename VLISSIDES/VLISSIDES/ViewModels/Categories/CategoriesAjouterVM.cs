using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Categories;

public class CategoriesAjouterVM
{
    [Required(ErrorMessage = "Le nom est obligatoire")]
    public string Nom { get; set; }
    [Required(ErrorMessage = "La description est obligatoire")]
    public string Description { get; set; }
    public List<SelectListItem>? CategoriesParents { get; set; }
    [DisplayName("Sous catégorie de")] public string? ParentId { get; set; }

    [DisplayName("Est une sous catégorie?")]
    public bool ASousCategorie { get; set; }
}