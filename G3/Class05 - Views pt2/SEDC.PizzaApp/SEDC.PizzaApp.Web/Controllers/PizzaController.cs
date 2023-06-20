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


        [HttpPost("order/{id}/pizza/create")]
        public IActionResult Create(CreatePizzaViewModel model)
        {
            var order = PizzaAppDb.Orders.FirstOrDefault(x => x.Id == model.OrderId);

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

        [HttpGet("order/{id}/pizza/create")]
        public IActionResult Create(int id)
        {
            return View(new CreatePizzaViewModel
            {
                OrderId = id
            });
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return View("NotFoundView");
            }

            var pizza = PizzaAppDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if(pizza == null)
            {
                return View("NotFoundView");
            }

            return View(pizza.ToViewModel());
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if(id == null)
            {
                return View("NotFoundView");
            }

            var pizza = PizzaAppDb.Pizzas.FirstOrDefault(x => x.Id == id);

            if(pizza == null)
            {
                return View("NotFoundView");
            }

            return View(pizza.ToViewModel());
        }

        [HttpPost]
        public IActionResult Update(PizzaViewModel model)
        {
            var pizza = PizzaAppDb.Pizzas.FirstOrDefault(x => x.Id == model.Id);
            if(pizza == null)
            {
                return View("NotFoundException");
            }

            //if(pizza.Order.User.Id == 1)
            //{
            //    return View("")
            //}

            pizza.Name = model.Name;
            pizza.IsOnPromotion = model.IsOnPromotion;
            pizza.Price = model.Price;

            return View(pizza.ToViewModel());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaAppDb.Pizzas.FirstOrDefault(x => x.Id == id);

            if(pizza == null)
            {
                return View("NotFoundView");
            }

            PizzaAppDb.Pizzas.Remove(pizza);

            return RedirectToAction("Index");
        }
     
    }
}
