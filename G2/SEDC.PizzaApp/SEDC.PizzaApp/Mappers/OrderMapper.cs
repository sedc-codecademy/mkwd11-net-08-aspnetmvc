using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                Delieverd = order.Delivered,
                PaymentMethod = order.PaymentMethod,
                PizzaName = order.Pizza.Name,
                UserId = order.User.Id
            };
        }
        public static OrderDetailsViewModel ToOrderDetailsViewModel(this Order order) 
        {
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                IsDelivered = order.Delivered,
                PizzaName = order.Pizza.Name,
                Price = order.Pizza.Price + 100,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                PaymentMethod = order.PaymentMethod
            };
        }
        public static OrderListViewModel ToOrderListViewModel(this Order order) 
        {
            return new OrderListViewModel
            {
                Id = order.Id,
                PizzaName = order.Pizza.Name,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}"
            };
        }

        public static Order ToOrderDomainModel(this OrderViewModel orderViewModel, 
                                               User user, 
                                               Pizza pizza) 
        {
            return new Order
            {
                Id = orderViewModel.Id,
                Delivered = orderViewModel.Delieverd,
                PaymentMethod = orderViewModel.PaymentMethod,
                User = user,
                UserId = user.Id,
                Pizza = pizza,
                PizzaId = pizza.Id
            };
        }
    }
}
