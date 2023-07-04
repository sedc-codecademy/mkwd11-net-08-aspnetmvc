using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Refactored.Services;
using SEDC.PizzaApp.Refactored.ViewModels.OrderViewModels;

namespace SEDC.PizzaApp.Refactored.Web.Controllers
{
    public class OrderController : Controller
    {
        private OrderService _orderService;

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
