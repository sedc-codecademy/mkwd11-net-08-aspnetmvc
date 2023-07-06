using Business.Abstraction;
using Business.Implementation;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace PizzaWebApp.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            var pizzas = _pizzaService.GetAll();
            return View(pizzas);
        }

        public IActionResult Details(int id)
        {
            return View(_pizzaService.GetById(id));
        }

        public IActionResult CreateEditPizza(int? id)
        {
            var model = id.HasValue ? _pizzaService.GetById(id.Value) : new PizzaViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Save(PizzaViewModel model)
        {
            _pizzaService.Save(model);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _pizzaService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
