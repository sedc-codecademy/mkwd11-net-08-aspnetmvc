using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Enums;

namespace SEDC.PizzaApp
{
    public static class StaticDb
    {
        public static int PizzaId = 2;
        public static List<Pizza> Pizzas = new List<Pizza>()
        {
            new Pizza()
            {
                Id = 1,
                Name = "Capri",
                Price = 350,
                IsOnPromotion = true,
            },
            new Pizza()
            {
                Id = 2,
                Name = "Pepperoni",
                Price = 400,
                IsOnPromotion = false,
            }
        };

        public static int UserId = 2;
        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Bobsky",
                PhoneNumber = "54623462"
            },
            new User()
            {
                Id = 2,
                FirstName = "Kate",
                LastName = "Katesky",
                PhoneNumber = "54677462"
            }
        };

        public static int OrderId = 2;
        public static List<Order> Orders = new List<Order>()
        {
            new Order()
            {
                Id = 1,
                UserId = 1,
                PizzaId = 1,
                User = Users.First(x => x.Id == 1),
                Pizza = Pizzas.First(x => x.Id == 1),
                PaymentMethod = PaymentMethod.Cash
            },
            new Order()
            {
                Id = 2,
                UserId = 2,
                PizzaId = 2,
                User = Users.First(x => x.Id == 2),
                Pizza = Pizzas.First(x => x.Id == 2),
                PaymentMethod = PaymentMethod.Cash
            }
        };
    }
}
