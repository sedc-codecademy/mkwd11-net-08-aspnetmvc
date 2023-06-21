using DataAccess.Repositories.Interfaces;
using DataAccess.Repositories;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEDC.PizzaApp.Models.Mappers;
namespace Services.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }
        public List<OrderListViewModel> GetAllOrders()
        {
            List<Order> dbOrders = _orderRepository.GetAll();

            return dbOrders.Select(x => x.MapToOrderListViewModel()).ToList();
        }
    }
}
