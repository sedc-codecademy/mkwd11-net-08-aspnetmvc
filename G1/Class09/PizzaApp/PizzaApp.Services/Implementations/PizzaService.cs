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

        public async Task CreatePizza(PizzaViewModel pizzaViewModel)
        {
            await _pizzaRepository.Insert(pizzaViewModel.ToPizza());
        }

        public async Task<int> DeletePizzaById(int id)
        {
            return await _pizzaRepository.DeleteById(id);
        }

        public async Task EditPizza(PizzaViewModel pizzaViewModel)
        {
            Pizza pizzaDb = await _pizzaRepository.GetById(pizzaViewModel.Id);

            if(pizzaDb == null)
            {
                throw new Exception("Pizza not found");
            }

            pizzaDb.Price = pizzaViewModel.Price;
            pizzaDb.IsOnPromotion = pizzaViewModel.IsOnPromotion;
            pizzaDb.Name = pizzaViewModel.Name;
            pizzaDb.ImageUrl = pizzaViewModel.ImageUrl;

            await _pizzaRepository.Update(pizzaDb);
        }

        public async Task<PizzaDetailsViewModel> GetPizzaDetails(int id)
        {
            Pizza pizzaDb = await _pizzaRepository.GetById(id);

            return pizzaDb.ToPizzaDetailsViewModel();
        }

        public async Task<PizzaViewModel> GetPizzaForEditing(int id)
        {
            Pizza pizza = await _pizzaRepository.GetById(id);

            if(pizza == null)
            {
                throw new Exception("Pizza not found");
            }

            PizzaViewModel pizzaViewModel = pizza.ToPizzaViewModel();

            return pizzaViewModel;
        }

        public async Task<List<PizzaListViewModel>> GetPizzasForCards()
        {
            List<Pizza> pizzasDb = await _pizzaRepository.GetAll();

            return pizzasDb.Select(x => x.ToPizzaListViewModel()).ToList();
        }
    }
}
