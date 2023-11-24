using System.ComponentModel;
using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionAuteurs;

public class AuteursAfficherVM
{
    [DisplayName("Identifiant")] public string Id { get; set; }
    [DisplayName("Nom")] public string Nom { get; set; }
    [DisplayName("Livres")] public List<string> Livres { get; set; }

    public AuteursAfficherVM(Auteur auteur)
    {
        auteur ??= new();
        Id = auteur.Id;
        Nom = auteur.NomAuteur;
        if (auteur.Livres != null) Livres = auteur.Livres.Select(l => l.Livre.Titre).ToList();
        else Livres = new List<string>();
    }
}