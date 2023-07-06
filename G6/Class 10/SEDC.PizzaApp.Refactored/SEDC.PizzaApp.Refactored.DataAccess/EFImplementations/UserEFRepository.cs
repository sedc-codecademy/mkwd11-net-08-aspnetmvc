using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Orders;
using SEDC.PizzaApp.Refactored.Domain.Users;

namespace SEDC.PizzaApp.Refactored.DataAccess.EFImplementations
{
    public class UserEFRepository : IRepository<User>
    {
        private PizzaAppDbContext _dbContext;

        public UserEFRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
           return _dbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            //we only need to check if the user exists, so it is enough only to read from Users table
           return _dbContext.Users.First(x => x.Id == id);
        }

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
