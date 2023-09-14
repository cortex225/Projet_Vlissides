using System.ComponentModel;

namespace VLISSIDES.Models;

public class Promotions
{
   public string Id { get; set; }

   public string Description { get; set; }
   
   public decimal Rabais { get; set; }

   [DisplayName("Date de début")]
   public DateTime DateDebut { get; set; }
   
   [DisplayName("Date de fin")]
   public DateTime DateFin { get; set; }
   
   [DisplayName("Livre en promotion")]
   public string LivreId { get; set; }
   
   public ICollection<Livre>? Livres { get; set; }
}