using SEDC.PizzaApp.Data.Database;
using SEDC.PizzaApp.Data.Models;

namespace SEDC.PizzaApp.Data.Repositories
{
    public class UserRepository
        : IRepository<User>
    {
        public void Save(User entity)
        {
            PizzaAppDb.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            PizzaAppDb.Users.Remove(entity);
            //var sql = "DELETE FROM [Users] where id = " + entity.Id;
        }

        public IEnumerable<User> GetAll()
        {
            return PizzaAppDb.Users;
        }

        public User? GetById(int id)
        {
            return PizzaAppDb.Users.SingleOrDefault(x => x.Id == id);
        }

        public void Update(User entity)
        {
        }
    }
}
