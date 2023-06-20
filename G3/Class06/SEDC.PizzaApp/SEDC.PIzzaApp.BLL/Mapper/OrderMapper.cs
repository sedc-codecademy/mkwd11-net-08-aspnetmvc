
using SEDC.PizzaApp.Data.Models;
using SEDC.PizzaApp.Web.Mapper;
using SEDC.PIzzaApp.BLL.DTOs.Orders;

namespace SEDC.PizzaApp.BLL.Mapper
{
    public static class OrderMapper
    {
        public static OrderDTO ToDTO(this Order order)
        {
            return new OrderDTO
            {
                Id = order.Id,
                FullName = order.User.FullName,
                UserId = order.User.Id,
                PaymentMethod = order.PaymentMethod,
                PizzaCount = order.Pizzas.Count
            };
        }

        public static OrderDetailsDTO ToDetailsDTO(this Order order)
        {
            return new OrderDetailsDTO
            {
                OrderId = order.Id,
                By = order.User.FullName,
                PaymentMethod = order.PaymentMethod,
                Pizzas = order.Pizzas.Select(x => x.ToDTO())
            };
        }
    }
}
