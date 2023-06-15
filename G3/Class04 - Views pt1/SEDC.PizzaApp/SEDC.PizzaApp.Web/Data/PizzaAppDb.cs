using SEDC.PizzaApp.Web.Models.Domain;

namespace SEDC.PizzaApp.Web.Data
{
    public static class PizzaAppDb
    {
        public static ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>
        {
            new Pizza
            {
                Id = 1,
                Name = "Margarita",
                Price = 200,
                IsOnPromotion = false
            },
            new Pizza
            { 
                Id = 2, 
                Name = "Special",
                Price = 350,
                IsOnPromotion = false
            }
        };

        public static ICollection<Order> Orders { get; set; } = new List<Order>()
        {
            new Order
            {
                Id = 1,
                PaymentMethod = Models.Enums.PaymentMethod.Card,
                User = new User("Jovan", "Gjorgjiev", "123/123/123")
                {
                    Id = 1,
                }
            }
        };

        public static ICollection<User> Users { get; set; } = new List<User>
        {
            new User("Jovan", "Gjorgjiev", "123/123/123")
            {
                    Id = 1,

            }
        };
    }
}
