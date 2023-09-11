using System.ComponentModel;

namespace VLISSIDES.Models;

public class TypeLivre
{
    public string Id { get; set; } = default!;

    [DisplayName("Nom")]
    public string Nom { get; set; } = default!;

    [DisplayName("Livres associés")]
    public ICollection<Livre> Livres { get; set; } = default!;
}