using SEDC.PizzaApp.DomainModels;
using SEDC.PizzaApp.ViewModels;

namespace SEDC.PizzaApp.Services.Mappers
{
    public static class SizeMapper
    {
        public static SizeViewModel ToViewModel(this Size size)
        {
            return new SizeViewModel
            {
                Id = size.Id,
                Name = size.Name,
                Description = size.Description,
            };
        }

        //this mapper is for mapping ViewModel to DomainModel on edit as a function, the ID of the edited object will be repassed
        public static Size ToDomainModel(this SizeViewModel model)
        {
            return new Size
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
            };
        }

        //this mapper is for mapping ViewModel to DomainModel on save as a function, the ID of the new object needs to be genereated and pass to the mapper
        public static Size ToDomainModel(this SizeViewModel model, int id)
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
