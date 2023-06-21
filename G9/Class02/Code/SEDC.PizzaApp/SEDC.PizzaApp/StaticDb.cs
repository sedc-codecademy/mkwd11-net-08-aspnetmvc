using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.enums;

namespace SEDC.PizzaApp
{
    public static class StaticDb
    {
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
        public static List<User> users = new List<User>
        {
            new User()
            {
                Id= 1,
                FirstName = "Aleksandar",
                LastName ="Audi",
                Address = "Kicevo"
            },
            new User()
            {
                Id= 2,
                FirstName = "Zoki",
                LastName ="Poki",
                Address = "Ohrit"
            },
        };
        public static List<Order> orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                UserID = 1,
                PizzaID = 1,
                Pizza = Pizzas.First(),
                User = users.First(x => x.Id == 3),
                PaymentMetod = PaymentMetod.Card
                
            },new Order()
            {
                Id = 2,
                UserID = 2,
                PizzaID = 2,
                Pizza = Pizzas.First(x=> x.Id ==2),
                User = users.First(x => x.Id == 2),
                PaymentMetod = PaymentMetod.Cash

            }
        };
    }
}
