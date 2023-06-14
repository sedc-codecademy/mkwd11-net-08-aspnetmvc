namespace SEDC.PizzaApp.Web.Models.Domain
{
    public class Pizza
    {
        public Pizza(Order order, string name, decimal price)
        {
            Order = order ?? throw new ArgumentNullException(nameof(order));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
        }
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool IsOnPromotion { get; set; }

        public Order Order { get; set; }
    }
}
