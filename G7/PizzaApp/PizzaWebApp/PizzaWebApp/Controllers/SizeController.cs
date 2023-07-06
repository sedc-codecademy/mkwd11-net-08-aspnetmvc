using Business.Abstraction;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace PizzaWebApp.Controllers
{
    public class SizeController : Controller
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        public IActionResult Index()
        {            
            return View(_sizeService.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(_sizeService.GetById(id));
        }

        public IActionResult CreateEditSize(int? id)
        {
            var model = id.HasValue ? _sizeService.GetById(id.Value) : new SizeViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Save(SizeViewModel model)
        {
            _sizeService.Save(model);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _sizeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
