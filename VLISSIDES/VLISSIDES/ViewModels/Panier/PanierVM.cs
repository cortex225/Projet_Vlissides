using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Panier;

public class PanierVM
{
    [DisplayName("Identifiant")] public List<AfficherPanierVM> ListeArticles { get; set; }
    [DisplayName("Identifiant")] public decimal PrixTotal { get; set; }
    [DisplayName("Identifiant")] public bool PremierChoixDon { get; set; }
    [DisplayName("Identifiant")] public bool DeuxiemeChoixDon { get; set; }
    [DisplayName("Identifiant")] public bool TroisiemeChoixDon { get; set; }

    [DisplayName("Identifiant")] public string? Promotion { get; set; }

    [DisplayName("Identifiant")] public bool PromotionAppliquee { get; set; }

    public PanierVM(IEnumerable<AfficherPanierVM> listeArticles, decimal? prixTotal = null, Promotion? promotion = null,
        bool promotionAppliquee = false)
    {
        ListeArticles = listeArticles.ToList();
        PrixTotal = prixTotal ?? 0;
        PremierChoixDon = false;
        DeuxiemeChoixDon = false;
        TroisiemeChoixDon = false;
        Promotion = (promotion ?? new()).Nom;
        PromotionAppliquee = promotionAppliquee;
    }
}