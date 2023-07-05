using PizzaAppRefactored.DataAccess;
using PizzaAppRefactored.Domain.Models;
using PizzaAppRefactored.Mappers;
using PizzaAppRefactored.Services.Interfaces;
using PizzaAppRefactored.ViewModels.PizzaViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.Services.Implementations
{
    public class PizzaService : IPizzaService
    {
        private IRepository<Pizza> _pizzaRepository;

        public PizzaService(IRepository<Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
        public List<PizzaOptionsViewModel> GetPizzasForDropdown()
        {
            List<Pizza> pizzasDb = _pizzaRepository.GetAll();

            List<PizzaOptionsViewModel> pizzasOptionsViewModel = new List<PizzaOptionsViewModel>();

            foreach(var pizza in pizzasDb)
            {
                var pizzaOptionViewModel = PizzaMapper.ToPizzaOptionsViewModel(pizza);

                pizzasOptionsViewModel.Add(pizzaOptionViewModel);
            }
            return pizzasOptionsViewModel;
        }
    }
}
