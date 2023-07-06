using Business.Abstraction;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace PizzaWebApp.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly IPizzaService _pizzaService;
        private readonly ISizeService _sizeService;

        public MenuController(IMenuService menuService, IPizzaService pizzaService, ISizeService sizeService)
        {
            _menuService = menuService;
            _pizzaService = pizzaService;
            _sizeService = sizeService;
        }

        public IActionResult Index()
        {
            return View(_menuService.GetAll());
        }

        public IActionResult CreateEditMenuItem(int? id)
        {
            var menuItem = id.HasValue ? _menuService.GetCreateEditViewModelById(id.Value) : new MenuItemCreateEditViewModel();

            ViewBag.Pizzas = _pizzaService.GetPizzasSelectList();
            ViewBag.Sizes = _sizeService.GetSizesSelectList();

            return View(menuItem);
        }

        public IActionResult Save(MenuItemCreateEditViewModel model)
        {
            _menuService.Save(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _menuService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
