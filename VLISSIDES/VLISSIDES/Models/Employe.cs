using System.ComponentModel;

namespace VLISSIDES.Models;

public class Employe : ApplicationUser
{
    [DisplayName("Num�ro d'employ�")] public string NoEmploye { get; set; } = default!;
}