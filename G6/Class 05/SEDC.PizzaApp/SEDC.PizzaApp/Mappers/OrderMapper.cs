using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.ViewModels;

namespace SEDC.PizzaApp.Mappers
{
    public static class OrderMapper
    {
        //we map from Order domain model (order from db) to OrderListViewModel
        public static OrderListViewModel OrderToOrderListViewModel(Order orderDb)
        {
            return new OrderListViewModel
            {
                Id = orderDb.Id,
                PizzaName = orderDb.Pizza.Name,
                UserFullName = $"{orderDb.User.FirstName} {orderDb.User.LastName}"
            };
        }

        //we map from Order domain model (order from db) to OrderDetailsViewModel
        public static OrderDetailsViewModel OrderToOrderDetailsViewModel(Order orderDb)
        {
            return new OrderDetailsViewModel
            {
                PizzaName = orderDb.Pizza.Name,
                UserFullName = $"{orderDb.User.FirstName} {orderDb.User.LastName}",
                OrderPrice = orderDb.Pizza.Price + 50,
                PaymentMethod = orderDb.PaymentMethod.ToString(),
                IsDelivered = orderDb.IsDelivered
            };
        }

        public static OrderViewModel OrderToOrderViewModel(Order orderDb)
        {
            return new OrderViewModel
            {
                OrderId = orderDb.Id,
                Delivered = orderDb.IsDelivered,
                PaymentMethod = orderDb.PaymentMethod,
                PizzaName = orderDb.Pizza.Name,
                UserId = orderDb.UserId
            };
        }
    }
}
