using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Implementation.StaticDbImplementation;
using SEDC.PizzaApp.Refactored.Domain.Models;
using SEDC.PizzaApp.Refactored.ViewModels.OrderViewModels;
using SEDC.PizzaApp.Refactored.Mappers.Extensions;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Implementation.EntityFrameworkImplementation;
using SEDC.PizzaApp.Refactored.Services.Abstraction;

namespace SEDC.PizzaApp.Refactored.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<OrderListViewModel> GetAllOrders() 
        {
            List<Order> dbOrders = _orderRepository.GetAll();
            return dbOrders.Select(order => order.MapToOrderListViewModel()).ToList();
        }
    }
}
