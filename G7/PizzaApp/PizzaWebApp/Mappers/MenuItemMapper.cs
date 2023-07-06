using DomainModels;
using Mappers;
using ViewModels;

namespace Mappers
{
    public static class MenuItemMapper
    {
        public static MenuItemViewModel ToViewModel(this MenuItem menuItem)
        {
            return new MenuItemViewModel
            {
                Id = menuItem.Id,
                Price = menuItem.Price,
                Pizza = menuItem.Pizza.ToViewModel(),
                Size = menuItem.Size.ToViewModel()
            };
        }
    }
}
