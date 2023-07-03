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
    public class UserEFRepository
        : IRepository<User>
    {
        private readonly ApplicationDbContext dbContext;

        public UserEFRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(User entity)
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return dbContext.Set<User>().AsNoTracking();
        }

        public User? GetById(int id)
        {
            return dbContext.Users.SingleOrDefault(x => x.Id == id);
        }

        public void Save(User entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
        }

        public void Update(User entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }
    }
}
