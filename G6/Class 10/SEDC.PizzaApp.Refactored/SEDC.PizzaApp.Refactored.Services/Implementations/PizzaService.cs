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
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
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

        public List<string> GetPizzasOnPromotion()
        {
            //1.get pizzas on promotion from db
            List<Pizza> pizzasOnPromotion = _pizzaRepository.GetPizzasOnPromotion();

            //2.get the names of the pizzas
            return pizzasOnPromotion.Select(x => x.Name).ToList();
        }
    }
}
