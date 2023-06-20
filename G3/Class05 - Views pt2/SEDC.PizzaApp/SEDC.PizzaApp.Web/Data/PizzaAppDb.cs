using SEDC.PizzaApp.Web.Models.Domain;

namespace SEDC.PizzaApp.Web.Data
{
    public static class PizzaAppDb
    {
        private static readonly User defaultUser = new ("Jovan", "Gjorgjiev", "123/123/123")
        {
            Id = 1,
        };

        private static readonly Order defaultOrder = new(defaultUser, Models.Enums.PaymentMethod.Card)
        {
            Id = 1,
        };

        public static ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>
        {
            new Pizza(defaultOrder, "Margarita", 200)
            {
                Id = 1,
                IsOnPromotion = false
            },
            new Pizza(defaultOrder, "Special", 350)
            {
                Id = 2,
                IsOnPromotion = false
            }
        };

        public static ICollection<Order> Orders { get; set; } = new List<Order>()
        {
            defaultOrder
        };

        public static ICollection<User> Users { get; set; } = new List<User>
        {
            defaultUser
        };
    }
}
