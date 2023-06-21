using PizzaApp.Refactored._07.DataAccess;
using PizzaApp.Refactored._07.Domain;
using PizzaApp.Refactored._07.Mappers;
using PizzaApp.Refactored._07.ViewModels;

namespace PizzaApp.Refactored._07.Services
{
    public class PizzaService : IPizzaService
    {
        private IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository) //Dependency Injection
        {
            _pizzaRepository = pizzaRepository;
        }
        public List<PizzaViewModel> GetPizzasForDropdown()
        {
            List<Pizza> pizzasDb = _pizzaRepository.GetAll();

            return pizzasDb.Select(x => x.MapToPizzaViewModel()).ToList();
        }

        public string GetPizzaOnPromotion()
        {
            return _pizzaRepository.GetPizzaOnPromotion().Name;
        }
    }
}
