namespace VLISSIDES.ViewModels.Livres
{
    public class GestionLivresAjouterVM
    {
        public string Titre { get; set; }
        public string Resume { get; set; }
        public string Couverture { get; set; }
        public int NbExemplaires { get; set; }
        public int NbPages { get; set; }
        public double Prix { get; set; }
        public DateTime DatePublication { get; set; }

        public string ISBN { get; set; }

        public string CategorieId { get; set; }
        public string AuteurId { get; set; }
        public string MaisonEditionId { get; set; }

        public string TypeLivreId { get; set; }
        public string EvaluationId { get; set; }
        public string LangueId { get; set; }

    }
}
