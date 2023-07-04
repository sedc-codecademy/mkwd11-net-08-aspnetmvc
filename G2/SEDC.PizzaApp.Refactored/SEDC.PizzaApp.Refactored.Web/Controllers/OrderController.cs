using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Refactored.Services;
using SEDC.PizzaApp.Refactored.Services.Abstraction;
using SEDC.PizzaApp.Refactored.ViewModels.OrderViewModels;

namespace SEDC.PizzaApp.Refactored.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IUserService _userService;

        public OrderController(IOrderService orderService, 
                               IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;

        }

        public IActionResult Index()
        {
            List<OrderListViewModel> orderListViewModels = _orderService.GetAllOrders();
            return View(orderListViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            ViewBag.Users = _userService.GetUsersForDropdown();
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.CreateOrder(orderViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("ExceptionPage");
            }
        }
    }
}
