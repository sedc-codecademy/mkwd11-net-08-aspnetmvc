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
    public class PizzaRepositoryEntity : IPizzaRepository
    {
        private PizzaAppDbContext _pizzaAppDbContext;

        public PizzaRepositoryEntity(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }

        public void DeleteById(int id)
        {
            Pizza pizzaDb = _pizzaAppDbContext.Pizzas.FirstOrDefault(pizza => pizza.Id == id);

            if (pizzaDb == null)
            {
                throw new Exception($"The pizza with id {id} was not found!");
            }

            _pizzaAppDbContext.Pizzas.Remove(pizzaDb);
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

        public Pizza GetPizzaOnPromotion()
        {
            return _pizzaAppDbContext.Pizzas.FirstOrDefault(x => x.IsOnPromotion);
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
