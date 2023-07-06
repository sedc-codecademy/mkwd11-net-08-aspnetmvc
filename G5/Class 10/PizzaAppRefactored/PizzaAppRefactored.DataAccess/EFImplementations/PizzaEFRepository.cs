using PizzaAppRefactored.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.DataAccess.EFImplementations
{
    public class PizzaEFRepository : IRepository<Pizza>

    {
       private PizzaAppDbContext _pizzaAppDbContext;

        public PizzaEFRepository(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }
        public void DeleteById(int id)
        {
            Pizza pizzasDb = _pizzaAppDbContext.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizzasDb == null)
            {
                throw new Exception($"Pizza with id {id} was not found!");
            }
            _pizzaAppDbContext.Pizzas.Remove(pizzasDb);
            _pizzaAppDbContext.SaveChanges();
        }

        public List<Pizza> GetAll()
        {
            return _pizzaAppDbContext.Pizzas.ToList();
        }

        public Pizza GetById(int id)
        {
            return _pizzaAppDbContext.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Pizza entity)
        {
            _pizzaAppDbContext.Pizzas.Add(entity);
            _pizzaAppDbContext.SaveChanges();

            return entity.Id;
        }

        public void Update(Pizza entity)
        {
            _pizzaAppDbContext.Pizzas.Update(entity);
            _pizzaAppDbContext.SaveChanges();

        }
    }
}
