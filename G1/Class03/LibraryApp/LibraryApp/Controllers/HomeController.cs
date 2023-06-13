using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //localhost:1111/Home/Index
        public IActionResult Index()
        {
            return View();
        }

        //localhost:1111/Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        //localhost:1111/Home/Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Title = "SEDC ERROR EXAMPLE" });
        }
    }
}