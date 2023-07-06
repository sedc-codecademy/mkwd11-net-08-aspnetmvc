using DomainModels;
using ViewModels;

namespace Mappers
{
    public static class PizzaMapper
    {
        public static PizzaViewModel ToViewModel(this Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                ImageUrl = pizza.ImageUrl
            };
        }
    }
}
