using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<Pizza> Pizzas = StaticDb.Pizzas;
            return View(Pizzas);
        }
    }
}
