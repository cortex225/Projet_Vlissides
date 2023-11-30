using System.ComponentModel.DataAnnotations;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.LivreUtilisateur
{
    public class LivreUtilisateurIndexVM
    {
        [Display(Name = "Identifiant")] public string Id { get; set; }
        [Display(Name = "Titre")] public string Titre { get; set; }
        [Display(Name = "Couverture")] public string Couverture { get; set; }
        [Display(Name = "Chemin de l'image numerique")] public string NumeriqueURL { get; set; }
        [Display(Name = "Auteurs")] public List<string> Auteurs { get; set; }
        [Display(Name = "Categories")] public List<string> Categories { get; set; }
        [Display(Name = "Maison d'édition")] public string MaisonEdition { get; set; }
        [Display(Name = "Mon evaluation")] public double? MonEvaluation { get; set; }
        [Display(Name = "Date commande")] public DateTime DateCommande { get; set; }

        public LivreUtilisateurIndexVM(Livre livre, Evaluation evaluation, Commande commande)
        {
            Id = livre.Id;
            Titre = livre.Titre;
            Couverture = livre.Couverture;
            NumeriqueURL = livre.UrlNumerique ?? "";
            Auteurs = (livre.LivreAuteurs ?? new()).Select(la => la.Auteur.NomAuteur).ToList();
            Categories = livre.Categories.Select(c => c.Categorie.Nom).ToList();
            MaisonEdition = (livre.MaisonEdition ?? new()).Nom;
            MonEvaluation = evaluation.Note;
            DateCommande = commande.DateCommande;
        }
    }
}
