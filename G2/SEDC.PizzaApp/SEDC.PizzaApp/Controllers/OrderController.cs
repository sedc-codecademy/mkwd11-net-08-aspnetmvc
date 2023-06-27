using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;
using System.Data;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
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
            List<OrderListViewModel> orderViewModels =
                ordersFromDb.Select(order => order.ToOrderListViewModel())
                .ToList();

            ViewBag.NumberOfOrders = orderViewModels.Count;
            ViewBag.Date = DateTime.Now.ToShortDateString();
            ViewBag.FirstUser = StaticDb.Orders.First().User;

            return View(orderViewModels);
        }

        [HttpGet]
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

            OrderDetailsViewModel viewModel = order.ToOrderDetailsViewModel();

            return View(viewModel);
        }
        public IActionResult Delete(int? id) 
        {
            if (id == null) 
            {
                return new EmptyResult();
            }

            Order order = StaticDb.Orders.FirstOrDefault(order => order.Id == id);

            if (order == null)
            {
                return new EmptyResult();
            }

            OrderDetailsViewModel viewModel = order.ToOrderDetailsViewModel();
            return View(viewModel);
        }
        public IActionResult ConfirmDelete(int? id) 
        {
            if (id == null)
            {
                return new EmptyResult();
            }

            Order order = StaticDb.Orders.FirstOrDefault(order => order.Id == id);

            if (order == null)
            {
                return new EmptyResult();
            }

            StaticDb.Orders.Remove(order);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateOrder() 
        {
            OrderViewModel viewModel = new OrderViewModel();

            ViewBag.Users = StaticDb.Users.Select(user 
                => user.MapToUserSelectViewModel()).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel viewModel) 
        {



            return RedirectToAction("Index");
        }


    }
}
