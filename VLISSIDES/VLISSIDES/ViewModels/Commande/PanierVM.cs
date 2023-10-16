namespace VLISSIDES.ViewModels.Commande;

public class PanierVM
{
    public List<ArticlePanier> Articles { get; set; } = new List<ArticlePanier>();

    public decimal Total
    {
        get
        {
            decimal total = 0;
            foreach (var article in Articles)
            {
                total += article.Total;
            }

            return total;
        }
    }
}

public class ArticlePanier
{
    public string Id { get; set; } // Id de l'article (livre)
    public string Nom { get; set; } // Nom du livre
    public decimal PrixParArticle { get; set; } // Prix du livre
    public int Quantite { get; set; } // Quantité sélectionnée par l'utilisateur

    public decimal Total
    {
        get { return PrixParArticle * Quantite; }
    }
}

