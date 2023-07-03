using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Models;
using SEDC.UserApp.BLL.Services;
using System.Diagnostics;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
            logger.LogDebug("Hello from controller");
            logger.LogTrace("Hello from controller");
            logger.LogInformation("Hello From controller");
            logger.LogWarning("Hello from controller");
            logger.LogError("Hello From controller");
            logger.LogCritical("Hello from controller");
        }

        public IActionResult Index()
        {
            IEnumerable<BLL.DTOs.Users.UserDTO>? users = userService.GetAll();
            return View(users);
        }
        public IActionResult Login(int id)
        {
            this.HttpContext.Session.SetInt32("User", id);
            return RedirectToAction("Index", "Pizza");
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