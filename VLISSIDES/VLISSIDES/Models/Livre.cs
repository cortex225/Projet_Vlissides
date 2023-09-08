namespace VLISSIDES.Models;

public class Livre
{
    public string Id { get; set; } = default!;

    public string Titre { get; set; } = default!;

    public string Resume { get; set; } = default!;

    public string Couverture { get; set; } = default!;

    public int NbExemplaires { get; set; } = default!;

    public DateTime DateAjout { get; set; } = default!;

    public int NbPages { get; set; } = default!;

    public double Prix { get; set; } = default!;

    public DateTime DatePublication { get; set; } = default!;

    public string ISBN { get; set; } = default!;

    public string CategorieId { get; set; } = default!;

    public string AuteurId { get; set; } = default!;

    public ICollection<Auteur> Auteur { get; set; } = default!;

    public string? MaisonEditionId { get; set; }

    public MaisonEdition? MaisonEdition { get; set; }

    public ICollection<Categorie> Categories { get; set; } = default!;

    public string? TypeLivreId { get; set; } = default!;

    public ICollection<TypeLivre> TypesLivre { get; set; } = default!;

    public string? EvaluationId { get; set; } = default!;

    public ICollection<Evaluation>? Evaluations { get; set; }

    public string LangueId { get; set; } = default!;

    public ICollection<Langue> Langues { get; set; } = default!;

    public ICollection<Favori>? Favoris { get; set; }

    public ICollection<LivreCommande>? LivreCommandes { get; set; }
}