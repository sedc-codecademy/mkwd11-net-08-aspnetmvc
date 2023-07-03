using SEDC.PizzaApp.DataAccess.Helpers;
using SEDC.PizzaApp.DataAccess.Storage;
using SEDC.PizzaApp.Services.Abstraction;
using SEDC.PizzaApp.Services.Mappers;
using SEDC.PizzaApp.ViewModels;

namespace SEDC.PizzaApp.Services
{
    public class SizeService : ISizeService
    {
        public List<SizeViewModel> GetAll()
        {
            //Using the Custom Mapper we get a List of SizeViewModels
            var sizes = PizzaDb.Sizes.Select(x => x.ToViewModel()).OrderBy(x => x.Name).ToList();
            return sizes;
        }

        public SizeViewModel GetById(int id)
        {
            //Get the Size with the matching id
            var size = PizzaDb.Sizes.FirstOrDefault(x => x.Id == id);

            //Handle scenario where there is no such Size
            if (size == null)
            {
                throw new Exception("Size with Id {id} not found");
            }

            //Directrly transform the Domain Model to a SizeViewModel using the Custom Mapper
            return size.ToViewModel();
        }

        public void Save(SizeViewModel model)
        {
            //Cant have more than one Size with the same name
            if (PizzaDb.Sizes.Any(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id))
            {
                throw new ArgumentException("Size with same name already exists");
            }

            //The ID is 0 only when we are Creating a new Size
            if (model.Id == 0)
            {
                //Use the Custom Mapper for ViewModel -> DomainModel
                var size = model.ToDomainModel(CommonHelper.GetRandomId());

                PizzaDb.Sizes.Add(size);

                return;
            }

            //This part handles the Edit
            var existingSize = PizzaDb.Sizes.FirstOrDefault(x => x.Id == model.Id);

            if (existingSize == null)
            {
                throw new Exception($"Size with id {model.Id} does not exist");
            }

            existingSize.Name = model.Name;
            existingSize.Description = model.Description;
        }

        public void Remove(int id)
        {
            var existingSize = PizzaDb.Sizes.FirstOrDefault(x => x.Id == id);

            if (existingSize == null)
            {
                throw new Exception($"Size with id {id} does not exist");
            }

            PizzaDb.Sizes.Remove(existingSize);
        }
    }
}
