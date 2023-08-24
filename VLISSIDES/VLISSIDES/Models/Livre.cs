using System;

namespace VLISSIDES.Models;

public class Livre
{
    public string Id { get; set; }
    
    public string Titre { get; set; }
    
    public string Auteur { get; set; }
    
    public string Editeur { get; set; }
    
    public string AnneeEdition { get; set; }
    
    public string Resume { get; set; }
    
    public string Image { get; set; }
    
    public int NbExemplaires { get; set; }
    
    public int NbPages { get; set; }
    
    public string Description { get; set; }
    
    public DateTime DatePublication { get; set; }
    
    public string ISBN { get; set; }
    
    
    
}
