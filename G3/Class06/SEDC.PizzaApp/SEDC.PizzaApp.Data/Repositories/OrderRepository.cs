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
        public void Create(Order entity)
        {
            entity.Id = PizzaAppDb.Orders.Max(x => x.Id) + 1;
            PizzaAppDb.Orders.Add(entity);
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }



        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
