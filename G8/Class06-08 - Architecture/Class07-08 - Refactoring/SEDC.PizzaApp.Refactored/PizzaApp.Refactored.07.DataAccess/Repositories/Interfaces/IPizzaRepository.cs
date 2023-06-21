using PizzaApp.Refactored._07.Domain;

namespace PizzaApp.Refactored._07.DataAccess
{
    public interface IPizzaRepository : IRepository<Pizza>
    {
        Pizza GetPizzaOnPromotion();
    }
}
