namespace VLISSIDES.Models;

public class LivreCategorie
{
    public string LivreId { get; set; } = default!;
    public Livre Livre { get; set; } = default!;
    public string CategorieId { get; set; } = default!;
    public Categorie Categorie { get; set; } = default!;
}