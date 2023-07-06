using PizzaApp.Refactored._09.Domain;

namespace PizzaApp.Refactored._09.DataAccess
{
    public interface IPizzaRepository : IRepository<Pizza>
    {
        Pizza GetPizzaOnPromotion();
    }
}
