using Microsoft.EntityFrameworkCore;
using PizzaAppRefactored.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.DataAccess.EFImplementations
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
            //select * from Order where Id == id
            Order orderDb = _pizzaAppDbContext.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                throw new Exception($"Order with id {id} was not found!");
            }
            _pizzaAppDbContext.Orders.Remove(orderDb);
            _pizzaAppDbContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            //select * from Orders o
            //inner join User u
            //on o.UserId = u.Id
            //inner join PizzaOrders po
            //on o.Id = po.OrderId
            //inner join Pizzas p
            //on p.Id = po.PizzaId
            var ordersDb = _pizzaAppDbContext.Orders
                 .Include(x => x.User) //inner join with Users
                 .Include(x => x.PizzaOrders) //inner join Orders with PizzaOrders
                 .ThenInclude(x => x.Pizza)  //inner join PizzaOrder with Pizza
                 .ToList();

            return ordersDb;
}
        public Order GetById(int id)
        {

            var orderDb = _pizzaAppDbContext.Orders
                 .Include(x => x.PizzaOrders)
                 .ThenInclude(x => x.Pizza)
                 .Include(x => x.User)
                 //.Where(x => x.Id == id)
                 .FirstOrDefault(x => x.Id ==id);

            if (orderDb == null)
            {
                throw new Exception($"Order with id {id} was not found!");
            }
            return orderDb;
        }

        public int Insert(Order entity)
        {
            _pizzaAppDbContext.Orders.Add(entity); //still no db call
            _pizzaAppDbContext.SaveChanges(); //call to db

            return entity.Id;
        }

        public void Update(Order entity)
        {
            _pizzaAppDbContext.Orders.Update(entity);
            _pizzaAppDbContext.SaveChanges();
        }
    }
}
