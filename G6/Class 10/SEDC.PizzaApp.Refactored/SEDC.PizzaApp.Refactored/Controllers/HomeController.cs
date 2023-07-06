using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Refactored.Models;
using SEDC.PizzaApp.Refactored.Services.Interfaces;
using SEDC.PizzaApp.Refactored.ViewModels.Home;
using System.Diagnostics;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _orderService;
        private readonly IPizzaService _pizzaService;

        public HomeController(ILogger<HomeController> logger, IOrderService orderService, IPizzaService pizzaService)
        {
            _logger = logger;
            _orderService = orderService;
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            //1.get the number of orders
            int totalNumberOfOrders = _orderService.GetAllOrders().Count;

            //2.get the names of all pizzas that are on promotion
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel
            {
                NumberOfOrdersInTheApp = totalNumberOfOrders,
                PizzasOnPromotion = _pizzaService.GetPizzasOnPromotion()
            };

            return View(homeIndexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}