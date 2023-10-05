using System.ComponentModel;

namespace VLISSIDES.Models;

public class TypeLivre
{
    public string Id { get; set; } = default!;

    [DisplayName("Nom")] public string Nom { get; set; } = default!;
    [DisplayName("Prix")] public double Prix { get; set; } = default!;

    [DisplayName("Type(s) de livre")] public ICollection<LivreTypeLivre> TypeLivres { get; set; } = default!;
}