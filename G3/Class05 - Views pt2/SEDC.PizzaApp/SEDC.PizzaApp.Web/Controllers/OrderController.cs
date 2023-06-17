using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEDC.PizzaApp.Web.Data;
using SEDC.PizzaApp.Web.Mapper;
using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.Enums;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            var viewModels = PizzaAppDb.Orders.Select(x => x.ToViewModel());
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Users = PizzaAppDb.Users.Select(x => x.ToViewModel());
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
        public IActionResult Create(CreateOrderViewModel model)
        {
            var user = PizzaAppDb.Users.FirstOrDefault(x => x.Id == model.UserId);

            if(user == null)
            {
                return View("NotFoundView");
            }
            var order = new Order(user, model.PaymentMethod)
            {
                Id = PizzaAppDb.Orders.Max(x => x.Id) + 1
            };
            user.Orders.Add(order);


            PizzaAppDb.Orders.Add(order);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return View("ViewNotFound");
            }
            var order = PizzaAppDb.Orders.FirstOrDefault(x => x.Id == id);

            if(order == null)
            {
                return View("ViewNotFound");
            }

            return View(order.ToDetailsViewModel());
        }
    }
}
