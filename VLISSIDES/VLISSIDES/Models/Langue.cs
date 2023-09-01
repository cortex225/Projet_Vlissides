namespace VLISSIDES.Models;

public class Langue
{
    public string Id { get; set; }

    public string Nom { get; set; }

    public string Code { get; set; }

    public ICollection<Livre>? Livres { get; set; }
}