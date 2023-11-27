using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Paiement;

public class PaiementCardVM
{
    [Required(ErrorMessage = "Le numéro de carte est requis")]
    [CreditCard(ErrorMessage = "Le numéro de carte n'est pas valide")]
    [Display(Name = "Numéro de carte")] public string NumereauCarte { get; set; }

    [Required(ErrorMessage = "Le mois d'expiration est requis")]
    [Range(1, 12, ErrorMessage = "Le mois d'expiration doit être entre 1 et 12")]
    [Display(Name = "Mois d'expiration")] public string MoiExpiration { get; set; }

    [Required(ErrorMessage = "L'année d'expiration est requise")]
    [Range(2021, 2030, ErrorMessage = "L'année d'expiration doit être entre 2021 et 2030")]
    [Display(Name = "Année d'expiration")] public string AnneeExpiration { get; set; }

    [Required(ErrorMessage = "Le CVV est requis")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "Le CVV doit être de 3 chiffres")]
    [Display(Name = "CVV")] public string CVV { get; set; }

    public PaiementCardVM(string numereauCarte, string moiExpiration, string anneeExpiration, string cVV)
    {
        NumereauCarte = numereauCarte;
        MoiExpiration = moiExpiration;
        AnneeExpiration = anneeExpiration;
        CVV = cVV;
    }
}