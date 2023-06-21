using SEDC.PizzaApp.Models.enums;

namespace SEDC.PizzaApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int PizzaID { get; set; }
        public int UserID { get; set; }

        public Pizza Pizza   { get; set;}
        public User User { get; set;}
        public PaymentMetod PaymentMetod { get; set;}

    }
}
