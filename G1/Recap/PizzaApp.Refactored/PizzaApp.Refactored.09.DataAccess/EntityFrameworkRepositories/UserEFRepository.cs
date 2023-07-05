using PizzaApp.Refactored._09.Domain;

namespace PizzaApp.Refactored._09.DataAccess
{
    public class UserEFRepository : IRepository<User>
    {
        private PizzaAppDbContext _pizzaAppDbContext;
        public UserEFRepository(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
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
