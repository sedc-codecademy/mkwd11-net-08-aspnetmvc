using SEDC.PizzaApp.BLL.Mapper;
using SEDC.PizzaApp.Data.Models;
using SEDC.PizzaApp.Data.Repositories;
using SEDC.PizzaApp.BLL.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.BLL.Services.Implementation
{
    public class OrderService
        : IOrderService
    {
        private readonly IRepository<Order> repository;
        private readonly IRepository<User> userRepository;

        public OrderService(IRepository<Order> repository, IRepository<User> userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            IEnumerable<Order> orders = repository.GetAll();
            return orders.Select(x => x.ToDTO());

        }

        public OrderDTO Create(CreateOrderDTO create)
        {
            var user = userRepository.GetById(create.UserId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var order = new Order(user, create.PaymentMethod);
            repository.Save(order);

            var orderDTO = order.ToDTO();
            return orderDTO;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }



        public OrderDetailsDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDTO Update(OrderDTO orderDTO)
        {
            throw new NotImplementedException();
        }
    }
}
