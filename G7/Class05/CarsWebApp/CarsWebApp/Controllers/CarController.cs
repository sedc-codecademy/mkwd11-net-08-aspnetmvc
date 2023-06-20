using CarsWebApp.Database;
using Microsoft.AspNetCore.Mvc;

namespace CarsWebApp.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var car = CarDb.Cars.FirstOrDefault(x => x.Id == id);
            return View(car);
        }
    }
}
