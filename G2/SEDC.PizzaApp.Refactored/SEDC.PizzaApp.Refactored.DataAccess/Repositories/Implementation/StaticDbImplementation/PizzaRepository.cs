using SEDC.PizzaApp.Refactored.DataAccess.Data;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Abstraction;
using SEDC.PizzaApp.Refactored.Domain.Models;

namespace SEDC.PizzaApp.Refactored.DataAccess.Repositories.Implementation.StaticDbImplementation
{
    public class PizzaRepository : IPizzaRepository
    {
        public Pizza GetPizzaOnPromotion()
        {
            return StaticDb.Pizzas.FirstOrDefault(pizza => pizza.IsOnPromotion);
        }

        public void DeleteById(int id)
        {
            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                throw new Exception($"Pizza with id {id} was not found");
            }
            StaticDb.Pizzas.Remove(pizza);
        }

        public List<Pizza> GetAll()
        {
            return StaticDb.Pizzas;
        }

        public Pizza GetById(int id)
        {
            return StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Pizza entity)
        {
            entity.Id = ++StaticDb.PizzaId;
            StaticDb.Pizzas.Add(entity);
            return entity.Id;
        }

        public void Update(Pizza entity)
        {
            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == entity.Id);
            if (pizza == null)
            {
                throw new Exception($"Pizza with id {entity.Id} was not found");
            }
            int index = StaticDb.Pizzas.IndexOf(pizza);
            StaticDb.Pizzas[index] = entity;
        }
    }
}
