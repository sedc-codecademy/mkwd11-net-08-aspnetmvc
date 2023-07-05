using PizzaAppRefactored.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.DataAccess.Implementations
{
    public class PizzaRepository : IRepository<Pizza>
    {
        public void DeleteById(int id)
        {
            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                throw new Exception($"Pizza with id {id} was not found!");
            }
            StaticDb.Pizzas.Remove(pizza);
        }

        public List<Pizza> GetAll()
        {
            return StaticDb.Pizzas;
        }

        public Pizza GetById(int id)
        {
            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                throw new Exception($"Pizza with id {id} was not found!");
            }
            return pizza;
        }

        public int Insert(Pizza entity)
        {
            entity.Id = StaticDb.Pizzas.Count() + 1;
            StaticDb.Pizzas.Add(entity);
            return entity.Id;
        }

        public void Update(Pizza entity)
        {
            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Id == entity.Id);
            if (pizzaDb == null)
            {
                throw new Exception($"Pizza with id {entity.Id} was not found!");
            }

            int index = StaticDb.Pizzas.FindIndex(x => x.Id == entity.Id);

            StaticDb.Pizzas[index] = entity;
        }
    }
}
