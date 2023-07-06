using DataAccess.Abstraction;
using DomainModels;

namespace DataAccess.Repositories
{
    public class PizzaRepository : IRepository<Pizza>
    {
        private readonly PizzaAppDbContext _dbContext;

        public PizzaRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Pizza> GetAll()
        {
            return _dbContext.Pizzas.ToList();
        }

        public Pizza GetById(int id)
        {
            return _dbContext.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Pizza entity)
        {
            _dbContext.Pizzas.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Pizza entity)
        {
            var item = GetById(entity.Id);
            if(item != null)
            {
                _dbContext.Pizzas.Update(entity);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            if(item != null)
            {
                _dbContext.Pizzas.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
