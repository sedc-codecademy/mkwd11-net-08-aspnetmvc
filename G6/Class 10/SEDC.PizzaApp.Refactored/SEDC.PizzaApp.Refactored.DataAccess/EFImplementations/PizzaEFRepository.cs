using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Orders;
using SEDC.PizzaApp.Refactored.Domain.Pizzas;

namespace SEDC.PizzaApp.Refactored.DataAccess.EFImplementations
{
    public class PizzaEFRepository : IPizzaRepository
    {
        private PizzaAppDbContext _dbContext;

        public PizzaEFRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //CRUD
        public void Delete(Pizza entity)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetAll()
        {
            //here we don't joins with other tables, since we need only Id and Name (from Pizzas table)

            return _dbContext.Pizzas.ToList();
        }

        public Pizza GetById(int id)
        {
            return _dbContext.Pizzas.FirstOrDefault(p => p.Id == id);
        }
        public void Insert(Pizza entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Pizza entity)
        {
            throw new NotImplementedException();
        }

        //specific method only for Pizzas
        public List<Pizza> GetPizzasOnPromotion()
        {
           return _dbContext.Pizzas.Where(x => x.IsOnPromotion).ToList();
        }
    }
}
