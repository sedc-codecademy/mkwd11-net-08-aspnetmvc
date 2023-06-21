using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class OrderMapper
    {
        //This method will be called in all places where we need to map from Order to OrderDetailsViewModel
        public static OrderDetailsViewModel ToOrderDetailsViewModel(Order orderDb)
        {
            return new OrderDetailsViewModel
            {
                Id = orderDb.Id,
                PaymentMethod = orderDb.PaymentMethod,
                PizzaName = orderDb.Pizza.Name,
                Price = orderDb.Pizza.Price + 100,
                UserFullname = $"{orderDb.User.FirstName} {orderDb.User.LastName}",
                Delivered = orderDb.Delivered
            };
        }

        //Extension methods
        public static OrderListViewModel MapToOrderListViewModel(this Order order)
        {
            return new OrderListViewModel
            {
                Id = order.Id,
                PizzaName = order.Pizza.Name,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}"
            };
        }

        //public static Order MapToOrder(this OrderViewModel orderViewModel)
        //{
        //    User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderViewModel.UserId);
        //    Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderViewModel.PizzaName);
        //    return new Order
        //    {
        //        Delivered = orderViewModel.Delivered,
        //        PaymentMethod = orderViewModel.PaymentMethod,
        //        Id = orderViewModel.Id,
        //        User = userDb,
        //        Pizza = pizzaDb
        //    };
        //}

        public static OrderViewModel MapToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Delivered = order.Delivered,
                PaymentMethod = order.PaymentMethod,
                PizzaName = order.Pizza.Name,
                UserId = order.User.Id
            };
        }
    }
}
