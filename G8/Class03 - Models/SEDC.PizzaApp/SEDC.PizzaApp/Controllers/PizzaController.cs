using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult GetPizzas()
        {
            List<Pizza> dbPizzas = StaticDb.Pizzas;
            return View(dbPizzas);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Error");
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if(pizza == null)
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
