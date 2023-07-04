using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Implementation.StaticDbImplementation;
using SEDC.PizzaApp.Refactored.Domain.Models;
using SEDC.PizzaApp.Refactored.ViewModels.OrderViewModels;
using SEDC.PizzaApp.Refactored.Mappers.Extensions;

namespace SEDC.PizzaApp.Refactored.Services
{
    public class OrderService
    {
        private OrderRepository _orderRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }

        public List<OrderListViewModel> GetAllOrders() 
        {
            List<Order> dbOrders = _orderRepository.GetAll();
            return dbOrders.Select(order => order.MapToOrderListViewModel()).ToList();
        }
    }
}
