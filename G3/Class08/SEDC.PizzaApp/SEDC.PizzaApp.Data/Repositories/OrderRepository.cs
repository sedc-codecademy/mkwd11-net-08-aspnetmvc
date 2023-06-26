using SEDC.PizzaApp.Data.Database;
using SEDC.PizzaApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Data.Repositories
{
    public class OrderRepository
        : IRepository<Order>
    {
        public IEnumerable<Order> GetAll()
        {
            return PizzaAppDb.Orders;
        }
        public void Save(Order entity)
        {
            entity.Id = PizzaAppDb.Orders.Max(x => x.Id) + 1;
            PizzaAppDb.Orders.Add(entity);
        }

        public void Delete(Order entity)
        {
            PizzaAppDb.Orders.Remove(entity);
        }


        public Order? GetById(int id)
        {
            return PizzaAppDb.Orders.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Order entity)
        {
            
        }
    }
}
