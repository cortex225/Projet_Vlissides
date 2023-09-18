using System.ComponentModel;

namespace VLISSIDES.Models;

public class Langue
{
    public string Id { get; set; } = default!;

    [DisplayName("Nom")] public string Nom { get; set; } = default!;

    [DisplayName("Code")] public string Code { get; set; } = default!;

    [DisplayName("Livre écrits dans cette langue")]
    public ICollection<LangueLivre>? LangueLivres { get; set; }
}