using SEDC.PizzaApp.Web.Models.Enums;

namespace SEDC.PizzaApp.Web.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();

        public User User { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
