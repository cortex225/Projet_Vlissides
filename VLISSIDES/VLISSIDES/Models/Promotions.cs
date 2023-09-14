namespace VLISSIDES.Models;

public class Promotions
{
   public string Id { get; set; }

   public string Description { get; set; }
   
   public decimal Rabais { get; set; }

   public DateTime DateDebut { get; set; }

   public DateTime DateFin { get; set; }
   
   public string LivreId { get; set; }
   
   public ICollection<Livre>? Livres { get; set; }
}