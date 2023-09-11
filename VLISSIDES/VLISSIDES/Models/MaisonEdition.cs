using System.ComponentModel;

namespace VLISSIDES.Models;

public class MaisonEdition
{
    public string Id { get; set; } = default!;

    [DisplayName("Nom")]
    public string Nom { get; set; } = default!;

    [DisplayName("Livres publi�s")]
    public ICollection<Livre> Livres { get; set; } = default!;
}