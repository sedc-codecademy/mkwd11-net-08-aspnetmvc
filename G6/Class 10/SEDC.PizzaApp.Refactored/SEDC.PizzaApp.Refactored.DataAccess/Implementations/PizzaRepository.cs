using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Orders;
using SEDC.PizzaApp.Refactored.Domain.Pizzas;

namespace SEDC.PizzaApp.Refactored.DataAccess.Implementations
{
    public class PizzaRepository : IRepository<Pizza>
    {
        public void Delete(Pizza entity)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetAll()
        {
            return StaticDb.Pizzas;
        }

        public Pizza GetById(int id)
        {
            return StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Pizza entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Pizza entity)
        {
            throw new NotImplementedException();
        }
    }
}
