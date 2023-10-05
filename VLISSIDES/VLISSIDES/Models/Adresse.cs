using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace VLISSIDES.Models;

public class Adresse
{
    public string Id { get; set; } = default!;

    [DisplayName("Numéro civique")] public string NoCivique { get; set; } = default!;

    [DisplayName("Rue")] public string Rue { get; set; } = default!;

    [DisplayName("Ville")] public string Ville { get; set; } = default!;

    [DisplayName("Province")] public string Province { get; set; } = default!;

    [DisplayName("Code postal")] public string CodePostal { get; set; } = default!;

    [DisplayName("Pays")] public string Pays { get; set; } = default!;


    // Propriété de navigation pour l'utilisateur principal
    [DisplayName("Identifiant de utilisateur principal")]
    public string? UtilisateurPrincipalId { get; set; }

    [NotMapped]
    [DisplayName("Utilisateur principal")]
    public ApplicationUser? UtilisateurPrincipal { get; set; }

    // Propriété de navigation pour l'utilisateur de livraison
    [DisplayName("Identifiant de utilisateur de livraison")]
    public string? UtilisateurLivraisonId { get; set; }

    [NotMapped]
    [DisplayName("Utilisateur de livraison")]
    public ApplicationUser? UtilisateurLivraison { get; set; }
}