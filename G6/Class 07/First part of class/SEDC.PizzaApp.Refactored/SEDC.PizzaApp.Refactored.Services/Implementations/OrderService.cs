using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Orders;
using SEDC.PizzaApp.Refactored.Services.Interfaces;
using SEDC.PizzaApp.Refactored.ViewModels.Orders;
using SEDC.PizzaApp.Refactored.Mappers.Orders;

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
            //from db we get list of  domain models
            List<Order> ordersDb = _orderRepository.GetAll();

            //map to viewmodels
            List<OrderListViewModel> orderListViewModels =
                ordersDb.Select(x => x.ToOrderListViewModel()).ToList();

            //List<OrderListViewModel> viewModels = new List<OrderListViewModel>();
            //foreach(Order order in ordersDb)
            //{
            //    viewModels.Add(order.ToOrderListViewModel());
            //}
            //return viewModels;

            return orderListViewModels;
        }
    }
}
