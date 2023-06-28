using Microsoft.AspNetCore.Mvc;
using PizzaApp.Services.Interfaces;
using PizzaApp.ViewModels.PizzaViewModels;

namespace PizzaApp.App.Controllers
{
    public class PizzaController : Controller
    {
        //1. Create a query in the DataAccess/Repositories
        //2. Create Mappers and ViewModels if needed
        //3. Use all of them in a service class, in a service method.
        //4. Use the service method here, in the controller, in an action
        //5. Create a view for that action

        private IPizzaService _pizzaService;

        public PizzaController(IPizzaService _pizzaService)
        {
            this._pizzaService = _pizzaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _pizzaService.GetPizzasForCards());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _pizzaService.GetPizzaDetails(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pizzaService.DeletePizzaById(id));
        }

        public IActionResult Create()
        {
            PizzaViewModel pizzaViewModel = new PizzaViewModel();

            return View(pizzaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PizzaViewModel pizzaViewModel)
        {
            await _pizzaService.CreatePizza(pizzaViewModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            PizzaViewModel pizzaViewModel = await _pizzaService.GetPizzaForEditing(id);

            return View(pizzaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PizzaViewModel pizzaViewModel)
        {
            await _pizzaService.EditPizza(pizzaViewModel);

            return RedirectToAction("Index");
        }
    }
}
