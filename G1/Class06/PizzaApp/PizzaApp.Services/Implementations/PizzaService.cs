namespace PizzaApp.Services.Implementations
{
    using PizzaApp.DataAccess.Repositories.Interfaces;
    using PizzaApp.Domain.Models;
    using PizzaApp.Mappers;
    using PizzaApp.Services.Interfaces;
    using PizzaApp.ViewModels.PizzaViewModels;

    public class PizzaService : IPizzaService
    {
        private IRepository<Pizza> _pizzaRepository;

        public PizzaService(IRepository<Pizza> _pizzaRepository)
        {
            this._pizzaRepository = _pizzaRepository;
        }

        public async Task<List<PizzaListViewModel>> GetPizzasForCards()
        {
            List<Pizza> pizzasDb = await _pizzaRepository.GetAll();

            return pizzasDb.Select(x => x.ToPizzaListViewModel()).ToList();
        }
    }
}
