using System.ComponentModel;

namespace VLISSIDES.Models;

public class Categorie
{
    public string Id { get; set; } = default!;

    [DisplayName("Nom")] public string Nom { get; set; } = default!;

    [DisplayName("Description")] public string Description { get; set; } = default!;
    [DisplayName("Parent")] public Categorie? Parent { get; set; } = default!;
    [DisplayName("Enfants")] public ICollection<Categorie>? Enfants { get; set; } = default!;

    [DisplayName("L'identifiant du parent")]
    public string? ParentId { get; set; }
    [DisplayName("Parent")]
    public Categorie? Parent { get; set; }
    [DisplayName("Enfants")]
    public ICollection<Categorie>? Enfants { get; set; }
    [DisplayName("Livres")]
    public ICollection<Livre>? Livres { get; set; }
}