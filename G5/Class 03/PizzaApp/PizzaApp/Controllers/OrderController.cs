using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models.Domain;
using PizzaApp.Models.ViewModels;

namespace PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersFromDb = StaticDb.Orders;

            List<OrderDetailsViewModel> orderViewModelList = ordersFromDb.Select(x => new OrderDetailsViewModel
            {
                PaymentMethod = x.PaymentMethod,
                PizzaName = x.Pizza.Name,
                Price = x.Pizza.Price + 50,
                UserFullName = $"{x.User.FirstName} {x.User.LastName}"
            })
            .ToList();

            //this is the same thing as above
            //List<OrderDetailsViewModel> odvm = new List<OrderDetailsViewModel>();

            //foreach(Order order in ordersFromDb)
            //{
            //    OrderDetailsViewModel viewModel = new OrderDetailsViewModel
            //    {
            //        PaymentMethod = order.PaymentMethod,
            //        PizzaName = order.Pizza.Name,
            //        UserFullName = order.User.FirstName + ' ' + order.User.LastName,
            //        Price = order.Pizza.Price + 50
            //    };

            //    odvm.Add(viewModel);
            //}

            //return View(ordersFromDb); //this is user for the first example

            return View(orderViewModelList);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new EmptyResult();

            }


            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(order == null)
            {
                return new EmptyResult();
            }


            OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel
            {
                PaymentMethod = order.PaymentMethod,
                PizzaName = order.Pizza.Name,
                Price = order.Pizza.Price + 50,
                UserFullName = order.User.FirstName + ' ' + order.User.LastName
            };


            // return View(order); this is for the first example where we used models (domain)
            return View(orderDetailsViewModel);

        }
    }
}
