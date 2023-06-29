using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Refactored.Services.Implementations;
using SEDC.PizzaApp.Refactored.Services.Interfaces;
using SEDC.PizzaApp.Refactored.ViewModels.Error;
using SEDC.PizzaApp.Refactored.ViewModels.Orders;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class OrderController : Controller
    {
        //Controller (presentation layer) needs business layer
        private IOrderService _orderService;
        private IUserService _userService;

        public OrderController()
        {
            _orderService = new OrderService();
            _userService = new UserService();
        }

        //show all orders
        public IActionResult Index()
        {
            //background logic:
            //1. take all orders from db
            //2. decide which data will be sent to the client
            //3. create viewmodel, map
            //4. send list of viewmodels to the view and return view to the client

            //PRESENTATION LAYER DOES NOT COMMUNICATE DIRECTLY WITH DB!
            //PRESENTATION LAYER COMMUNICATES WITH BUSINESS LAYER (SERVICES)

            //call a service to get the orders
            //controller methods should be as simple as possible
            //they should get ready data


           List<OrderListViewModel> orders = _orderService.GetAllOrders();

            return View(orders);
        }


        public IActionResult Details(int id)
        {
            if(id <= 0)
            {
                return View("GeneralError", new GeneralErrorViewModel { Message = "Invalid id value!" });
            }

            try
            {
                //call logic
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id);
                //return response
                return View(orderDetailsViewModel);
            }
            catch(Exception ex)
            {
                //TODO catch custom exception
                return View("GeneralError", new GeneralErrorViewModel { Message = ex.Message });
            }

        }

        //GET
        //this is the first step of Create, get a view with form in it
        public IActionResult CreateOrder()
        {
            CreateOrderViewModel createOrderViewModel = new CreateOrderViewModel();

            //get all users from db, mapped as dropdown viewmodels
            ViewBag.Users = _userService.GetUserForDropdown();

            return View(createOrderViewModel);
        }
    }
}
