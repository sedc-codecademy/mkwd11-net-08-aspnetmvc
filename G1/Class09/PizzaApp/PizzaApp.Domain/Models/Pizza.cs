namespace PizzaApp.Domain.Models
{
    public class Pizza : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public bool IsOnPromotion { get; set; }

        public int Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public List<PizzaOrder> PizzaOrders { get; set; } = new List<PizzaOrder>();
    }
}
