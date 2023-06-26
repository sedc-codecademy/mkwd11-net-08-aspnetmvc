using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEDC.PizzaApp.BLL.DTOs.Orders;
using SEDC.PizzaApp.BLL.Services;
using SEDC.PizzaApp.Data.Enums;
using SEDC.UserApp.BLL.Services;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IUserService userService;
        private readonly ILogger<OrderController> logger;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService, IUserService userService)
        {
            this.logger = logger;
            this.orderService = orderService;
            this.userService = userService;
        }
        public IActionResult Index()
        {
            var DTOs = orderService.GetAll();
            return View(DTOs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Users = userService.GetAll();
            //ViewBag.PaymentList = Enum.GetValues(typeof(PaymentMethod))
            //    .OfType<PaymentMethod>()
            //    .ToList();
            ViewBag.PaymentList = new List<PaymentMethod>
            {
                PaymentMethod.Card,
                PaymentMethod.Cash
            }.Select(x => new SelectListItem(x.ToString(), x.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateOrderDTO model)
        {
            try
            {
                var orderDTO = orderService.Create(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return View("NotFoundView");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("ViewNotFound");
            }
            try
            {
                var order = orderService.GetById(id.Value);
                return View(order);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return View("NotFoundView");
            }
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return View("ViewNotFound");
            }
            try
            {
                var order = orderService.GetById(id.Value);
                return View(order);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return View("NotFoundView");
            }
        }

        [HttpPost]
        public IActionResult Update(OrderDTO model)
        {

            try
            {
                var order = orderService.Update(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return View("NotFoundView");
            }
        }
    }
}
