using Microsoft.AspNetCore.Mvc;
using PizzaApp.Services.Interfaces;

namespace PizzaApp.App.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaService _pizzaService;

        public PizzaController(IPizzaService _pizzaService)
        {
            this._pizzaService = _pizzaService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _pizzaService.GetPizzasForCards());
        }
    }
}
