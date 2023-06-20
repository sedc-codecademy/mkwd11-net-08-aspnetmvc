using PizzaApp.Models.Domain;
using PizzaApp.Models.ViewModels.PizzaViewModels;

namespace PizzaApp.Models.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaListViewModel MapFromPizzaToPizzaListViewModel(this Pizza pizza)
        {
            return new PizzaListViewModel()
            {
                Id = pizza.Id,
                imgUrl = pizza.ImageUrl,
                Name = pizza.Name,
                Price = pizza.Price
            };
        }

        public static PizzaDetailsViewModel MapFromPizzaToPizzaDetailsViewModel(this Pizza pizza)
        {
            return new PizzaDetailsViewModel()
            {
                ImageUrl = pizza.ImageUrl,
                Ingredients = pizza.Ingredients,
                IsOnPromotion = pizza.IsOnPromotion,
                Name = pizza.Name,
                PizzaSizes = pizza.PizzaSizes,
                Price = pizza.Price
            };
        }
    }
}
