using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Panier;

public class AfficherPanierVM
{
    [DisplayName("Identifiant")] public string Id { get; set; }
    [DisplayName("Identifiant du livre")] public string LivreId { get; set; }

    [DisplayName("Livre")] public string Livre { get; set; }
    [DisplayName("Couverture de livre")] public string Couverture { get; set; }

    [DisplayName("Type de livre")] public string Type { get; set; }

    [DisplayName("Prix original")] public decimal PrixOriginal { get; set; }

    [DisplayName("Identifiant de l'utilisateur")] public string? UtilisateurId { get; set; }

    [DisplayName("Quantité")] public int? Quantite { get; set; }
    [DisplayName("Auteurs")] public List<string>? AuteursIds { get; set; }
    [DisplayName("Auteurs")] public List<string>? Auteurs { get; set; }
    [DisplayName("Auteurs")] public List<string>? CategoriesIds { get; set; }
    [DisplayName("Auteurs")] public string? MaisonEditionId { get; set; }

    [DisplayName("Prix après promotion")] public decimal PrixApresPromotion { get; set; }

    public AfficherPanierVM(LivrePanier livrePanier)
    {
        Id = livrePanier.Id;
        LivreId = livrePanier.Livre.Id;
        Livre = livrePanier.Livre.Titre;
        Livre = livrePanier.Livre.Couverture;
        Type = livrePanier.TypeLivre.Nom;
        PrixOriginal = livrePanier.PrixOriginal ?? 0;
        UtilisateurId = livrePanier.UserId;
        Quantite = livrePanier.Quantite;
        AuteursIds = livrePanier.Livre.LivreAuteurs.Select(a => a.Auteur.Id).ToList();
        Auteurs = livrePanier.Livre.LivreAuteurs.Select(a => a.Auteur.NomAuteur).ToList();
        CategoriesIds = livrePanier.Livre.Categories.Select(a => a.Categorie.Id).ToList();
        MaisonEditionId = livrePanier.Livre.MaisonEditionId;
        PrixApresPromotion = livrePanier.PrixApresPromotion ?? 0;
    }
}