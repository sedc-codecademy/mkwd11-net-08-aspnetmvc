using SEDC.PizzaApp.Refactored.Domain.Enums;

namespace SEDC.PizzaApp.Refactored.Domain.Models
{
    public class Order : BaseEntity
    {
        public PaymentMethod PaymentMethod { get; set; }
        public bool Delivered { get; set; }
        public string Location { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
