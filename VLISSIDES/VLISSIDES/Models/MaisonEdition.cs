namespace VLISSIDES.Models;

public class MaisonEdition
{
    public string Id { get; set; } = default!;

    public string Nom { get; set; } = default!;

    public ICollection<Livre> Livres { get; set; } = default!;
}