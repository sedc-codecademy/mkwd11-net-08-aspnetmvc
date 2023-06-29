using SEDC.PizzaApp.Refactored.Domain.Enums;
using SEDC.PizzaApp.Refactored.Domain.Users;

namespace SEDC.PizzaApp.Refactored.Domain.Orders
{
    public class Order : BaseEntity
    {
        //FK column
        public int UserId { get; set; }
        public User User { get; set; }

        //column (int)
        public PaymentMethod PaymentMethod { get; set; }

        //column (bit)
        public bool IsDelivered { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }
    }
}
