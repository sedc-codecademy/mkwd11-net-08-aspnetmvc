using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Services.Abstraction;
using SEDC.PizzaApp.ViewModels;
using System.Diagnostics;

namespace SEDC.PizzaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuItemService _menuItemService; 

        public HomeController(ILogger<HomeController> logger, IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _menuItemService.GetById(3);
            return View();
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}