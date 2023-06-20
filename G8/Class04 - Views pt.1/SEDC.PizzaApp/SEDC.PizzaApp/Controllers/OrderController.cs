using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersDb = StaticDb.Orders;
            //From each object in ordersDb list we project (map) an object of type OrderDetailsViewModel
            List<OrderListViewModel> orderListViewModels = ordersDb
                .Select(x => x.MapToOrderListViewModel()).ToList();

            ViewData["Title"] = "These are the orders made with our app:";
            ViewData["NumberOfOrders"] = StaticDb.Orders.Count;

            ViewData["FirstUser"] = StaticDb.Orders.First().User;

            return View(orderListViewModels);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new EmptyResult();
            }

            ViewBag.Message = StaticDb.Message;
            ViewBag.User = StaticDb.Users.First();

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);

            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            OrderDetailsViewModel orderDetailsViewModel = orderDb.MapToOrderDetailsViewModel();
            return View(orderDetailsViewModel);
        }

        public IActionResult Delete(int? id) //localhost:[port]/Order/Delete/1
        {
            if (id == null)
            {
                return new EmptyResult();
            }
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }
            OrderDetailsViewModel orderDetailsViewModel = orderDb.MapToOrderDetailsViewModel();
            return View(orderDetailsViewModel);
        }
    }
}
