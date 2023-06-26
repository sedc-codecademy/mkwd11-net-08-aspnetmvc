using CarsWebApp.Database;
using CarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarsWebApp.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View(CarDb.Cars);
        }

        public IActionResult Details(int id)
        {
            var car = CarDb.Cars.FirstOrDefault(x => x.Id == id);
            return View(car);
        }

        public IActionResult Create()
        {
            var car = new Car();
            return View(car);
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            //Validations
            car.Id = CarDb.Cars.Count + 1;
            CarDb.Cars.Add(car);

            return RedirectToAction("Index");
        }
    }
}
