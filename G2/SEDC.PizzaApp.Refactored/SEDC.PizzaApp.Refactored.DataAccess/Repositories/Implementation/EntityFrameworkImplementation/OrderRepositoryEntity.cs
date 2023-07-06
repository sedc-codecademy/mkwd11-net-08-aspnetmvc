using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Refactored.DataAccess.Data;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Abstraction;
using SEDC.PizzaApp.Refactored.Domain.Models;

namespace SEDC.PizzaApp.Refactored.DataAccess.Repositories.Implementation.EntityFrameworkImplementation
{
    public class OrderRepositoryEntity : IRepository<Order>
    {
        private PizzaAppDbContext _pizzaAppDbContext;

        public OrderRepositoryEntity(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }

        public void DeleteById(int id)
        {
            Order orderDb = _pizzaAppDbContext.Orders.FirstOrDefault(order => order.Id == id);

            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }

            _pizzaAppDbContext.Orders.Remove(orderDb);
            _pizzaAppDbContext.SaveChanges();
        
        }

        public List<Order> GetAll()
        {
            return _pizzaAppDbContext
                .Orders
                .Include(x => x.PizzaOrders)
                .ThenInclude(x => x.Pizza)
                .Include(x => x.User)
                .ToList();
        }

        public Order GetById(int id)
        {
            return _pizzaAppDbContext
                    .Orders
                   .Include(x => x.PizzaOrders)
                   .ThenInclude(x => x.Pizza)
                   .Include(x => x.User)
                   .FirstOrDefault(x => x.Id == id)!;
        }

        public int Insert(Order entity)
        {
            _pizzaAppDbContext.Orders.Add(entity);
            return _pizzaAppDbContext.SaveChanges();
        }

        public void Update(Order entity)
        {
            _pizzaAppDbContext.Orders.Update(entity);
            _pizzaAppDbContext.SaveChanges();
        }
    }
}
