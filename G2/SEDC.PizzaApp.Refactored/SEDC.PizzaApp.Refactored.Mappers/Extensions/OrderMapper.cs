using SEDC.PizzaApp.Refactored.Domain.Models;
using SEDC.PizzaApp.Refactored.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Mappers.Extensions
{
    public static class OrderMapper
    {
        public static OrderListViewModel MapToOrderListViewModel(this Order order) 
        {
            return new OrderListViewModel
            {
                Id = order.Id,
                Delieverd = order.Delivered,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                PizzaNames = order.PizzaOrders.Select(po => po.Pizza.Name).ToList()
            };
        }
    }
}
