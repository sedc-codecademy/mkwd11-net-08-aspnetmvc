using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Services;
using SEDC.PizzaApp.Services.Abstraction;
using SEDC.PizzaApp.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class SizeController : Controller
    {
        private readonly ISizeService _sizeService;
        private readonly ISmsService _smsService;

        public SizeController(ISizeService sizeService, ISmsService smsService)
        {
            _sizeService = sizeService;
            _smsService = smsService;
        }

        public IActionResult Index()
        {
            //1. Get data from UI (if needed)
            //2. Call method from service
            //3. Return result to UI

            //ISmsService smsService = new A1SmsService();
            //ISizeService sizeService = new SizeService();
            var textMessage = _smsService.Send("070111111", "Listing all apps");

            var sizes = _sizeService.GetAll();

            //Just for testing accessing the MenuItem to grab everthing linked with them

            return View(sizes);
        }

        public IActionResult Filtered(string id)
        {
            var sizes = _sizeService.FilteredSizes(id);

            return View(sizes);
        }

        public IActionResult Details(int id)
        {
            //ISmsService smsService = new A1SmsService();
            //ISizeService sizeService = new SizeService();
            _smsService.Send("070111111", "Details opened");

            var result = _sizeService.GetById(id);
            return View(result);
        }

        public IActionResult CreateEditSize(int? id)
        {
            //ISizeService sizeService = new SizeService();

            var model = !id.HasValue ? new SizeViewModel() : _sizeService.GetById(id.Value);

            return View(model);
        }

        [HttpPost]
        public IActionResult Save(SizeViewModel model)
        {
            try
            {
                //ISmsService smsService = new TMobileSmsService();
                //ISizeService sizeService = new SizeService();

                _smsService.Send("070111111", "Size created or edit");
                //This is MVC Validation with the help of Data Anotations in the corresponding model
                //This handles if the validation does not passess
                if (!ModelState.IsValid)
                {
                    //This handles the case when the validation check does not pass
                    return View("CreateEditSize", model);
                }

                _sizeService.Save(model);

                return RedirectToAction("Index");
            }
            catch (ArgumentException ex)
            {
                //Log error
                ModelState.AddModelError("Name", ex.Message);
                return View("CreateEditSize", model);
            }
            catch(Exception ex)
            {
                //Log error
                return View("ApplicationError", ex.Message);
            }
        }

        public IActionResult Remove(int id)
        {
            //ISmsService smsService = new A1SmsService();
            //ISizeService sizeService = new SizeService();

            _smsService.Send("070111111", "Size removed");
            _sizeService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
