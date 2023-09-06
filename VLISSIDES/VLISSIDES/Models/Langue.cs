namespace VLISSIDES.Models;

public class Langue
{
    public string Id { get; set; } = default!;

    public string Nom { get; set; } = default!;

    public string Code { get; set; } = default!;

    public ICollection<Livre>? Livres { get; set; }
}