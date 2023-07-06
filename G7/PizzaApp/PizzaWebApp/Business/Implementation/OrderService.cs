using Business.Abstraction;
using DataAccess.Abstraction;
using DomainModels;
using Mappers;
using ViewModels;

namespace Business.Implementation
{
    public class OrderService : IOrderService
    {
        public IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<OrderViewModel> GetAll()
        {
            return _orderRepository.GetAll().Select(x => x.ToViewModel()).ToList();
        }

        public OrderViewModel Details(int id)
        {
            var order = _orderRepository.GetById(id);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            return order.ToViewModel();
        }

        public int Save(OrderViewModel model)
        {
            var order = new Order(model.Name, model.Address, model.PhoneNumber, model.Note, new List<OrderItem>());

            _orderRepository.Insert(order);

            return order.Id;
        }
        public void Delete(int id)
        {
            var existingOrder = _orderRepository.GetById(id);

            if (existingOrder == null)
            {
                throw new Exception($"Order with id {id} does not exist");
            }

            _orderRepository.DeleteById(existingOrder.Id);
        }
    }
}
