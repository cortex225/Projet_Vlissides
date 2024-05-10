using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Paiement;

public class PaiementCardVM
{
    [Display(Name = "Numéro de carte")]
    [Required(ErrorMessage = "Le numéro de carte est requis")]
    [CreditCard(ErrorMessage = "Le numéro de carte n'est pas valide")]
    public string CardNumber { get; set; }

    [Display(Name = "Mois d'expiration")]
    [Required(ErrorMessage = "Le mois d'expiration est requis")]
    [Range(1, 12, ErrorMessage = "Le mois d'expiration doit être entre 1 et 12")]
    public string ExpiryMonth { get; set; }

    [Display(Name = "Année d'expiration")]
    [Required(ErrorMessage = "L'année d'expiration est requise")]
    [Range(2021, 2030, ErrorMessage = "L'année d'expiration doit être entre 2021 et 2030")]
    public string ExpiryYear { get; set; }

    [Display(Name = "CVV")]
    [Required(ErrorMessage = "Le CVV est requis")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "Le CVV doit être de 3 chiffres")]
    public string CVV { get; set; }
}