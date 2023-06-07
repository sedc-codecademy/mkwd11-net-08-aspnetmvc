
using PizzaApp.Models;

namespace PizzaApp
{
    public static class StaticDb
    {
        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza()
            {
                Id = 1,
                Name = "Capricciosa",
                Price = 300,
                IsOnPromotion = true
            },
            new Pizza()
            {
                Id = 2,
                Name = "Pepperoni",
                Price = 350,
                IsOnPromotion = false
            }

        };
    }
}
