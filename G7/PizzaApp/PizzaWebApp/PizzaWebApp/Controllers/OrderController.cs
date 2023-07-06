using Business.Abstraction;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace PizzaWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View(_orderService.GetAll());
        }

        public IActionResult CreateOrder()
        {
            return View(new OrderViewModel());
        }

        [HttpPost]
        public IActionResult Save(OrderViewModel model)
        {
            var id = _orderService.Save(model);

            return RedirectToAction("Details", new { id = id });
        }

        public IActionResult Details(int id)
        {
            return View(_orderService.Details(id));
        }

        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
