using System.ComponentModel;

namespace VLISSIDES.Models;

public class Categorie
{
    public string Id { get; set; } = default!;

    [DisplayName("Nom")] public string Nom { get; set; } = default!;

    [DisplayName("Description")] public string Description { get; set; } = default!;

    [DisplayName("Livres reliées à cette catégorie")]
    public ICollection<Livre> Livres { get; set; } = default!;
}