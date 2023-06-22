using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models.Domain;
using PizzaApp.Models.Mappers;
using PizzaApp.Models.ViewModels;

namespace PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersFromDb = StaticDb.Orders;

            //List<OrderDetailsViewModel> orderViewModelList = ordersFromDb.Select(x =>
            //new OrderDetailsViewModel
            //{
            //    PaymentMethod = x.PaymentMethod,
            //    PizzaName = x.Pizza.Name,
            //    Price = x.Pizza.Price + 50,
            //    UserFullName = $"{x.User.FirstName} {x.User.LastName}"
            //})
            //.ToList();

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

            List<OrderDetailsViewModel> orderViewModelList = ordersFromDb.Select(x => OrderMapper.ToOrderDetailsViewModel(x)).ToList();

            ViewData["Title"] = "These are the orders made with our app:";
            ViewData["NumberOfOrders"] = StaticDb.Orders.Count;
            return View(orderViewModelList);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new EmptyResult();

            }


            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return View("Error");
            }


            //OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel
            //{
            //    PaymentMethod = order.PaymentMethod,
            //    PizzaName = order.Pizza.Name,
            //    Price = order.Pizza.Price + 50,
            //    UserFullName = order.User.FirstName + ' ' + order.User.LastName
            //};

            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(order);

            // ViewBag.Title = string.Empty;
            ViewBag.Title = $"Details for order with id {id}";
            ViewBag.User = order.User;
            // return View(order); this is for the first example where we used models (domain)
            return View(orderDetailsViewModel);

        }

        //[HttpGet]
        public IActionResult CreateOrder()
        {

            OrderDialogViewModel orderDialogViewModel = new OrderDialogViewModel();

            ViewBag.Users = StaticDb.Users.Select(x => new UserOptionViewModel
            {
                Id = x.Id, //value for the option tag
                UserFullName = $"{x.FirstName} {x.LastName}" //text for the option tag

            });

            return View(orderDialogViewModel);
        }

        [HttpPost]
        public IActionResult CreateOrderPost(OrderDialogViewModel orderDialogViewModel)
        {
            //validation for user, we have to validate if the user id is an id of an existing user
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderDialogViewModel.UserId);

            if(userDb == null)
            {
                return View("ResourceNotFound");
            }

            //validation for pizza, we have to validate if the pizza name is a name of an existing pizza
            //if we want to match only part of the name, we can use contains ot StartsWith
            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderDialogViewModel.PizzaName); 
            if(pizzaDb == null)
            {
                return View("ResourceNotFound");
            }

            //mapping from view model to domain model
            Order newOrder = new Order
            {
                Id = StaticDb.Orders.Count + 1,
                IsDelivered = orderDialogViewModel.IsDelivered,
                PaymentMethod = orderDialogViewModel.PaymentMethod,
                Pizza = pizzaDb,
                PizzaId = pizzaDb.Id,
                User = userDb,
                UserId = userDb.Id //orderDialogViewModel.UserId
            };

            StaticDb.Orders.Add(newOrder);

            return RedirectToAction("Index");
        }

        public IActionResult EditOrder(int? id)
        {
            if(id == null)
            {
                return View("Error");
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);

            if(orderDb == null)
            {
                return View("ResourceNotFound");
            }

            ViewBag.Users = StaticDb.Users.Select(x => new UserOptionViewModel
            {
                Id = x.Id, //value for the option tag
                UserFullName = $"{x.FirstName} {x.LastName}" //text for the option tag

            });

            OrderDialogViewModel orderDialogViewModel = new OrderDialogViewModel
            {
                IsDelivered = orderDb.IsDelivered,
                PaymentMethod = orderDb.PaymentMethod,
                UserId = orderDb.User.Id, //orderDb.UserId
                PizzaName = orderDb.Pizza.Name,
                Id = orderDb.Id
            };

            return View(orderDialogViewModel);

        }

        [HttpPost]
        public IActionResult EditOrder(OrderDialogViewModel orderDialogViewModel)
        {
            //always check the negative scenarios
            //check if the data is valid

            if(orderDialogViewModel == null)
            {
                return View("Error");
            }

            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == orderDialogViewModel.Id);
            if(order == null)
            {
                return View("ResourceNotFound");
            }
            //validation for user, we have to validate if the user id is an id of an existing user
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderDialogViewModel.UserId);

            if (userDb == null)
            {
                return View("ResourceNotFound");
            }

            //validation for pizza, we have to validate if the pizza name is a name of an existing pizza
            //if we want to match only part of the name, we can use contains ot StartsWith
            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderDialogViewModel.PizzaName);
            if (pizzaDb == null)
            {
                return View("ResourceNotFound");
            }

            //Take the orders from db and for each property update its value
            order.Pizza = pizzaDb;
            order.PizzaId = pizzaDb.Id;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderDialogViewModel.Id).User = userDb;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderDialogViewModel.Id).UserId = userDb.Id; //orderDialogViewModel.UserId
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderDialogViewModel.Id).PaymentMethod = orderDialogViewModel.PaymentMethod;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderDialogViewModel.Id).IsDelivered = orderDialogViewModel.IsDelivered;

            return RedirectToAction("Index");
        }

        public IActionResult DeleteOrder(int? id)
        {
            if(id == null)
            {
                return View("Error");
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            int index = StaticDb.Orders.FindIndex(x => x.Id == id);
            if(index == -1)
            {
                return View("ResourceNotFound");
            }

            StaticDb.Orders.RemoveAt(index);
            //StaticDb.Order.Remove(orderDb);

            return RedirectToAction("Index");
        }
    }
}
