using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Compte;

public class ExternalLoginVM
{
    [DisplayName("Adresse email")]
    [Required] [EmailAddress] public string Email { get; set; } = default!;

    [DisplayName("Nom")]
    [Required] public string Name { get; set; } = default!;
}