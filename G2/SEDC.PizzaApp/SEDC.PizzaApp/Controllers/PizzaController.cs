using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult GetPizzas() 
        {
            var pizzas = StaticDb.Pizzas;
            return View(pizzas);
        }

        public IActionResult Details(int? id) 
        {
            if (id == null) 
            {
                return RedirectToAction("Error");
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(pizza => pizza.Id == id);

            if (pizza == null) 
            {
                return RedirectToAction("Error");
            }

            return View(pizza);
        }

        public IActionResult Error() 
        {
            return View();
        }
    }
}
