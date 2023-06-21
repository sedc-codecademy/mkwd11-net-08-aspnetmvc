using PizzaApp.Refactored._07.Domain;
using PizzaApp.Refactored._07.ViewModels;

namespace PizzaApp.Refactored._07.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaViewModel MapToPizzaViewModel(this Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name
            };
        }
    }
}
