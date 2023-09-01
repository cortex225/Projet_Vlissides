using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Compte;

public class ForgotPasswordVM
{
    public string? UserName { get; set; }


    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = default!;
}