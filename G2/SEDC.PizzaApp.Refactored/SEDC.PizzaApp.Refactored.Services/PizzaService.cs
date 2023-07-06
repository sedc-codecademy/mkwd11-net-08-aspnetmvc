using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Abstraction;
using SEDC.PizzaApp.Refactored.Domain.Models;
using SEDC.PizzaApp.Refactored.Mappers.Extensions;
using SEDC.PizzaApp.Refactored.Services.Abstraction;
using SEDC.PizzaApp.Refactored.ViewModels.PizzaViewModels;

namespace SEDC.PizzaApp.Refactored.Services
{
    public class PizzaService : IPizzaService
    {
        private IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public List<PizzaViewModel> GetPizzasForDropdown()
        {
            List<Pizza> pizzasDb = _pizzaRepository.GetAll();
            return pizzasDb.Select(x => x.MapToPizzaViewModel()).ToList();
        }

        public string GetPizzaNameOnPromotion()
        {
            return _pizzaRepository.GetPizzaOnPromotion().Name;
        }
    }
}
