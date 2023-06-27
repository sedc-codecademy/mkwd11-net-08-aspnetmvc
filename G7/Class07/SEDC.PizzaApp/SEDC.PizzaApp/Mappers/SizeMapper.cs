using SEDC.PizzaApp.DomainModels;
using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp.Mappers
{
    public static class SizeMapper
    {
        public static SizeViewModel ToViewModel (this Size size)
        {
            return new SizeViewModel
            {
                Id = size.Id,
                Name = size.Name,
                Description = size.Description,
            };
        }

        public static Size ToDomainModel(this SizeViewModel model)
        {
            return new Size
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
            };
        }

        public static Size ToDomainModel (this SizeViewModel model, int id)
        {
            return new Size
            {
                Id = id,
                Name = model.Name,
                Description = model.Description,
            };
        }
    }
}
