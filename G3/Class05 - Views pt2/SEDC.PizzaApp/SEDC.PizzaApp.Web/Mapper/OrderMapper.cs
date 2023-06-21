using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Mapper
{
    public static class OrderMapper
    {
        public static OrderViewModel ToViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                FullName = order.User.FullName,
                UserId = order.User.Id,
                PaymentMethod = order.PaymentMethod,
                PizzaCount = order.Pizzas.Count
            };
        }

        public static OrderDetailsViewModel ToDetailsViewModel(this Order order)
        {
            return new OrderDetailsViewModel
            {
                OrderId = order.Id,
                By = order.User.FullName,
                PaymentMethod = order.PaymentMethod,
                Pizzas = order.Pizzas.Select(x => x.ToViewModel())
            };
        }
    }
}
