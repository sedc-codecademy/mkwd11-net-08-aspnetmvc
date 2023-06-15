using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class OrderMapper
    {
        //This method will be called in all places where we need to map from Order to OrderDetailsViewModel
        public static OrderDetailsViewModel MapToOrderDetailsViewModel(this Order orderDb)
        {
            return new OrderDetailsViewModel
            {
                PaymentMethod = orderDb.PaymentMethod,
                PizzaName = orderDb.Pizza.Name,
                Price = orderDb.Pizza.Price + 100,
                UserFullname = $"{orderDb.User.FirstName} {orderDb.User.LastName}",
                Delivered = orderDb.Delivered
            };
        }

        public static OrderListViewModel MapToOrderListViewModel(this Order order)
        {
            return new OrderListViewModel
            {
                Id = order.Id,
                PizzaName = order.Pizza.Name,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}"
            };
        }
    }
}
