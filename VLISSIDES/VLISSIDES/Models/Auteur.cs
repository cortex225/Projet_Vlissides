namespace VLISSIDES.Models;

public class Auteur
{
    public string Id { get; set; }

    public string Nom { get; set; }

    public string Prenom { get; set; }

    public string Biographie { get; set; }

    public string Photo { get; set; }

    public ICollection<Livre> Livres { get; set; }
}