using Microsoft.EntityFrameworkCore;
using PizzaApp.Refactored._09.Domain;
using PizzaApp.Refactored._09.Shared;

namespace PizzaApp.Refactored._09.DataAccess
{ 
    public class OrderEFRepository : IRepository<Order>
    {
        private PizzaAppDbContext _pizzaAppDbContext;
        public OrderEFRepository(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }
        public void DeleteById(int id)
        {
            Order orderDb = _pizzaAppDbContext.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                throw new ResourceNotFoundException($"The order with id {id} was not found!");
            }
            _pizzaAppDbContext.Orders.Remove(orderDb);
            _pizzaAppDbContext.SaveChanges(); 
        }

        public List<Order> GetAll()
        {
            // SQL LIKE SYNTAX
            //select* from Orders o
            //inner join PizzaOrder po
            //on o.Id = po.OrderId
            //inner join Pizzas p
            //on po.PizzaId = p.Id
            //inner join Users u
            //on u.Id = o.UserId

            // LINQ SINTAX
            return _pizzaAppDbContext.Orders
                    .Include(x => x.PizzaOrders)
                    .ThenInclude(x => x.Pizza)
                    .Include(x => x.User)
                    .ToList();
        }

        public Order GetById(int id)
        {
            return _pizzaAppDbContext.Orders 
                   .Include(x => x.PizzaOrders)
                   .ThenInclude(x => x.Pizza)
                   .Include(x => x.User)
                   .FirstOrDefault(x => x.Id == id);
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
