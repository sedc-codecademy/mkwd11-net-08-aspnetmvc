using SEDC.PizzaApp.Data.Enums;

namespace SEDC.PizzaApp.Data.Models
{
    public class Order
        : BaseEntity
    {
        public Order(User user, PaymentMethod paymentMethod)
        {
            User = user;
            PaymentMethod = paymentMethod;
            User.Orders.Add(this);
        }
        public PaymentMethod PaymentMethod { get; set; }

        public User User { get; set; }

        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
