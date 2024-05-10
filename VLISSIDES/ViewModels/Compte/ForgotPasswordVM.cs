using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Compte;

public class ForgotPasswordVM
{
    [Display(Name = "Nom de l'utilisateur")] public string? UserName { get; set; }


    [Required]
    [EmailAddress]
    [Display(Name = "Email")] public string Email { get; set; }

    public ForgotPasswordVM()
    {
        UserName = "";
        Email = "";
    }

    public ForgotPasswordVM(string? userName, string email)
    {
        UserName = userName;
        Email = email;
    }
}