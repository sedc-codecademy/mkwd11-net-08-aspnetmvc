using PizzaApp.Refactored._09.Domain;
using PizzaApp.Refactored._09.ViewModels;

namespace PizzaApp.Refactored._09.Mappers
{
    public static class OrderMapper
    {
        public static OrderListViewModel MapToOrderListViewModel(this Order order)
        {
            return new OrderListViewModel
            {
                Id = order.Id,
                Delivered = order.Delivered,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                PizzaNames = order.PizzaOrders.Select(x => x.Pizza.Name).ToList()
            };
        }

        public static OrderDetailsViewModel MapToOrderDetailsViewModel(this Order order)
        {
            return new OrderDetailsViewModel
            {
                Delivered = order.Delivered,
                PaymentMethod = order.PaymentMethod,
                Location = order.Location,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                PizzaNames = order.PizzaOrders.Select(x => x.Pizza.Name).ToList(),
                Id = order.Id
            };
        }

        public static Order MapToOrder(this OrderViewModel orderViewModel)
        {
            return new Order
            {
                Delivered = orderViewModel.Delivered,
                Location = orderViewModel.Location,
                PaymentMethod = orderViewModel.PaymentMethod,
                PizzaOrders = new List<PizzaOrder>(),
                UserId = orderViewModel.UserId
            };
        }

        public static OrderViewModel MapToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Delivered = order.Delivered,
                Location = order.Location,
                PaymentMethod = order.PaymentMethod,
                UserId = order.UserId
            };
        }
    }
}
