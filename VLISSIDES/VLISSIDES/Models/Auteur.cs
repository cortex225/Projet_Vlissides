using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLISSIDES.Models;

public class Auteur
{
    public string Id { get; set; } = default!;

    [DisplayName("Nom")] public string Nom { get; set; } = default!;

    [DisplayName("Pr�nom")] public string Prenom { get; set; } = default!;

    [NotMapped]
    [DisplayName("Nom complet")]
    public string NomComplet => Prenom + " " + Nom;

    [DisplayName("Livres �crits")] public ICollection<Livre> Livres { get; set; } = default!;
}