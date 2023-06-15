using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Data;
using SEDC.PizzaApp.Web.Mapper;
using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            //var pizzas = PizzaAppDb.Pizzas.Select(x => new PizzaViewModel
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Price = x.Price,
            //    IsOnPromotion = x.IsOnPromotion

            //});
            ViewBag.User = PizzaAppDb.Users.First().ToViewModel();
            ViewData["User"] = PizzaAppDb.Users.First().ToViewModel();

            List<PizzaViewModel> viewModels = PizzaAppDb.Pizzas.Select(x => x.ToViewModel()).ToList();
            
            return View(viewModels);

            // return View(new PizzaOverviewModel) se sho ni treba vo eden model
        }

        [HttpGet("order/{id}/pizza/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("order/{id}/pizza/create")]
        public IActionResult Create(int id, CreatePizzaViewModel model)
        {
            var order = PizzaAppDb.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                return View("NotFoundView");
            }

            var pizza = new Pizza(order, model.Name, model.Price)
            {
                Id = PizzaAppDb.Pizzas.Max(x => x.Id) + 1,
                IsOnPromotion = model.IsOnPromotion
            };
            order.Pizzas.Add(pizza);

            PizzaAppDb.Pizzas.Add(pizza);
            return RedirectToAction("Index");
        }
    }
}
