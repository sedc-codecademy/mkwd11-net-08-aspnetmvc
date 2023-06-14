using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models.Domain;
using PizzaApp.Models.Mappers;
using PizzaApp.Models.ViewModels.PizzaViewModels;

namespace PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<Pizza> pizzas = StaticDb.Pizzas;
            List<PizzaListViewModel> pizzaList = pizzas.Select(x => x.MapFromPizzaToPizzaListViewModel()).ToList();
            return View(pizzaList);
        }

        public IActionResult Details(int? indentifier)
        {
            if (indentifier == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Id == indentifier);

            if (pizzaDb == null)
            {
                return RedirectToAction("Error", "Home");
            }

            PizzaDetailsViewModel pizzaDetails = pizzaDb.MapFromPizzaToPizzaDetailsViewModel();

            return View(pizzaDetails);
        }
    }
}
