using PizzaApp.Refactored._07.Domain;

namespace PizzaApp.Refactored._07.DataAccess
{
    public class PizzaRepository : IPizzaRepository
    {

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

        public Pizza GetPizzaOnPromotion()
        {
            return StaticDb.Pizzas.FirstOrDefault(x => x.IsOnPromotion);
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
