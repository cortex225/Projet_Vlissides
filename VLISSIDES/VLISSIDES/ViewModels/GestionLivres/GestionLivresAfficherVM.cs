using VLISSIDES.Models;

namespace VLISSIDES.ViewModels.GestionLivres;

public class GestionLivresAfficherVM
{
    public string Id { get; set; }
    public string Image { get; set; }
    public string Titre { get; set; }
    public string ISBN { get; set; }

    public string Categorie { get; set; }
    public ICollection<LivreTypeLivre> LivreTypeLivres { get; set; }

    //public ICollection<Auteur>? Auteur { get; set; }
    public ICollection<Auteur>? ListAuteur { get; set; }

    public int Quantite { get; set; }
}