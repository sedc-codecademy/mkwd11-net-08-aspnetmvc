using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Models;
using System.Diagnostics;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            logger.LogDebug("Hello from controller");
            logger.LogTrace("Hello from controller");
            logger.LogInformation("Hello From controller");
            logger.LogWarning("Hello from controller");
            logger.LogError("Hello From controller");
            logger.LogCritical("Hello from controller");
        }

        public IActionResult Index()
        {
            this.HttpContext.Session.SetString("User", "1");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorDTO { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}