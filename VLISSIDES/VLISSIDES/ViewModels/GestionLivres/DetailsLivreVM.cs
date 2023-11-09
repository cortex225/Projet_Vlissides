using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionLivres
{
    public class DetailsLivreVM
    {
        public string Id { get; set; }
        public string Titre { get; set; }
        public List<string> Auteurs { get; set; }
        public List<string> Categories { get; set; }
        public DateTime DatePublication { get; set; }
        public string Couverture { get; set; }
        public string MaisonEdition { get; set; }
        public int NbPages { get; set; }
        public string Resume { get; set; }
        public int NbExemplaires { get; set; }
        public Decimal? Papier { get; set; }
        public Decimal? Numerique { get; set; }
        public int Note { get; set; }

        public string ISBN { get; set; }

        public string Langue { get; set; }

        public DetailsLivreVM(Livre livre)
        {
            Id = livre.Id;
            Titre = livre.Titre;
            Auteurs = livre.LivreAuteurs.Select(a => a.Auteur.NomAuteur).ToList();
            Categories = livre.Categories.Select(c => c.Categorie.Nom).ToList();
            DatePublication = livre.DatePublication;
            Couverture = livre.Couverture;
            MaisonEdition = livre.Couverture;
            NbPages = livre.NbPages;
            Resume = livre.Resume;
            if (!livre.Evaluations.Equals(null))
                Note = (int)livre.Note;
            else Note = 0;
            ISBN = livre.ISBN;
            Langue = livre.Langue.Nom;
            NbExemplaires = livre.NbExemplaires;
            foreach (var media in livre.LivreTypeLivres)
                switch (media.TypeLivre.Nom)
                {
                    case "Papier": Papier = media.Prix; break;
                    case "Numérique": Numerique = media.Prix; break;
                }
        }
    }
}
