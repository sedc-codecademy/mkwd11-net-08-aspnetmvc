using Business.Abstraction;
using DataAccess.Abstraction;
using DomainModels;
using Mappers;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;

namespace Business.Implementation
{
    public class SizeService : ISizeService
    {
        private readonly IRepository<Size> _sizeRepository;
        private readonly IRepository<MenuItem> _menuItemRepository;

        public SizeService(IRepository<Size> sizeRepository, IRepository<MenuItem> menuItemRepository)
        {
            _sizeRepository = sizeRepository;
            _menuItemRepository = menuItemRepository;
        }

        public List<SizeViewModel> GetAll()
        {
            var sizes = _sizeRepository.GetAll().Select(x => x.ToViewModel()).OrderBy(x => x.Description).ToList();
            return sizes;
        }

        public List<SelectListItem> GetSizesSelectList()
        {
            return _sizeRepository.GetAll().Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }

        public SizeViewModel GetById(int id)
        {
            var size = _sizeRepository.GetById(id);

            if (size == null)
            {
                throw new Exception($"Size with Id {id} not found");
            }

            return size.ToViewModel();
        }

        public void Save(SizeViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name)
                || string.IsNullOrEmpty(model.Description))
            {
                throw new Exception($"All properties are required.");
            }

            if (_sizeRepository.GetAll().Any(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id))
            {
                throw new Exception($"Size with the name {model.Name} already exists");
            }


            if (model.Id == 0)
            {
                var size = new Size(model.Name, model.Description);

                _sizeRepository.Insert(size);

                return;
            }

            var existingSize = _sizeRepository.GetById(model.Id);

            if (existingSize == null)
            {
                throw new Exception($"Size with id {model.Id} does not exist");
            }

            existingSize.Name = model.Name;
            existingSize.Description = model.Description;

            _sizeRepository.Update(existingSize);
        }

        public void Delete(int id)
        {
            var existingSize = _sizeRepository.GetById(id);

            if (existingSize == null)
            {
                throw new Exception($"Size with id {id} does not exist");
            }

            var menuItems = _menuItemRepository.GetAll().Where(x => x.Size.Id == id).ToList();

            foreach (var menuItem in menuItems)
            {
                _menuItemRepository.DeleteById(menuItem.Id);
            }

            _sizeRepository.DeleteById(existingSize.Id);
        }
    }
}
