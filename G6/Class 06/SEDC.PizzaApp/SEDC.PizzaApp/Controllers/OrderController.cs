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

        public IActionResult DetailsExample(int? id)
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

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                //return the GeneralError view. First look in Order folder, then in Shared folder
                return View("GeneralError", new GeneralErrorViewModel
                {
                    ErrorMessage = "You must provide an id to view details!"
                });
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                return View("ResourceNotFound");
            }

            ViewData["Title"] = "Order details";

            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(orderDb);
            return View(orderDetailsViewModel);
        }

        public IActionResult Delete(int id)
        {
            if(id <= 0)
            {
                return View("GeneralError", new GeneralErrorViewModel
                {
                    ErrorMessage = "Id is invalid"
                });
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);    
            if( orderDb == null)
            {
                return View("ResourceNotFound");
            }

            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.OrderToOrderDetailsViewModel(orderDb);
            return View(orderDetailsViewModel);
        }

        public IActionResult ConfirmDelete(int id)
        {
            if (id <= 0)
            {
                return View("GeneralError", new GeneralErrorViewModel
                {
                    ErrorMessage = "Id is invalid"
                });
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            StaticDb.Orders.Remove(orderDb);
            return RedirectToAction("GetAllOrders");
        }

        //Create order
        //this is the method that reacts to GET request
        //returns the view with a form in which we will enter data for the new order
        [HttpGet]
        public IActionResult CreateOrder()
        {
            //we have an empty object, to send it to the view
            //so we can fill data in its properties via the form in the view
            OrderViewModel orderViewModel = new OrderViewModel();

            //we have to send all existing users, so that they are shown in dropdown
            //we are sending list of viewmodels
            ViewBag.Users = StaticDb.Users.Select(x => UserMapper.ToUserDropDownViewModel(x)).ToList();

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult CreateOrderPost(OrderViewModel orderViewModel)
        {
            //create new Order with data from the model

            //in order to create order and send to the database
            //we must check the negative scenarios

            //we must check if there is a user with the given UserId in the db
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderViewModel.UserId);
            if (userDb == null)
            {
                return View("ResourceNotFound");
            }

            //we must check if there is a pizza with the given name in the db
            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderViewModel.PizzaName);
            if (pizzaDb == null)
            {
                return View("ResourceNotFound");
            }

            Order newOrder = new Order
            {
                Id = ++StaticDb.OrderId,
                IsDelivered = orderViewModel.Delivered,
                PizzaId = pizzaDb.Id,
                Pizza = pizzaDb,
                UserId = orderViewModel.UserId,
                User = userDb,
                PaymentMethod = orderViewModel.PaymentMethod
            };
            StaticDb.Orders.Add(newOrder);

            return RedirectToAction("GetAllOrders");
        }

        //Edit order
        //this is the action that will the return view with form for editing order
        //this action will be called when we click on an Edit link in Orders table
        public IActionResult EditOrder(int id)
        {
            Order orderForEdit = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(orderForEdit == null)
            {
                return View("ResourceNotFound");
            }

            ViewBag.Users = StaticDb.Users.Select(x => UserMapper.ToUserDropDownViewModel(x)).ToList();

            //we need to send viewmodel, but filled with data for edit
            OrderViewModel orderViewModel = OrderMapper.OrderToOrderViewModel(orderForEdit);

            return View(orderViewModel);
        }

        //this action will be called when we click Save on the Edit form
        [HttpPost]
        public IActionResult EditOrderPost(OrderViewModel orderViewModel)
        {
            //1. we need to find the order for edit
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.OrderId);
            if(orderDb == null)
            {
                return View("ResourceNotFound");
            }

            //we must check if there is a user with the given UserId in the db
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderViewModel.UserId);
            if (userDb == null)
            {
                return View("ResourceNotFound");
            }

            //we must check if there is a pizza with the given name in the db
            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderViewModel.PizzaName);
            if (pizzaDb == null)
            {
                return View("ResourceNotFound");
            }

            //2. we need to edit the data and save it to db
            orderDb.PaymentMethod = orderViewModel.PaymentMethod;
            orderDb.IsDelivered = orderViewModel.Delivered;
            orderDb.PizzaId = pizzaDb.Id;
            orderDb.Pizza = pizzaDb;
            orderDb.UserId = orderViewModel.UserId;
            orderDb.User = userDb;

            return RedirectToAction("GetAllOrders");
        }
    }
}
