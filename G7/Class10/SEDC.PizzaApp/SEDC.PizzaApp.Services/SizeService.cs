using SEDC.PizzaApp.DataAccess.Helpers;
using SEDC.PizzaApp.DataAccess.Repositories.Interfaces;
using SEDC.PizzaApp.DataAccess.Storage;
using SEDC.PizzaApp.DomainModels;
using SEDC.PizzaApp.Services.Abstraction;
using SEDC.PizzaApp.Services.Mappers;
using SEDC.PizzaApp.ViewModels;

namespace SEDC.PizzaApp.Services
{
    public class SizeService : ISizeService
    {
        public readonly IRepository<Size> _sizeRepository;

        public SizeService(IRepository<Size> sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }
        
        public List<SizeViewModel> GetAll()
        {
            //Using the Custom Mapper we get a List of SizeViewModels
            var sizes = _sizeRepository.GetAll().Select(x => x.ToViewModel()).OrderBy(x => x.Name).ToList();
            return sizes;
        }

        public SizeViewModel GetById(int id)
        {
            //Get the Size with the matching id
            var size = _sizeRepository.GetById(id);

            //Directrly transform the Domain Model to a SizeViewModel using the Custom Mapper
            return size.ToViewModel();
        }

        public void Save(SizeViewModel model)
        {
            //Cant have more than one Size with the same name
            if (_sizeRepository.GetAll().Any(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id))
            {
                throw new ArgumentException("Size with same name already exists");
            }

            //The ID is 0 only when we are Creating a new Size
            if (model.Id == 0)
            {
                //Use the Custom Mapper for ViewModel -> DomainModel
                var size = model.ToDomainModel();
                //var size = new Size()
                //{
                //    Name = model.Name,
                //    Description = model.Description
                //};

                _sizeRepository.Insert(size);

                return;
            }

            //This part handles the Edit
            var existingSize = _sizeRepository.GetById(model.Id);

            if (existingSize == null)
            {
                throw new Exception($"Size with id {model.Id} does not exist");
            }

            existingSize.Name = model.Name;
            existingSize.Description = model.Description;

            _sizeRepository.Update(existingSize);
        }

        public void Remove(int id)
        {
            _sizeRepository.DeleteById(id);
        }

        public List<SizeViewModel> FilteredSizes(string filter)
        {
            filter = filter == null ? string.Empty : filter;

            //Select * From Sizes => 4
            //Memory: Where Name Like '' OR Description Like ''
            //Memory: Transform the object to viewModel
            //var filteredSizes = _sizeRepository.GetAll()
            //    .Where(x => x.Name.ToLower().Contains(filter)
            //                || x.Description.ToLower().Contains(filter))
            //    .Select(x => x.ToViewModel())
            //    .ToList();

            //Select Id as Id, Name as Name, Description as Description From Sizes Where Name Like '' OR Description Like '' => Objects that met the filtering
            var filteredSizes = _sizeRepository.Query()
                .Where(x => x.Name.ToLower().Contains(filter)
                            || x.Description.ToLower().Contains(filter))
                .Select(x => x.ToViewModel())
                .ToList();

            return filteredSizes;
        }
    }
}
