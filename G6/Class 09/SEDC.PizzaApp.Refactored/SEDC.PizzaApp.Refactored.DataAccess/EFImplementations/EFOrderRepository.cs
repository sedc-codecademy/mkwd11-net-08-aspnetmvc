using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.DataAccess.EFImplementations
{
    public class EFOrderRepository : IRepository<Order>
    {
        private PizzaAppDbContext _dbContext;

        public EFOrderRepository(PizzaAppDbContext dbContext) //Dependency injection
        {
            _dbContext = dbContext;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            /*
             select *
            from Orders as o
            inner join
            Users as u
            on o.UserId = u.Id
            inner join PizzaOrder as po
            on po.OrderId = o.Id
            inner join Pizzas as p
            on p.Id = po.PizzaId
             */

            //this only returns what's in Orders table (without joins)
            //return _dbContext.Orders.ToList();

            return _dbContext.Orders
                .Include(x => x.User) //join with table Users
                .Include(x => x.PizzaOrders) //join with table PizzaOrder
                .ThenInclude(x => x.Pizza) //now join PizzaOrder with Pizzas
                .ToList();

        }

        public Order GetById(int id)
        {
            return _dbContext.Orders
                .Include(x => x.PizzaOrders) //join PizzaOrder
                .ThenInclude(x => x.Pizza) // make join between PizzaOrder and Pizzas
                .Include(x => x.User) // join Orders with Users
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
