using Microsoft.AspNetCore.Mvc;
using PizzaAppRefactored.Services.Interfaces;
using PizzaAppRefactored.ViewModels.OrderViewModels;

namespace PizzaAppRefactored.Controllers
{
    public class OrderController : Controller
    {
        public IOrderService _orderService;
        public IUserService _userService;
        public IPizzaService _pizzaService;

        //The constructor is called per each request
        public OrderController(IOrderService orderService, IUserService userService, IPizzaService pizzaService)
        {
            _orderService = orderService;
            _userService = userService;
            _pizzaService = pizzaService;
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

        public IActionResult AddPizza(int id)
        {
            ViewBag.Pizzas = _pizzaService.GetPizzasForDropdown();

            AddPizzaToOrderViewModel addPizzaToOrderViewModel = new AddPizzaToOrderViewModel();
            addPizzaToOrderViewModel.OrderId = id;

            return View(addPizzaToOrderViewModel);

        }

        [HttpPost]
        public IActionResult AddPizzaPost(AddPizzaToOrderViewModel addPizzaToOrderViewModel)
        {
            try
            {
                _orderService.AddPizzaToOrder(addPizzaToOrderViewModel);
                return RedirectToAction("Details", new { id= addPizzaToOrderViewModel.OrderId});

            }catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GeneralError");
            }
        }

        public IActionResult DeleteOrder(int? id)
        {
            //validations
            if(id == null)
            {
                return View("BadRequest");
            }

            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderById(id.Value);
                return View(orderDetailsViewModel);

            }catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GeneralError");
            }

        }

        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                _orderService.DeleteOrder(id.Value);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GeneralError");
            }

        }
    }
}
