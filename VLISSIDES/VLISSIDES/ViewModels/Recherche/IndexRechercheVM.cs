using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Recherche;

public class IndexRechercheVM
{
    public string? MotRecherche { get; set; } //Juste le mot clé que l'on va afficher dans le message 

    //"Résultat de recherche pour "MotRecherche"
    public List<Livre> ResultatRecherche { get; set; } = new();
    public List<Categorie> ListeCategories { get; set; } = new();
    public List<Langue> ListeLangues { get; set; } = new();
    public List<TypeLivre> ListeTypeLivres { get; set; } = new();

    public double minPrix { get; set; } = 0.0;
    public double maxPrix { get; set; } = 199.99;
}