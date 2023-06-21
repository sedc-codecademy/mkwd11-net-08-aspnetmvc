using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Mapers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return new EmptyResult();
            }
            Order order = StaticDb.orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return new EmptyResult();
            }
            OrderDetailsViewModel viewModel = OrderMaper.OrderToViewModel(order);
            return View(viewModel);

        }
    }
}
