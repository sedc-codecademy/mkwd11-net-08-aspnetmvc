using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models.Domain;
using PizzaApp.Models.Mappers;
using PizzaApp.Models.ViewModels.OrderViewModels;

namespace PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersDb = StaticDb.Orders;

            ViewData["Message"] = $"The number of orders is: {ordersDb.Count}";
            ViewData["Title"] = "Order list";
            ViewData["Date"] = DateTime.Now.ToShortDateString();

            List<OrderListViewModel> orderList = ordersDb.Select(x => x.MapFromOrderToOrderListViewModel()).ToList();

            return View(orderList);
        }

        public IActionResult Details(int? id)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(o => o.Id == id);

            OrderListViewModel orderDetails = orderDb.MapFromOrderToOrderListViewModel();

            ViewBag.Message = "You are on the order details page";
            ViewBag.User = orderDb.User;
            ViewData["User"] = orderDb.User;
            return View(orderDetails);
        }
    }
}
