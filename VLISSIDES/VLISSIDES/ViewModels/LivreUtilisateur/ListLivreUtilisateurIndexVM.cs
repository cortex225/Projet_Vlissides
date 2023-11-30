using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.LivreUtilisateur;

public class ListLivreUtilisateurIndexVM
{
    [Display(Name = "Livres")] public List<LivreUtilisateurIndexVM> Livres { get; set; }
    [Display(Name = "l'identifiant du livre selectionne" +
        "")]
    public string livreSelectionneId { get; set; }

    public ListLivreUtilisateurIndexVM(IEnumerable<LivreUtilisateurIndexVM> livres, string livreSelectionneId)
    {
        this.Livres = livres.ToList();
        this.livreSelectionneId = livreSelectionneId;
    }
}