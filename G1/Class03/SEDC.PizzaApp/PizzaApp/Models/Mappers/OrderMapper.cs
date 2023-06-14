using PizzaApp.Models.Domain;
using PizzaApp.Models.ViewModels.OrderViewModels;

namespace PizzaApp.Models.Mappers
{
    public static class OrderMapper
    {
        public static OrderDetailsViewModel MapFromOrderToOrderDetailsViewModel(this Order order)
        {
            return new OrderDetailsViewModel()
            {
                PaymentMethod = order.PaymentMethod,
                PizzaName = order.Pizza.Name,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                Price = order.Pizza.Price
            };
        }
    }
}
