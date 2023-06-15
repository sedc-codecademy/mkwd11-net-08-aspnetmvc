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
            ViewData["Message"] = $"The number of orders is: {ordersDb.Count}";
            ViewData["Title"] = "Orders list";
            ViewData["Date"] = DateTime.Now.ToShortDateString();

            //=========map from domain models to view models===========


            //=======FIRST WAY============
            //List<OrderDetailsViewModel> orderViewModels = ordersDb.Select(x => new OrderDetailsViewModel
            //{
            //    PaymentMethod = x.PaymentMethod,
            //    PizzaName = x.Pizza.Name,
            //    Price = x.Pizza.Price + 50,
            //    UserFullname = $"{x.User.FirstName} {x.User.LastName}"
            //}).ToList();

            //=======SECOND WAY============
            //List<OrderDetailsViewModel> orderViewModels = new List<OrderDetailsViewModel>();
            //foreach(Order order in ordersDb)
            //{
            //    viewModels.Add(new OrderDetailsViewModel
            //    {
            //        PaymentMethod = order.PaymentMethod,
            //        PizzaName = order.Pizza.Name,
            //        Price = order.Pizza.Price + 50,
            //        UserFullname = $"{order.User.FirstName} {order.User.LastName}"
            //    });
            //}

            //=======THIRD WAY============
            //From each object in ordersDb list we project (map) an object of type OrderDetailsViewModel
            List<OrderDetailsViewModel> orderViewModels = ordersDb.Select(x => OrderMapper.ToOrderDetailsViewModel(x))
                .ToList();

            //return View(ordersDb);
            return View(orderViewModels);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return new EmptyResult();
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                return new EmptyResult();
            }


            ViewBag.Message = "You are on the order details page";
            ViewBag.User = StaticDb.Users.First();

            //======map from domain to view model===========

            //OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel
            //{
            //    PaymentMethod = orderDb.PaymentMethod,
            //    PizzaName = orderDb.Pizza.Name,
            //    Price = orderDb.Pizza.Price + 50,
            //    UserFullname = $"{orderDb.User.FirstName} {orderDb.User.LastName}"
            //};

            //From orderDb we project (map) an object of type OrderDetailsViewModel
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(orderDb);

            //return View(orderDb);
            return View(orderDetailsViewModel);
        }
    }
}
