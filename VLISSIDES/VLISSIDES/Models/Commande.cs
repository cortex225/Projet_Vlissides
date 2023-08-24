using System;
using System.Collections.Generic;

namespace VLISSIDES.Models;

public class Commande
{
    
    public string Id { get; set; }
    
    public DateTime DateCommande { get; set; }
    
    public decimal PrixTotal { get; set; }
    
    public ApplicationUser Client { get; set; }
    
    public string IdEmploye { get; set; }
    
    public Employe Employe { get; set; }
    
    public List<Livre> Livres { get; set; }
    
    public string IdAdresse { get; set; }
    
    public Adresse AdresseLivraison { get; set; }
}