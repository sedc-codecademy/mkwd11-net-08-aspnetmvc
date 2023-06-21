using PizzaApp.Refactored._06.Domain;
using PizzaApp.Refactored._06.ViewModels;

namespace PizzaApp.Refactored._06.Mappers
{
    public static class OrderMapper
    {
        public static OrderListViewModel MapToOrderListViewModel(this Order order)
        {
            return new OrderListViewModel
            {
                Delivered = order.Delivered,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                PizzaNames = order.PizzaOrders.Select(x => x.Pizza.Name).ToList()
            };
        }
    }
}
