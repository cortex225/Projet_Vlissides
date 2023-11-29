using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionAuteurs;

public class AuteursIndexVM
{
    [DisplayName("Auteurs")] public List<AuteursAfficherVM> Auteurs { get; set; }
    [DisplayName("Auteur ajouter")] public AuteursAjouterVM AuteurAjouter { get; set; }

    public AuteursIndexVM(List<Auteur> auteurs)
    {
        auteurs ??= new List<Auteur>();
        Auteurs = auteurs.Select(a => new AuteursAfficherVM(a)).ToList();
        AuteurAjouter = new AuteursAjouterVM();
    }
}