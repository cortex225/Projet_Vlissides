using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Categories;

public class CategoriesIndexVM
{
    [DisplayName("Identifiant")] public string Id { get; set; }
    [DisplayName("Nom")] public string Nom { get; set; }
    [DisplayName("Description")] public string Description { get; set; }
    [DisplayName("Livres")] public List<string> Livres { get; set; }
    [DisplayName("Enfants")] public List<string> Enfants { get; set; }

    public CategoriesIndexVM(Categorie categorie)
    {
        Id = categorie.Id;
        Nom = categorie.Nom;
        Description = categorie.Description;
        Livres = categorie.Livres.Select(l => l.Livre.Titre).ToList();
        Enfants = categorie.Enfants.Select(l => l.Nom).ToList();
    }
}