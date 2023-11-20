namespace VLISSIDES.ViewModels.LivreUtilisateur
{
    public class LivreUtilisateurIndexVM
    {
        public string Id { get; set; }
        public string Titre { get; set; }
        public string Couverture { get; set; }
        public string NumeriqueURL { get; set; }
        public List<string> Auteurs { get; set; }
        public List<string> Categories { get; set; }
        public string MaisonEdition { get; set; }
        public double? monEvaluation { get; set; }
        public DateTime DateCommande { get; set; }
    }
}
