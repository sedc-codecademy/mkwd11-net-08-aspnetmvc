using SEDC.PizzaApp.Refactored.DataAccess.Implementations;
using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Pizzas;
using SEDC.PizzaApp.Refactored.Mappers.Pizzas;
using SEDC.PizzaApp.Refactored.Services.Interfaces;
using SEDC.PizzaApp.Refactored.ViewModels.Pizzas;

namespace SEDC.PizzaApp.Refactored.Services.Implementations
{
    public class PizzaService : IPizzaService
    {
        private IRepository<Pizza> _pizzaRepository;

        public PizzaService(IRepository<Pizza> pizzaRepository)
        {
            //_pizzaRepository = new PizzaRepository();
            _pizzaRepository = pizzaRepository;
        }
        public List<PizzaDropDownViewModel> GetAllPizzasForDropdown()
        {
            //get pizzas from db
            List<Pizza> pizzasDb = _pizzaRepository.GetAll();

            //map to view models
            List<PizzaDropDownViewModel> result = pizzasDb.Select(p => p.ToPizzaDropDownViewModel()).ToList();

            //return
            return result;
        }
    }
}
