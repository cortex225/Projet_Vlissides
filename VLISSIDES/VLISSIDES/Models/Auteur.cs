using System.ComponentModel;

namespace VLISSIDES.Models;

public class Auteur
{
    public string Id { get; set; } = default!;

    [DisplayName("Nom de l'auteur")] public string NomAuteur { get; set; } = default!;

    [DisplayName("Livres écrits")] public ICollection<LivreAuteur> Livres { get; set; } = default!;

    [DisplayName("Promotions reliées")] public ICollection<Promotions> Promotions { get; set; } = default!;
}