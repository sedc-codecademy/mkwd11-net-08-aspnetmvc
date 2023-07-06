using Business.Abstraction;
using DataAccess.Abstraction;
using DomainModels;
using ViewModels;

namespace Business.Implementation
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<MenuItem> _menuItemRepository;

        public OrderItemService(IRepository<Order> orderRepository, IRepository<MenuItem> menuItemRepository)
        {
            _orderRepository = orderRepository;
            _menuItemRepository = menuItemRepository;
        }

        public void Save(OrderItemViewModel model)
        {
            var order = _orderRepository.GetById(model.OrderId);

            if (order == null)
            {
                throw new Exception($"Order does not exist");
            }

            var menuItem = _menuItemRepository.GetById(model.MenuItem.Id);

            if (menuItem == null)
            {
                throw new Exception($"Menu item does not exist");
            }

            if (model.Quantity <= 0)
            {
                throw new Exception($"Quantity must be grater than 0");
            }

            var orderItem = new OrderItem(menuItem, model.Quantity);

            order.OrderItems.Add(orderItem);

            _orderRepository.Update(order);
        }
        public int Delete(int id)
        {
            var existingOrder = _orderRepository.GetAll().FirstOrDefault(x => x.OrderItems.Any(y => y.Id == id));

            if (existingOrder == null)
            {
                throw new Exception($"Order that contains order item with {id} does not exist");
            }

            var existingOrderItem = existingOrder.OrderItems.First(x => x.Id == id);

            existingOrder.OrderItems.Remove(existingOrderItem);

            _orderRepository.Update(existingOrder);

            return existingOrder.Id;
        }
    }
}
