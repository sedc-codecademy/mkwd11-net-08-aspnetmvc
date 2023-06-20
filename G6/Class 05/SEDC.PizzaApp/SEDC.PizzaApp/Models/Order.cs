using SEDC.PizzaApp.Models.Enums;

namespace SEDC.PizzaApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        //in the db this will be translated into an int (1, 2)
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsDelivered { get; set; }
    }
}
