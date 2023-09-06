namespace VLISSIDES.Models;

public class Adresse
{
    public string Id { get; set; } = default!;

    public string NoCivique { get; set; } = default!;

    public string Rue { get; set; } = default!;

    public string Ville { get; set; } = default!;

    public string Province { get; set; } = default!;

    public string CodePostal { get; set; } = default!;

    public string Pays { get; set; } = default!;


    // Propriété de navigation pour l'utilisateur principal
    public string? UtilisateurPrincipalId { get; set; }
    public ApplicationUser? UtilisateurPrincipal { get; set; }

    // Propriété de navigation pour l'utilisateur de livraison
    public string? UtilisateurLivraisonId { get; set; }
    public ApplicationUser? UtilisateurLivraison { get; set; }
}