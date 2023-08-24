using System.Collections.Generic;

namespace VLISSIDES.Models;

public class Categorie
{
    public string Id { get; set; }
    
    public string Nom { get; set; }
    
    public string Description { get; set; }
    
    public List<Livre> Livres { get; set; }
    
}