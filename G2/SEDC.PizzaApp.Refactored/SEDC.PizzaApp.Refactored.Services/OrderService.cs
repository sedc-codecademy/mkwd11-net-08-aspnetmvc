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
        private IRepository<User> _userRepository;

        public OrderService(IRepository<Order> orderRepository,
                            IRepository<User> userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;   

        }

        public List<OrderListViewModel> GetAllOrders() 
        {
            List<Order> dbOrders = _orderRepository.GetAll();
            return dbOrders.Select(order => order.MapToOrderListViewModel()).ToList();
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            User userDb = _userRepository.GetById(orderViewModel.UserId);

            if (userDb == null)
            {
                throw new Exception($"User with id {orderViewModel.UserId} was not found!");
            }

            Order order = orderViewModel.MapToOrder();
            order.User = userDb;

            int newOrderId = _orderRepository.Insert(order);
            if (newOrderId <= 0)
            {
                throw new Exception("An error occured while saving to db");
            }
        }
    }
}
