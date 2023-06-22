using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Mappers
{
    public static class OrderMapper
    {
        //public static OrderViewModel ToOrderViewModel(Order order) 
        //{
        //    return new OrderViewModel()
        //    {
        //        PizzaName = order.Pizza.Name,
        //        UserFullName = $"{order.User.FirstName} {order.User.LastName}",
        //        PaymentMethod = order.PaymentMethod,
        //        Price = order.Pizza.Price + 50,
        //        Id = order.Id
        //    };
        //}

        //public static OrderViewModel ToOrderViewModelExtension(this Order order)
        //{
        //    return new OrderViewModel()
        //    {
        //        PizzaName = order.Pizza.Name,
        //        UserFullName = $"{order.User.FirstName} {order.User.LastName}",
        //        PaymentMethod = order.PaymentMethod,
        //        Price = order.Pizza.Price + 50,
        //        Id = order.Id
        //    };
        //}

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
    }
}
