using Business.Abstraction;
using DataAccess.Abstraction;
using DomainModels;
using Mappers;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;

namespace Business.Implementation
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<MenuItem> _menuItemRepository;
        private readonly IRepository<Size> _sizeRepository;
        private readonly IRepository<Pizza> _pizzaRepository;

        public MenuService(IRepository<MenuItem> menuItemRepository, IRepository<Size> sizeRepository, IRepository<Pizza> pizzaRepository)
        {
            _menuItemRepository = menuItemRepository;
            _sizeRepository = sizeRepository;
            _pizzaRepository = pizzaRepository;
        }

        public List<MenuItemViewModel> GetAll()
        {
            var menu = _menuItemRepository.GetAll().Select(x => x.ToViewModel()).OrderBy(x => x.Pizza.Name).ThenBy(x => x.Size.Description).ToList();
            return menu;
        }

        public MenuItemCreateEditViewModel GetCreateEditViewModelById(int id)
        {
            var item = _menuItemRepository.GetById(id);

            if (item == null)
            {
                throw new Exception($"Menu item with that id does not exist");
            }

            var menuItem = new MenuItemCreateEditViewModel
            {
                Id = item.Id,
                Price = item.Price,
                SelectedPizzaId = item.Pizza.Id,
                SelectedSizeId = item.Size.Id
            };

            return menuItem;
        }

        public void Save(MenuItemCreateEditViewModel model)
        {
            if (model.SelectedSizeId == 0 || model.SelectedPizzaId == 0 || model.Price == 0)
            {
                throw new Exception($"All properties are required.");
            }

            var selectedSize = _sizeRepository.GetById(model.SelectedSizeId);

            if (selectedSize == null)
            {
                throw new Exception($"Selected size does not exist.");
            }

            var selectedPizza = _pizzaRepository.GetById(model.SelectedPizzaId);

            if (selectedPizza == null)
            {
                throw new Exception($"Selected pizza does not exist.");
            }

            if (model.Price <= 0)
            {
                throw new Exception("Price should be larger than 0.");
            }

            if (_menuItemRepository.GetAll().Any(x => x.Id != model.Id && x.Pizza.Id == model.SelectedPizzaId && x.Size.Id == model.SelectedSizeId))
            {
                throw new Exception($"This menu item already exist.");
            }

            if (model.Id == 0)
            {
                var menuItem = new MenuItem(selectedPizza.Id, selectedSize.Id, model.Price);

                _menuItemRepository.Insert(menuItem);

                return;
            }

            var existingMenuItem = _menuItemRepository.GetById(model.Id);

            if (existingMenuItem == null)
            {
                throw new Exception($"Menu item does not exist.");
            }

            existingMenuItem.Pizza = selectedPizza;
            existingMenuItem.Size = selectedSize;
            existingMenuItem.Price = model.Price;

            _menuItemRepository.Update(existingMenuItem);
        }

        public void Delete(int id)
        {
            var existingMenuItem = _menuItemRepository.GetById(id);

            if (existingMenuItem == null)
            {
                throw new Exception($"Menu item does not exist.");
            }

            _menuItemRepository.DeleteById(existingMenuItem.Id);
        }

        public List<SelectListItem> GetMenuItemsSelectList()
        {
            return _menuItemRepository.GetAll().Select(x => new SelectListItem(x.ToString(), x.Id.ToString())).ToList();
        }
    }
}
