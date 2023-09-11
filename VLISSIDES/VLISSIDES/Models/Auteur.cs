using System.ComponentModel.DataAnnotations.Schema;

namespace VLISSIDES.Models;

public class Auteur
{
    public string Id { get; set; } = default!;

    public string Nom { get; set; } = default!;

    public string Prenom { get; set; } = default!;

    [NotMapped]
    public string NomComplet { get => Prenom + " " + Nom; }


    public string Biographie { get; set; } = default!;

    public string Photo { get; set; } = default!;

    public ICollection<Livre> Livres { get; set; } = default!;
}