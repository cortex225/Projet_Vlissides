namespace VLISSIDES.ViewModels.Categories;

public class CategoriesIndexVM
{
    public string Id { get; set; }
    public string Nom { get; set; }
    public string Description { get; set; }
    public List<string> Livres { get; set; }
    public List<string> Enfants { get; set; }
}