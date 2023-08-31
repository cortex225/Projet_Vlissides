namespace VLISSIDES.Models;

public class Adresse
{
    public string Id { get; set; }

    public string NoCivique { get; set; }

    public string Rue { get; set; }

    public string Ville { get; set; }

    public string Province { get; set; }

    public string CodePostal { get; set; }

    public string Pays { get; set; }


    // Propriété de navigation pour l'utilisateur principal
    public string? UtilisateurPrincipalId { get; set; }
    public ApplicationUser? UtilisateurPrincipal { get; set; }

    // Propriété de navigation pour l'utilisateur de livraison
    public string? UtilisateurLivraisonId { get; set; }
    public ApplicationUser? UtilisateurLivraison { get; set; }
    
}