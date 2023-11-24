using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionLivres
{
    public class DetailsLivreVM
    {
        [Display(Name = "Identifiant")] public string Id { get; set; }
        [Display(Name = "Titre")] public string Titre { get; set; }
        [Display(Name = "Auteurs")] public List<string> Auteurs { get; set; }
        [Display(Name = "Catégories")] public List<string> Categories { get; set; }
        [Display(Name = "Date de publication")] public DateTime DatePublication { get; set; }
        [Display(Name = "Couverture")] public string Couverture { get; set; }
        [Display(Name = "Edition")] public string MaisonEdition { get; set; }
        [Display(Name = "Nombre de page")] public int NbPages { get; set; }
        [Display(Name = "Resume")] public string Resume { get; set; }
        [Display(Name = "Nom du livre")] public int NbExemplaires { get; set; }
        [Display(Name = "Papier")] public Decimal? Papier { get; set; }
        [Display(Name = "Numerique")] public Decimal? Numerique { get; set; }
        [Display(Name = "Note")] public int Note { get; set; }

        [Display(Name = "ISBN")] public string ISBN { get; set; }

        [Display(Name = "Langue")] public string Langue { get; set; }

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
