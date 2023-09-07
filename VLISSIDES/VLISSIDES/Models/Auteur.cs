namespace VLISSIDES.Models;

public class Auteur
{
    public string Id { get; set; } = default!;

    public string Nom { get; set; } = default!;

    public string Prenom { get; set; } = default!;

    public string Biographie { get; set; } = default!;

    public string Photo { get; set; } = default!;

    public ICollection<Livre> Livres { get; set; } = default!;
}