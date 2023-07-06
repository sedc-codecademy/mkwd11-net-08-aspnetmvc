using SEDC.PizzaApp.Refactored.Domain.Models;
using SEDC.PizzaApp.Refactored.ViewModels.PizzaViewModels;

namespace SEDC.PizzaApp.Refactored.Mappers.Extensions
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
