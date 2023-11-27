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

    public PanierVM(IEnumerable<AfficherPanierVM> listeArticles, decimal? prixTotal,
        IEnumerable<bool> dons, Promotion? promotion, bool promotionAppliquee = false)
    {
        ListeArticles = listeArticles.ToList();
        PrixTotal = prixTotal??0;
        PremierChoixDon = dons.ToList()[0];
        DeuxiemeChoixDon = dons.ToList()[1];
        TroisiemeChoixDon = dons.ToList()[2];
        Promotion = promotion.Nom;
        PromotionAppliquee = promotionAppliquee;
    }
}