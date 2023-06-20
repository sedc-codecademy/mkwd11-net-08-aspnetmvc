using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Enums;

namespace SEDC.PizzaApp
{
    public static class StaticDb
    {
        public static string Message = "Message 1";
        public static int UserId = 2;
        public static List<Pizza> Pizzas = new List<Pizza> {
        new Pizza()
        {
            Id = 1,
            Name = "Capri",
            Price = 300,
            IsOnPromotion = true
        },
        new Pizza()
        {
            Id = 2,
            Name = "Pepperoni",
            Price = 400,
            IsOnPromotion = false
        }
    };
        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName ="Bob",
                LastName = "Bobsky",
                PhoneNumber = "5253252322"
            },
             new User
            {
                Id = 2,
                FirstName ="Kate",
                LastName = "Katesky",
                PhoneNumber = "78979879"
            }
        };

        public static List<Order> Orders = new List<Order>
        {
            new Order
            {
                Id = 1,
                PizzaId = 1,
                UserId = 2,
                Pizza = Pizzas.First(),
                User = Users.First(x => x.Id == 2),
                PaymentMethod = PaymentMethod.Cash,
                Delivered = true
            },
            new Order
            {
                Id = 2,
                PizzaId = 1,
                UserId = 2,
                Pizza = Pizzas.First(x => x.Id == 2),
                User = Users.First(x => x.Id == 1),
                PaymentMethod = PaymentMethod.Card,
                Delivered = false
            }
        };
    }
}
