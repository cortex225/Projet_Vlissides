using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Categories;

public class CategoriesModifierVM
{
    [DisplayName("Identifiant")] public string Id { get; set; }

    [Required(ErrorMessage = "Le nom est obligatoire")]
    [DisplayName("Nom")] public string Nom { get; set; }

    [Required(ErrorMessage = "La description est obligatoire")]
    [DisplayName("Description")] public string Description { get; set; }

    [DisplayName("Parent identifiant")] public string? ParentId { get; set; }
    [DisplayName("Catégorie parents?")] public List<SelectListItem>? Parent { get; set; }

    [DisplayName("Est une sous catégorie?")] public bool ASousCategorie { get; set; }

    public CategoriesModifierVM()
    {
        Id = "";
        Nom = "";
        Description = "";
        Parent = new();
        ParentId = "";
        ASousCategorie = false;
    }
    public CategoriesModifierVM(Categorie categorie, IEnumerable<Categorie> categories)
    {
        Id = categorie.Id;
        Nom = categorie.Nom;
        Description = categorie.Description;
        Parent = categories.Select(c => new SelectListItem(c.Nom, c.Id)).ToList();
        ParentId = categorie.ParentId;
        ASousCategorie = categorie.Parent != null;
    }
}