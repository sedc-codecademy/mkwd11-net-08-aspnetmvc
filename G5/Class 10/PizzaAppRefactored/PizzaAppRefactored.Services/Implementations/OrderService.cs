using PizzaAppRefactored.DataAccess;
using PizzaAppRefactored.Domain.Models;
using PizzaAppRefactored.Mappers;
using PizzaAppRefactored.Services.Interfaces;
using PizzaAppRefactored.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;
        private IRepository<User> _userRepository;
        private IRepository<Pizza> _pizzaRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<User> userRepository, IRepository<Pizza> pizzaRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _pizzaRepository = pizzaRepository;
        }

        public List<OrderDetailsViewModel> GetAllOrders()
        {
            List<Order> orders = _orderRepository.GetAll();

            List<OrderDetailsViewModel> orderDetailsViewModels = new List<OrderDetailsViewModel>();  

            foreach(var order in orders)
            {
                OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(order);
                orderDetailsViewModels.Add(orderDetailsViewModel);
            }

            return orderDetailsViewModels;
        }

        public OrderDetailsViewModel GetOrderById(int id)
        {
            //get the order from repository who will get it from database
            Order orderDb = _orderRepository.GetById(id);
            
            //validation
            if(orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }

            //Mapping the domain to view model
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(orderDb);
            return orderDetailsViewModel;

        }

        public void CreateOrder(OrderDialogViewModel orderDialogViewModel)
        {
            //validation
            if(orderDialogViewModel == null)
            {
                throw new Exception("Model cannot be null");
            }

            User user = _userRepository.GetById(orderDialogViewModel.UserId);
            if(user == null)
            {
                throw new Exception($"User with id {orderDialogViewModel.UserId} was not found");
            }

            //mapping
            Order newOrder = OrderMapper.ToOrder(orderDialogViewModel);
            newOrder.User = user;

            //send it to the database
            int newOrderId = _orderRepository.Insert(newOrder);  
            if(newOrderId <= 0)
            {
                throw new Exception("An error occured while adding the new order");
            }
        }

        public void AddPizzaToOrder(AddPizzaToOrderViewModel addPizzaToOrderViewModel)
        {
            //validation
            Order orderDb = _orderRepository.GetById(addPizzaToOrderViewModel.OrderId);
            if (orderDb == null)
            {
                throw new Exception($"Order with id {addPizzaToOrderViewModel.OrderId} was not found");
            }

            Pizza pizzaDb = _pizzaRepository.GetById(addPizzaToOrderViewModel.PizzaId);
            if (pizzaDb == null)
            {
                throw new Exception($"Pizza with id {addPizzaToOrderViewModel.PizzaId} was not found");
            }

            if(addPizzaToOrderViewModel.Quantity <=0 || addPizzaToOrderViewModel.Price <= 0)
            {
                throw new Exception("The price and the quantity must be greater than zero!");
            }

            orderDb.PizzaOrders.Add(new PizzaOrder
            {
              //  Id = orderDb.PizzaOrders.Count() + 1,
                OrderId = orderDb.Id,
                Order = orderDb,
                Pizza = pizzaDb,
                PizzaId = pizzaDb.Id,
                Quantity = addPizzaToOrderViewModel.Quantity,
                PizzaSize = addPizzaToOrderViewModel.PizzaSize,
                Price = addPizzaToOrderViewModel.Price
            });

            _orderRepository.Update(orderDb);

        }

        public void DeleteOrder(int orderId)
        {
            Order orderDb = _orderRepository.GetById(orderId);
            if (orderDb == null)
            {
                throw new Exception($"Order with id {orderId} was not found");
            }

            _orderRepository.DeleteById(orderId);
        }

    }
}
