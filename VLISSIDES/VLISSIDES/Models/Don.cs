namespace VLISSIDES.Models
{
    public class Don
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public double Montant { get; set; } = 5.00;

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
