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

        public IActionResult CreateOrder()
        {
            OrderViewModel orderViewModel = new OrderViewModel();

            ViewBag.Users = StaticDb.Users.Select(x => x.MapToUserSelectViewModel()).ToList();

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel orderViewModel)
        {
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderViewModel.UserId);

            if (userDb == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderViewModel.PizzaName);

            if (pizzaDb == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Order newOrder = orderViewModel.MapToOrder();
            newOrder.Id = StaticDb.OrderId + 1;
            StaticDb.Orders.Add(newOrder);
            StaticDb.OrderId++;

            return RedirectToAction("Index");
        }
    }
}
