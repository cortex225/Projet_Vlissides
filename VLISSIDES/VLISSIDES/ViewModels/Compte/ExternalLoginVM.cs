using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Compte;

public class ExternalLoginVM
{
    [Required]
    [EmailAddress]
    [DisplayName("Adresse email")] public string Email { get; set; }

    [DisplayName("Nom")][Required] public string Name { get; set; }

    public ExternalLoginVM(string email, string name)
    {
        Email = email;
        Name = name;
    }
}