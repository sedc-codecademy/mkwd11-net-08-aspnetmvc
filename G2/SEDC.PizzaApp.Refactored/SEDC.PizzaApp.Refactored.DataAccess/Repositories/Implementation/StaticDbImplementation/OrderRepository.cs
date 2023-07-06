using SEDC.PizzaApp.Refactored.DataAccess.Data;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Abstraction;
using SEDC.PizzaApp.Refactored.Domain.Models;

namespace SEDC.PizzaApp.Refactored.DataAccess.Repositories.Implementation.StaticDbImplementation
{
    public class OrderRepository : IRepository<Order>
    {
        public void DeleteById(int id)
        {
            Order order = StaticDb.Orders.FirstOrDefault(order => order.Id == id);
            StaticDb.Orders.Remove(order);
        }

        public List<Order> GetAll()
        {
            return StaticDb.Orders;
        }

        public Order GetById(int id)
        {
            return StaticDb.Orders.FirstOrDefault(order => order.Id == id);
        }

        public int Insert(Order entity)
        {
            entity.Id = ++StaticDb.OrderId;
            StaticDb.Orders.Add(entity);
            return entity.Id;
        }

        public void Update(Order entity)
        {
            Order order = StaticDb.Orders.FirstOrDefault(order => order.Id == entity.Id);
            int index = StaticDb.Orders.IndexOf(order);
            StaticDb.Orders[index] = entity;
        }
    }
}
