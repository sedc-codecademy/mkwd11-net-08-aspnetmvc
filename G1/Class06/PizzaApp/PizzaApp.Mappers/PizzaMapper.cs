using PizzaApp.Domain.Models;
using PizzaApp.ViewModels.PizzaViewModels;

namespace PizzaApp.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaListViewModel ToPizzaListViewModel(this Pizza pizza)
        {
            return new PizzaListViewModel()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                IsOnPromotion = pizza.IsOnPromotion
            };
        }
    }
}
