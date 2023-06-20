using SEDC.PizzaApp.Web.Models.Enums;

namespace SEDC.PizzaApp.Web.Models.Domain
{
    public class Order
    {
        public Order(User user, PaymentMethod paymentMethod)
        {
            User = user;
            PaymentMethod = paymentMethod;
        }
        public int Id { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public User User { get; set; }

        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
