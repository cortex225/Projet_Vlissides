using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Categories;

public class CategoriesAjouterVM
{
    [Required(ErrorMessage = "Le nom est obligatoire")]
    [DisplayName("Nom")] public string Nom { get; set; }

    [Required(ErrorMessage = "La description est obligatoire")]
    [DisplayName("Description")] public string Description { get; set; }

    [DisplayName("Categories parents")] public List<SelectListItem>? CategoriesParents { get; set; }
    [DisplayName("Parent identifiant")] public string? ParentId { get; set; }

    [DisplayName("Est une sous catégorie?")] public bool ASousCategorie { get; set; }

    public CategoriesAjouterVM(Categorie categorie)
    {
        Nom = categorie.Nom;
        Description = categorie.Description;
        CategoriesParents = categorie.Enfants.Select(c => new SelectListItem(c.Nom, c.Id)).ToList();
        ParentId = categorie.ParentId;
        ASousCategorie = categorie.Parent != null;
    }
}