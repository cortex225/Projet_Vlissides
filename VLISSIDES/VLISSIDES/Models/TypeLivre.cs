namespace VLISSIDES.Models;

public class TypeLivre
{
    public string Id { get; set; } = default!;

    [DisplayName("Nom")] public string Nom { get; set; } = default!;

    [DisplayName("Type(s) de livre")] public ICollection<LivreTypeLivre> LivreTypeLivres { get; set; } = default!;
}