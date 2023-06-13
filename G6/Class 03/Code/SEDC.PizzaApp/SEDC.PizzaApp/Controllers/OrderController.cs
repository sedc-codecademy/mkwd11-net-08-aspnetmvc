using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.ViewModels;
using System.Xml.Linq;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult GetAllOrders()
        {
            //domain model, they represent our entities (tables)
            //we mainly use in the business logic, reading from db...
            List<Order> ordersDb = StaticDb.Orders;

            //in most cases we don't send domain models to the UI
            //they contain extra data, sensitive data, maybe we need to modify data
            //return View(ordersDb);

            //we send viewmodels to the views
            //FIRST WAY
            //List<OrderListViewModel> orderListViewModels = new List<OrderListViewModel>();
            //foreach (Order order in ordersDb)
            //{
            //    OrderListViewModel orderListViewModel = new OrderListViewModel
            //    {
            //        PizzaName = order.Pizza.Name,
            //        UserFullName = $"{order.User.FirstName} {order.User.LastName}"
            //    };
            //    orderListViewModels.Add(orderListViewModel);
            //}


            //SECOND WAY
            //List<OrderListViewModel> orderListViewModels = ordersDb.Select(x => new OrderListViewModel
            //{
            //    PizzaName = x.Pizza.Name,
            //    UserFullName = $"{x.User.FirstName} {x.User.LastName}"
            //}).ToList();

            //THIRD WAY
            List<OrderListViewModel> orderListViewModels = 
                ordersDb.Select(x => OrderMapper.OrderToOrderListViewModel(x)).ToList();

            return View(orderListViewModels);
        }

        //we want to get the details for an order with a given id
        //we want to show: user fullname, pizza name, price (price of pizaa + 50 for delivery), payment method

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                return RedirectToAction("Error", "Home");
            }

            //we need to send title that will be displayed in the header tag
            ViewData["Title"] = "Order details";
            ViewData["DateTime"] = DateTime.Now.ToShortDateString();

            //we need to map from domain model (entity from db) to view model
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(orderDb);

            //OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel
            //{
            //    PizzaName = orderDb.Pizza.Name,
            //    UserFullName = $"{orderDb.User.FirstName} {orderDb.User.LastName}",
            //    OrderPrice = orderDb.Pizza.Price + 50,
            //    PaymentMethod = orderDb.PaymentMethod.ToString()
            //};

            ViewBag.User = orderDb.User;

           // we want to send: user fullname, pizza name, price(price of pizaa + 50 for delivery), payment method
            return View(orderDetailsViewModel);
        }
    }
}
