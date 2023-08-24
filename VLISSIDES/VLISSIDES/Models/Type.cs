using System.Collections.Generic;

namespace VLISSIDES.Models;

public class Type
{
    
    public string Id { get; set; }
    
    public string Nom { get; set; }
    
    public List<Livre> Livres { get; set; }
}