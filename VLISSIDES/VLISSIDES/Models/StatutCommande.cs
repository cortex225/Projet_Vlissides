using System.Collections.Generic;

namespace VLISSIDES.Models;

public class StatutCommande
{
    
    public string Id { get; set; }
    
    public string Nom { get; set; }
    
    public string Description { get; set; }
    
    public ICollection<Commande> Commandes { get; set; }
}