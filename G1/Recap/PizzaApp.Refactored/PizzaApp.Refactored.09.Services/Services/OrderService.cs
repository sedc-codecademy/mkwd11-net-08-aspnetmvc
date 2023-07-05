using PizzaApp.Refactored._09.DataAccess;
using PizzaApp.Refactored._09.Domain;
using PizzaApp.Refactored._09.Mappers;
using PizzaApp.Refactored._09.Shared;
using PizzaApp.Refactored._09.ViewModels;

namespace PizzaApp.Refactored._09.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        private IRepository<User> _userRepository;
        private IPizzaRepository _pizzaRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<User> userRepository, IPizzaRepository pizzaRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _pizzaRepository = pizzaRepository;
        }

        public void AddPizzaToOrder(PizzaOrderViewModel pizzaOrderViewModel)
        {
            Pizza pizzaDb = _pizzaRepository.GetById(pizzaOrderViewModel.PizzaId);
            if(pizzaDb == null)
            {
                // We can add loggs here
                throw new Exception($"Pizza with id {pizzaOrderViewModel.PizzaId} was not found");
            }
            Order orderDb = _orderRepository.GetById(pizzaOrderViewModel.OrderId);
            if (orderDb == null)
            {
                // We can add loggs here
                throw new Exception($"Order with id {pizzaOrderViewModel.OrderId} was not found");
            }

            orderDb.PizzaOrders.Add(new PizzaOrder
            {
                Pizza = pizzaDb,
                PizzaId = pizzaDb.Id,
                PizzaSize = pizzaOrderViewModel.PizzaSize
            });
            _orderRepository.Update(orderDb);
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            User userDb = _userRepository.GetById(orderViewModel.UserId);
            if(userDb == null)
            {
                throw new Exception($"User with id {orderViewModel.UserId} was not found!");
            }
            Order order = orderViewModel.MapToOrder();
            order.User = userDb;

            int newOrderId = _orderRepository.Insert(order);
            if(newOrderId <= 0)
            {
                throw new Exception("An error occured while saving to db");
            }
        }

        public void DeleteOrder(int id)
        {
            Order orderDb = _orderRepository.GetById(id);
            if (orderDb == null)
            {
                throw new ResourceNotFoundException($"The order with id {id} was not found!");
            }
            _orderRepository.DeleteById(id);
        }

        public void EditOrder(OrderViewModel orderViewModel)
        {
            Order orderDb = _orderRepository.GetById(orderViewModel.Id);
            if (orderDb == null)
            {
                throw new ResourceNotFoundException($"The order with id {orderViewModel.Id} was not found!");
            }
            User userDb = _userRepository.GetById(orderViewModel.UserId);
            if (userDb == null)
            {
                throw new ResourceNotFoundException($"The user with id {orderViewModel.UserId} was not found!");
            }

            orderDb.User = userDb;

            orderDb.Delivered = orderViewModel.Delivered;
            orderDb.PaymentMethod = orderViewModel.PaymentMethod;
            orderDb.Location = orderViewModel.Location;
            _orderRepository.Update(orderDb);
        }

        public List<OrderListViewModel> GetAllOrders()
        {
            List<Order> dbOrders = _orderRepository.GetAll();

            return dbOrders.Select(x => x.MapToOrderListViewModel()).ToList();
        }

        public OrderDetailsViewModel GetOrderDetails(int id)
        {
            Order orderDb = _orderRepository.GetById(id);
            if(orderDb == null)
            {
                // We can add loggs here
                throw new Exception($"The order with id {id} was not found!");
            }
            return orderDb.MapToOrderDetailsViewModel();
        }

        public OrderViewModel GetOrderForEditing(int id)
        {
            Order orderDb = _orderRepository.GetById(id);
            if(orderDb == null)
            {
                throw new ResourceNotFoundException($"The order with id {id} was not found!");
            }

            return orderDb.MapToOrderViewModel();
        }
    }
}
