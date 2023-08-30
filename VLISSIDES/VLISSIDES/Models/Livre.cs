namespace VLISSIDES.Models;

public class Livre
{
    public string Id { get; set; }

    public string Titre { get; set; }
    
    public string Resume { get; set; }

    public string Couverture { get; set; }

    public int NbExemplaires { get; set; }

    public DateTime DateAjout { get; set; }

    public int NbPages { get; set; }

    public double Prix { get; set; }

    public DateTime DatePublication { get; set; }

    public string ISBN { get; set; }

    public string CategorieId { get; set; }
    
    public string AuteurId { get; set; }
    
    public ICollection<Auteur> Auteur { get; set; }
    
    public string? MaisonEditionId { get; set; }
    
    public MaisonEdition? MaisonEdition { get; set; }

    public ICollection<Categorie> Categories { get; set; }

    public string TypeLivreId { get; set; }

    public ICollection<TypeLivre> TypesLivre { get; set; }

    public string EvaluationId { get; set; }

    public ICollection<Evaluation>? Evaluations { get; set; }

    public string LangueId { get; set; }

    public ICollection<Langue> Langues { get; set; }
    
    public ICollection<Favori>? Favoris { get; set; }

    public ICollection<LivreCommande>? LivreCommandes { get; set; }

}