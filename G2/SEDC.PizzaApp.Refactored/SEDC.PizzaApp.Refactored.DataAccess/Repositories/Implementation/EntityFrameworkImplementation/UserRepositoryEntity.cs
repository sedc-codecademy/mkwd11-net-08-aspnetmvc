using SEDC.PizzaApp.Refactored.DataAccess.Data;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Abstraction;
using SEDC.PizzaApp.Refactored.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.DataAccess.Repositories.Implementation.EntityFrameworkImplementation
{
    public class UserRepositoryEntity : IRepository<User>
    {
        private PizzaAppDbContext _pizzaAppDbContext;
        public UserRepositoryEntity(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }

        public void DeleteById(int id)
        {
            User userDb = _pizzaAppDbContext.Users.FirstOrDefault(user => user.Id == id);

            if (userDb == null)
            {
                throw new Exception($"The users with id {id} was not found!");
            }

            _pizzaAppDbContext.Users.Remove(userDb);
            _pizzaAppDbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _pizzaAppDbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _pizzaAppDbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(User entity)
        {
            _pizzaAppDbContext.Users.Add(entity);
            return _pizzaAppDbContext.SaveChanges();
        }

        public void Update(User entity)
        {
            _pizzaAppDbContext.Users.Update(entity);
            _pizzaAppDbContext.SaveChanges();
        }
    }
}
