using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;

namespace Business.Abstraction
{
    public interface IMenuService
    {
        List<MenuItemViewModel> GetAll();
        MenuItemCreateEditViewModel GetCreateEditViewModelById(int id);
        void Save(MenuItemCreateEditViewModel model);
        void Delete(int id);
        List<SelectListItem> GetMenuItemsSelectList();
    }
}
