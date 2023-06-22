using Microsoft.AspNetCore.Mvc;
using PizzaApp.Refactored._06.Services;
using PizzaApp.Refactored._06.Services.Services;
using PizzaApp.Refactored._06.ViewModels;

namespace PizzaApp.Refactored._06.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController()
        {
            _orderService = new OrderService();
        }
        public IActionResult Index()
        {
            List<OrderListViewModel> orderListViewModels = _orderService.GetAllOrders();
            return View(orderListViewModels);
        }
    }
}
