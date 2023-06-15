using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersFromDb = StaticDb.Orders;

            //==MANUAL MAPPING==
            //List<OrderViewModel> orderViewModels = new List<OrderViewModel>();

            //foreach (Order order in ordersFromDb) 
            //{
            //    var temporaryOrderViewModel = new OrderViewModel()
            //    {
            //        PizzaName = order.Pizza.Name,
            //        UserFullName = $"{order.User.FirstName} {order.User.LastName}",
            //        PaymentMethod = order.PaymentMethod,
            //        Price = order.Pizza.Price
            //    };

            //    orderViewModels.Add(temporaryOrderViewModel);
            //}

            //==MANUAL MAPING WITH LINQ
            List<OrderViewModel> orderViewModels = ordersFromDb.Select((order) => new OrderViewModel
            {
                PizzaName = order.Pizza.Name,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                PaymentMethod = order.PaymentMethod,
                Price = order.Pizza.Price
            }).ToList();

            return View(orderViewModels);
        }
    }
}
