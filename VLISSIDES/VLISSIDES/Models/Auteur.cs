using System.ComponentModel;

namespace VLISSIDES.Models;

public class Auteur
{
    public string Id { get; set; } = default!;

    [DisplayName("Nom de l'auteur")] public string NomAuteur { get; set; } = default!;

    [DisplayName("Livres écrits")] public ICollection<Livre> Livres { get; set; } = default!;
}