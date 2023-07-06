using Business.Abstraction;
using DomainModels;
using Mappers;
using ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Abstraction;

namespace Business.Implementation
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<Pizza> _pizzaRepository;
        private readonly IRepository<MenuItem> _menuItemRepository;

        public PizzaService(IRepository<Pizza> pizzaRepository, IRepository<MenuItem> menuItemRepository)
        {
            _pizzaRepository = pizzaRepository;
            _menuItemRepository = menuItemRepository;
        }

        public List<PizzaViewModel> GetAll()
        {
            var pizzas = _pizzaRepository.GetAll().Select(x => x.ToViewModel()).OrderBy(x => x.Name).ToList();
            return pizzas;
        }

        public PizzaViewModel GetById(int id)
        {
            var pizza = _pizzaRepository.GetById(id);

            if (pizza == null)
            {
                throw new Exception($"Pizza with Id {id} not found");
            }

            return pizza.ToViewModel();
        }

        public void Save(PizzaViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name)
                || string.IsNullOrEmpty(model.Description)
                || string.IsNullOrEmpty(model.ImageUrl))
            {
                throw new Exception($"All properties are required.");
            }

            if (_pizzaRepository.GetAll().Any(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id))
            {
                throw new Exception($"Pizza with the name {model.Name} already exists");
            }

            if (model.Id == 0)
            {
                var pizza = new Pizza(model.Name, model.Description, model.ImageUrl);

                _pizzaRepository.Insert(pizza);

                return;
            }

            var existingPizza = _pizzaRepository.GetById(model.Id);

            if (existingPizza == null)
            {
                throw new Exception($"Pizza with id {model.Id} does not exist");
            }

            existingPizza.Name = model.Name;
            existingPizza.Description = model.Description;
            existingPizza.ImageUrl = model.ImageUrl;

            _pizzaRepository.Update(existingPizza);
        }

        public void Delete(int id)
        {
            var existingPizza = _pizzaRepository.GetById(id);

            if (existingPizza == null)
            {
                throw new Exception($"Pizza with id {id} does not exist");
            }

            var menuItems = _menuItemRepository.GetAll().Where(x => x.Pizza.Id == id).ToList();

            foreach (var menuItem in menuItems)
            {
                _menuItemRepository.DeleteById(menuItem.Id);
            }

            _pizzaRepository.DeleteById(existingPizza.Id);
        }

        public List<SelectListItem> GetPizzasSelectList()
        {
            return _pizzaRepository.GetAll().Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }
    }
}
