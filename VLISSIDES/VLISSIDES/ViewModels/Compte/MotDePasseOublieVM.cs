using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Compte;

public class MotDePasseOublieVM
{
    [Display(Name = "Nom de l'utilisateur")] public string? UserName { get; set; }


    [Required]
    [EmailAddress]
    [Display(Name = "Email")] public string Email { get; set; }

    public MotDePasseOublieVM(string? userName, string email)
    {
        UserName = userName;
        Email = email;
    }
}