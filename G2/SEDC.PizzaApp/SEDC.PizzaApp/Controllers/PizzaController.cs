using Microsoft.AspNetCore.Mvc;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult GetPizzas() 
        {
            var pizzas = StaticDb.Pizzas;
            return View(pizzas);
        }
    }
}
