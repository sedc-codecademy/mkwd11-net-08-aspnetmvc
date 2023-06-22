using PizzaApp.Refactored._06.DataAccess;
using PizzaApp.Refactored._06.Domain;
using PizzaApp.Refactored._06.Mappers;
using PizzaApp.Refactored._06.ViewModels;

namespace PizzaApp.Refactored._06.Services.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            //_orderRepository = new OrderRepository();
        }
        public List<OrderListViewModel> GetAllOrders()
        {
            List<Order> dbOrders = _orderRepository.GetAll();

            return dbOrders.Select(x => x.MapToOrderListViewModel()).ToList();
        }
    }
}
