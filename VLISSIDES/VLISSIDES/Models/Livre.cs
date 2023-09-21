using System.ComponentModel;

namespace VLISSIDES.Models;

public class Livre
{
    public string Id { get; set; } = default!;

    [DisplayName("Titre")] public string Titre { get; set; } = default!;

    [DisplayName("Résumé")] public string Resume { get; set; } = default!;

    [DisplayName("Page couverture")] public string Couverture { get; set; } = default!;

    [DisplayName("Nombre d'exemplaires disponibles")]
    public int NbExemplaires { get; set; } = default!;

    [DisplayName("Date d'ajout")] public DateTime DateAjout { get; set; } = default!;

    [DisplayName("Nombre de pages")] public int NbPages { get; set; } = default!;

    [DisplayName("Prix")] public double Prix { get; set; } = default!;

    [DisplayName("Date de publication")] public DateTime DatePublication { get; set; } = default!;

    [DisplayName("ISBN")] public string ISBN { get; set; } = default!;

    [DisplayName("Identifiant de l'auteur")]
    public string AuteurId { get; set; } = default!;

    [DisplayName("Auteur(s)")] public ICollection<Auteur> Auteurs { get; set; } = default!;

    [DisplayName("Identifiant de la maison d'édition")]
    public string? MaisonEditionId { get; set; }

    [DisplayName("Maison d'édition")] public MaisonEdition? MaisonEdition { get; set; }

    [DisplayName("Catégories associés")] public ICollection<Categorie> Categories { get; set; } = default!;

    [DisplayName("Identifiant du type(s) de livre")] public string TypesLivreId { get; set; } = default!;

    [DisplayName("Type(s) de livre")] public TypeLivre TypesLivre { get; set; } = default!;

    [DisplayName("Évaluations")] public ICollection<Evaluation>? Evaluations { get; set; }

    [DisplayName("L'identifiant de la langue")] public Langue LangueId { get; set; } = default!;

    [DisplayName("Langues")] public Langue Langue { get; set; } = default!;

    [DisplayName("Favoris")] public ICollection<Favori>? Favoris { get; set; }

    [DisplayName("Livres commande")] public ICollection<LivreCommande>? LivreCommandes { get; set; }

    [DisplayName("Promotions")] public ICollection<Promotions>? Promotions { get; set; }
}