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
    }
}
