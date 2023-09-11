using System.ComponentModel;

namespace VLISSIDES.Models;

public class Employe : ApplicationUser
{
    [DisplayName("Numéro d'employé")]
    public string NoEmploye { get; set; } = default!;
}