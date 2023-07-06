using PizzaApp.Refactored._09.Domain;
using PizzaApp.Refactored._09.ViewModels;

namespace PizzaApp.Refactored._09.Mappers
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
