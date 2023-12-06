using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VLISSIDES.ViewModels.Compte;

public class ConnectionExterneVM
{
    [Required]
    [EmailAddress]
    [DisplayName("Adresse email")] public string Email { get; set; }

    [DisplayName("Nom")][Required] public string Name { get; set; }

    public ConnectionExterneVM(string email, string name)
    {
        Email = email;
        Name = name;
    }
}