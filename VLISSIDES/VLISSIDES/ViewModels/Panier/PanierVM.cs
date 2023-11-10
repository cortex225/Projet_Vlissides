namespace VLISSIDES.ViewModels.Panier
{
    public class PanierVM
    {
        public List<AfficherPanierVM> ListeArticles { get; set; }
        public double PrixTotal { get; set; }
        public bool PremierChoixDon { get; set; }
        public bool DeuxiemeChoixDon { get; set; }
        public bool TroisiemeChoixDon { get; set; }

    }
}
