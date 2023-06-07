using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebApp.Controllers
{
    public class AcademyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Students()
        {
            return View();
        }
    }
}
