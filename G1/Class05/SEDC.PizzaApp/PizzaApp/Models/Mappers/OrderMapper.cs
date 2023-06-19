using PizzaApp.Models.Domain;
using PizzaApp.Models.ViewModels.OrderViewModels;

namespace PizzaApp.Models.Mappers
{
    public static class OrderMapper
    {
        public static OrderListViewModel MapFromOrderToOrderListViewModel(this Order order)
        {
            return new OrderListViewModel()
            {
                Id = order.Id,
                PaymentMethod = order.PaymentMethod,
                PizzaName = order.Pizza.Name,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                Price = order.Pizza.Price
            };
        }

        public static Order MapToOrder(this OrderViewModel orderViewModel)
        {
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderViewModel.UserId);
            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderViewModel.PizzaName);

            return new Order()
            {
                Id = orderViewModel.Id,
                PaymentMethod = orderViewModel.PaymentMethod,
                Pizza = pizzaDb,
                User = userDb,
                IsDelivered = orderViewModel.IsDelivered
            };
        }
    }
}
