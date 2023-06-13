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
            return View();
        }

        public IActionResult Details(int? id)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(o => o.Id == id);

            OrderDetailsViewModel orderDetails = orderDb.MapFromOrderToOrderDetailsViewModel();

            return View(orderDetails);
        }
    }
}
