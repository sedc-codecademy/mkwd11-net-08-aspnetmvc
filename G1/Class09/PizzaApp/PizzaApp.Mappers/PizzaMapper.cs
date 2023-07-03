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
                ImgUrl = pizza.ImageUrl,
                Price = pizza.Price
            };
        }

        public static PizzaDetailsViewModel ToPizzaDetailsViewModel(this Pizza pizza)
        {
            return new PizzaDetailsViewModel()
            {
                Price = pizza.Price,
                ImageUrl = pizza.ImageUrl,
                IsOnPromotion = pizza.IsOnPromotion,
                Name = pizza.Name,
                NumberOfTimesOrdered = pizza.PizzaOrders.Count()
            };
        }

        public static Pizza ToPizza(this PizzaViewModel pizzaViewModel)
        {
            return new Pizza()
            {
                ImageUrl = pizzaViewModel.ImageUrl,
                IsOnPromotion = pizzaViewModel.IsOnPromotion,
                Name = pizzaViewModel.Name,
                Price = pizzaViewModel.Price
            };
        }

        public static PizzaViewModel ToPizzaViewModel(this Pizza pizzaDb)
        {
            return new PizzaViewModel()
            {
                Id = pizzaDb.Id,
                ImageUrl = pizzaDb.ImageUrl,
                IsOnPromotion = pizzaDb.IsOnPromotion,
                Name = pizzaDb.Name,
                Price = pizzaDb.Price
            };
        }
    }
}
