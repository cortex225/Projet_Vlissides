using System.ComponentModel;

namespace VLISSIDES.Models;

public class MaisonEdition
{
    public string Id { get; set; } = default!;

    [DisplayName("Nom")] public string Nom { get; set; } = default!;

    [DisplayName("Livres publiés")] public ICollection<Livre> Livres { get; set; } = default!;

    [DisplayName("Promotion reliées")] public ICollection<Promotion> Promotions { get; set; } = default!;
}