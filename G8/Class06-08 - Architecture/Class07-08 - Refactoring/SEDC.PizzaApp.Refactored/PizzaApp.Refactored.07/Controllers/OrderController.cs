using Microsoft.AspNetCore.Mvc;
using PizzaApp.Refactored._07.Services;
using PizzaApp.Refactored._07.Shared;
using PizzaApp.Refactored._07.ViewModels;

namespace PizzaApp.Refactored._07.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IUserService _userService;
        private IPizzaService _pizzaService;
        public OrderController(IOrderService orderService, IUserService userService, IPizzaService pizzaService) //DependencyInjectionHelper -> map
        {
            _orderService = orderService;
            _userService = userService;
            _pizzaService = pizzaService;
        }
        public IActionResult Index()
        {
            List<OrderListViewModel> orderListViewModels = _orderService.GetAllOrders();
            return View(orderListViewModels);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return View("BadRequest");
            }
            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id.Value);
                return View(orderDetailsViewModel);
            }
            catch(Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");

            }
        }

        public IActionResult Create()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            ViewBag.Users = _userService.GetUsersForDropdown();
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.CreateOrder(orderViewModel);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");
            }
        }

        public IActionResult AddPizza(int id)
        {
            PizzaOrderViewModel pizzaOrderViewModel = new PizzaOrderViewModel();
            pizzaOrderViewModel.OrderId = id;
            ViewBag.Pizzas = _pizzaService.GetPizzasForDropdown();
            return View(pizzaOrderViewModel);
        }

        [HttpPost]
        public IActionResult AddPizza(PizzaOrderViewModel pizzaOrderViewModel)
        {
            try
            {
                _orderService.AddPizzaToOrder(pizzaOrderViewModel);
                return RedirectToAction("Details", new { id = pizzaOrderViewModel.OrderId });
            }
            catch(Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");
            }
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return View("BadRequest");
            }
            try
            {
                OrderViewModel model = _orderService.GetOrderForEditing(id.Value);
                ViewBag.Users = _userService.GetUsersForDropdown();
                return View(model);
            }
            catch(ResourceNotFoundException e)
            {
                // We can add loggs here
                return View("ResourceNotFound");
            }
            catch(Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");
            }

        }

        [HttpPost]
        public IActionResult Edit(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.EditOrder(orderViewModel);
                return RedirectToAction("Index");
            }
            catch (ResourceNotFoundException e)
            {
                // We can add loggs here
                return View("ResourceNotFound");
            }
            catch (Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }
            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id.Value);
                return View(orderDetailsViewModel);
            }
            catch(Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");
            }
        }

        [HttpPost]
        public IActionResult Delete(OrderDetailsViewModel orderDetailsViewModel)
        {
            try
            {
                _orderService.DeleteOrder(orderDetailsViewModel.Id);
                return RedirectToAction("Index");
            }
            catch (ResourceNotFoundException e)
            {
                // We can add loggs here
                return View("ResourceNotFound");
            }
            catch (Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");
            }
        }
    }
}
