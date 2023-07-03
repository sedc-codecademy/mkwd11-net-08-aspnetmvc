using PizzaApp.Domain.Enums;

namespace PizzaApp.Domain.Models
{
    public class Order : BaseEntity
    {
        public PaymentMethodEnum PaymentMethod { get; set; }

        public bool IsDelivered { get; set; }

        public string Location { get; set; } = string.Empty;

        public List<PizzaOrder> PizzaOrders { get; set; } = new List<PizzaOrder>();

        public User User { get; set; }

        public int UserId { get; set; }
    }
}
