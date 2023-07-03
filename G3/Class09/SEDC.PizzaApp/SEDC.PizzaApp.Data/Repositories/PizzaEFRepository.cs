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
    public class PizzaEFRepository
        : IRepository<Pizza>
    {
        private readonly ApplicationDbContext dbContext;

        public PizzaEFRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Delete(Pizza entity)
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public IEnumerable<Pizza> GetAll()
        {
            return dbContext.Pizzas.AsNoTracking();
        }

        public Pizza? GetById(int id)
        {
            return dbContext.Pizzas.SingleOrDefault(p => p.Id == id);
        }

        public void Save(Pizza entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void Update(Pizza entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
