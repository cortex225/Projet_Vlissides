using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Panier;

public class AfficherPanierVM
{
    [DisplayName("Identifiant")] public string Id { get; set; }

    [DisplayName("Livre")] public string Livre { get; set; }

    [DisplayName("Type de livre")] public string Type { get; set; }

    [DisplayName("Prix original")] public decimal PrixOriginal { get; set; }

    [DisplayName("Identifiant de l'utilisateur")] public string? UtilisateurId { get; set; }

    [DisplayName("Quantité")] public int? Quantite { get; set; }
    [DisplayName("Auteurs")] public List<string>? Auteurs { get; set; }

    [DisplayName("Prix après promotion")] public decimal PrixApresPromotion { get; set; }

    public AfficherPanierVM(LivrePanier livrePanier)
    {
        Id = livrePanier.Id;
        Livre = livrePanier.Livre.Titre;
        Type = livrePanier.TypeLivre.Nom;
        PrixOriginal = livrePanier.PrixOriginal??0;
        UtilisateurId = livrePanier.UserId;
        Quantite = livrePanier.Quantite;
        Auteurs = livrePanier.Livre.LivreAuteurs.Select(a=>a.Auteur.NomAuteur).ToList();
        PrixApresPromotion = livrePanier.PrixApresPromotion??0;
    }
}