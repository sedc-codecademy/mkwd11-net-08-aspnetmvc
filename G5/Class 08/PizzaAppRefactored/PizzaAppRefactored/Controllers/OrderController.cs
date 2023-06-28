using Microsoft.AspNetCore.Mvc;
using PizzaAppRefactored.Services.Interfaces;
using PizzaAppRefactored.ViewModels.OrderViewModels;

namespace PizzaAppRefactored.Controllers
{
    public class OrderController : Controller
    {
        public IOrderService _orderService;
        public IUserService _userService;

        //The constructor is called per each request
        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            List<OrderDetailsViewModel> viewModels = _orderService.GetAllOrders();

            return View(viewModels);
        }

        //Order/Details/1
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return View("BadRequest");
            }

            try
            {                                                 //to get the value from the id, because here id is nullable
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderById(id.Value); 
                return View(orderDetailsViewModel); 
            }
            catch (Exception ex) {
                ViewBag.ErrorMessage = ex.Message;
                return View("GeneralError");
            }
        }

        public IActionResult CreateOrder()
        {
            OrderDialogViewModel orderDialogViewModel = new OrderDialogViewModel();
            ViewBag.Users = _userService.GetAllUsersForDropDown();

            return View(orderDialogViewModel);
        }

        [HttpPost]
        public IActionResult CreateOrderPost(OrderDialogViewModel orderDialogViewModel)
        {
            try
            {
                _orderService.CreateOrder(orderDialogViewModel);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GeneralError");
            }
        }
    }
}
