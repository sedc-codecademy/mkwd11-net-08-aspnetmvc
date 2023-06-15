using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;
using System.Data;

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
            //List<OrderViewModel> orderViewModels = ordersFromDb.Select((order) => new OrderViewModel
            //{
            //    PizzaName = order.Pizza.Name,
            //    UserFullName = $"{order.User.FirstName} {order.User.LastName}",
            //    PaymentMethod = order.PaymentMethod,
            //    Price = order.Pizza.Price
            //}).ToList();

            //==MAPPING WITH HELPER MAP CLASS AND LINQ==
            //List<OrderViewModel> orderViewModels =
            //    ordersFromDb.Select(order => OrderMapper.ToOrderViewModel(order)).ToList();

            //==MAPPING WITH EXTENSION METHOD AND LINQ==
            List<OrderViewModel> orderViewModels =
                ordersFromDb.Select(order => order.ToOrderViewModelExtension())
                .ToList();

            return View(orderViewModels);
        }

        public IActionResult Details(int? id) 
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Pizza");
            }

            Order order = StaticDb.Orders.FirstOrDefault(order => order.Id == id);

            if (order == null)
            {
                return RedirectToAction("Error", "Pizza");
            }

            OrderViewModel orderViewModel = order.ToOrderViewModelExtension();

            return View(orderViewModel);
        }
    }
}
