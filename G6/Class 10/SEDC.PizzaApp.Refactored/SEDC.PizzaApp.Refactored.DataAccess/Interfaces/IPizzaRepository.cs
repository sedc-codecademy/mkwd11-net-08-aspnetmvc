using SEDC.PizzaApp.Refactored.Domain.Pizzas;

namespace SEDC.PizzaApp.Refactored.DataAccess.Interfaces
{
    //this interface now has all signatures from IRepository + GetPizzasOnPromotion
    public interface IPizzaRepository : IRepository<Pizza>
    {
        List<Pizza> GetPizzasOnPromotion();
    }
}
