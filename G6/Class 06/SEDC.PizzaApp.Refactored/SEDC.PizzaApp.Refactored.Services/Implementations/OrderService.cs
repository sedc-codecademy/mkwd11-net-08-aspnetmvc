using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Orders;
using SEDC.PizzaApp.Refactored.Services.Interfaces;

namespace SEDC.PizzaApp.Refactored.Services.Implementations
{
    public class OrderService : IOrderService
    {
        
        //service (business layer) needs data layer
        private IRepository<Order> _orderRepository;

        //we need a method that:
        //reads from db -> we need a class that directly communicates with db (Repository)
        //map to viewmodels
        public List<OrderListViewModel> GetAllOrders()
        {
            List<Order> ordersDb = _orderRepository.GetAll();
            //TODO map to viewmodels
        }
    }
}
