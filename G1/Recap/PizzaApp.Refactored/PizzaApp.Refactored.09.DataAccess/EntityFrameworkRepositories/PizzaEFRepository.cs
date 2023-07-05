using PizzaApp.Refactored._09.Domain;

namespace PizzaApp.Refactored._09.DataAccess
{
    public class PizzaEFRepository : IPizzaRepository
    {
        private PizzaAppDbContext _pizzaAppDbContext;
        public PizzaEFRepository(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetAll()
        {
            return _pizzaAppDbContext.Pizzas.ToList();
        }

        public Pizza GetById(int id)
        {
            return _pizzaAppDbContext.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public Pizza GetPizzaOnPromotion()
        {
            return _pizzaAppDbContext.Pizzas.FirstOrDefault(x => x.IsOnPromotion == true);
        }

        public int Insert(Pizza entity)
        {
            _pizzaAppDbContext.Pizzas.Add(entity);
            return _pizzaAppDbContext.SaveChanges();
        }

        public void Update(Pizza entity)
        {
            _pizzaAppDbContext.Pizzas.Update(entity);
            _pizzaAppDbContext.SaveChanges();
        }
    }
}
