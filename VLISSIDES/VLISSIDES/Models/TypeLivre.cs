namespace VLISSIDES.Models;

public class TypeLivre
{
    public string Id { get; set; }

    public string Nom { get; set; }
    
    public ICollection<Livre> Livres { get; set; }
}