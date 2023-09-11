//ViewModel pour _CarteLivre.cshtml et CarteLivrePetit.cshtml

using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.Accueil
{
    public class _LivreCardVM
    {
        public string Couverture { get; set; }
        public string Titre { get; set; }
        public double Prix { get; set; }
        public string Auteurs { get; set; }
        public int Score { get; set; }
        public List<string> Categories { get; set; }

        public _LivreCardVM(string couverture = "", string titre = "", double prix = 0, List<Auteur> auteurs = default!, List<Categorie> categories = default!)
        {
            auteurs ??= new();
            categories ??= new();
            Couverture = couverture;
            Titre = titre;
            Prix = prix;
            Auteurs = "";
            if (auteurs.Any())
            {
                auteurs.ForEach(auteur => Auteurs += auteur.NomComplet + ", ");
                Auteurs.Remove(Auteurs.Length - 2, 2);
            }
            Categories ??= new();
            categories.ForEach(categorie => Categories.Add(categorie.Nom));
        }
        public _LivreCardVM(Livre livre)
        {
            livre.Evaluations ??= new List<Evaluation>();
            Couverture = livre.Couverture;
            Titre = livre.Titre;
            Prix = livre.Prix;
            Auteurs = "";
            Score = (int)livre.Evaluations.Select(evaluation => evaluation.Note).Average();
            if (!((List<Auteur>)livre.Auteur).Any())
            {
                ((List<Auteur>)livre.Auteur).ForEach(auteur => Auteurs += auteur.NomComplet + ", ");
                Auteurs.Remove(Auteurs.Length - 2, 2);
            }
            Categories ??= new();
            ((List<Auteur>)livre.Categories).ForEach(categorie => Categories.Add(categorie.Nom));
        }
    }
}
