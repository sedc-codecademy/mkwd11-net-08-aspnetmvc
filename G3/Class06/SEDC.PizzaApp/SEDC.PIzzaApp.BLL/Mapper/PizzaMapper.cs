using SEDC.PizzaApp.Data.Models;
using SEDC.PIzzaApp.BLL.DTOs.Pizzas;

namespace SEDC.PizzaApp.Web.Mapper
{
    public static class PizzaMapper
    {
        public static PizzaDTO ToDTO(this Pizza pizza)
        {
            return new PizzaDTO
            {
                Id = pizza.Id,
                Name = pizza.Name,
                IsOnPromotion = pizza.IsOnPromotion,
                Price = pizza.Price
            };
        }
    }
}
