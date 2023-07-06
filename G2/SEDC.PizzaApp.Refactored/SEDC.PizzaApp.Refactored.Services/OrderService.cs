using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Abstraction;
using SEDC.PizzaApp.Refactored.Domain.Models;
using SEDC.PizzaApp.Refactored.Mappers.Extensions;
using SEDC.PizzaApp.Refactored.Services.Abstraction;
using SEDC.PizzaApp.Refactored.ViewModels.OrderViewModels;

namespace SEDC.PizzaApp.Refactored.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        private IRepository<User> _userRepository;
        private IPizzaRepository _pizzaRepository;

        public OrderService(IRepository<Order> orderRepository,
                            IRepository<User> userRepository,
                            IPizzaRepository pizzaRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _pizzaRepository = pizzaRepository;
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

        public void DeleteOrder(int id)
        {
            Order orderDb = _orderRepository.GetById(id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }
            _orderRepository.DeleteById(id);
        }

        public void EditOrder(OrderViewModel orderViewModel)
        {
            Order orderDb = _orderRepository.GetById(orderViewModel.Id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {orderViewModel.Id} was not found!");
            }

            User userDb = _userRepository.GetById(orderViewModel.UserId);
            if (userDb == null)
            {
                throw new Exception($"The user with id {orderViewModel.UserId} was not found!");
            }

            Order editedOrder = orderViewModel.MapToOrder();
            editedOrder.User = userDb;
            editedOrder.Id = orderViewModel.Id;
            editedOrder.PizzaOrders = orderDb.PizzaOrders;
            _orderRepository.Update(editedOrder);
        }

        public OrderViewModel GetOrderForEditing(int id)
        {
            Order orderDb = _orderRepository.GetById(id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }

            return orderDb.MapToOrderViewModel();
        }

        public OrderDetailsViewModel GetOrderDetails(int id)
        {
            Order orderDb = _orderRepository.GetById(id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }
            return orderDb.MapToOrderDetailsViewModel();
        }

        public void AddPizzaToOrder(PizzaOrderViewModel pizzaOrderViewModel) 
        {
            var pizzaDb = _pizzaRepository.GetById(pizzaOrderViewModel.PizzaId);
            if (pizzaDb == null) 
            {
                throw new Exception($"Pizza with id {pizzaOrderViewModel.PizzaId} was not found");
            }

            var orderDb = _orderRepository.GetById(pizzaOrderViewModel.OrderId);
            if (orderDb == null)
            {
                throw new Exception($"Order with id {pizzaOrderViewModel.OrderId} was not found");
            }

            var pizzaOrder = new PizzaOrder
            {
                Pizza = pizzaDb,
                PizzaId = pizzaDb.Id,
                Order = orderDb,
                OrderId = orderDb.Id,
                PizzaSize = pizzaOrderViewModel.PizzaSize
            };

            orderDb.PizzaOrders.Add(pizzaOrder);

            _orderRepository.Update(orderDb);
        }
    }
}
