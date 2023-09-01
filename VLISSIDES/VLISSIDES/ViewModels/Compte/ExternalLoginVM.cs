using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Compte;

public class ExternalLoginVM
{
    [Required] [EmailAddress] public string Email { get; set; } = default!;

    [Required] public string Name { get; set; } = default!;
}