using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Refactored.Services.Abstraction;
using SEDC.PizzaApp.Refactored.ViewModels.HomeViewModels;
using SEDC.PizzaApp.Refactored.Web.Models;
using System.Diagnostics;

namespace SEDC.PizzaApp.Refactored.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPizzaService _pizzaService;
        private IOrderService _orderService;


        public HomeController(IPizzaService pizzaService, 
                              IOrderService orderService)
        {
            _pizzaService = pizzaService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel();
            homeIndexViewModel.PizzaOnPromotion = _pizzaService.GetPizzaNameOnPromotion();
            homeIndexViewModel.OrderCount = _orderService.GetAllOrders().Count;
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