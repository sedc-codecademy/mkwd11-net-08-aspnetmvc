using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.DataAccess.Repositories.Interfaces;
using SEDC.PizzaApp.DomainModels;
using SEDC.PizzaApp.Services.Abstraction;

namespace SEDC.PizzaApp.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IRepository<MenuItem> _menuItemRepository;

        public MenuItemService(IRepository<MenuItem> menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public int GetById(int id/*, int page, int pageSize*/)
        {
            var menuItem = _menuItemRepository.Query().Include(x => x.Pizza).Include(x => x.Size).FirstOrDefault(x => x.Id == id);

            //page: 3, itemsPerPage: 20
            //_menuItemRepository.Query().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return menuItem.Id;
        }
    }
}
