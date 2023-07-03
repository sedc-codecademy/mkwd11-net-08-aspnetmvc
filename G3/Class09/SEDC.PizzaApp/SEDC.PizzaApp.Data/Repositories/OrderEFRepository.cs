using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Data.Database;
using SEDC.PizzaApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Data.Repositories
{
    public class OrderEFRepository
        : IRepository<Order>
    {
        private readonly ApplicationDbContext dbContext;

        public OrderEFRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(Order entity)
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return dbContext.Orders.AsNoTracking();
        }

        public Order? GetById(int id)
        {
            return dbContext.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Order entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void Update(Order entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
