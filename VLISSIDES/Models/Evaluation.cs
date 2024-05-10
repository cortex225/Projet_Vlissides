using System.ComponentModel;

namespace VLISSIDES.Models;

public class Evaluation
{
    public string Id { get; set; } = default!;

    [DisplayName("Note")] public int Note { get; set; } = default!;

    [DisplayName("Date de l'évaluation")] public DateTime DateEvaluation { get; set; } = default!;

    [DisplayName("Identifiant du membre")] public string MembreId { get; set; } = default!;

    [DisplayName("Membre ayant évalué")] public Membre Membre { get; set; } = default!;

    [DisplayName("Identifiant du livre")] public string LivreId { get; set; } = default!;

    [DisplayName("Livre commenté")] public Livre Livre { get; set; } = default!;
}