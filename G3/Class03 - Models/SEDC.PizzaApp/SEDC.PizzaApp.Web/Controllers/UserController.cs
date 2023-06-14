using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Data;
using SEDC.PizzaApp.Web.Mapper;
using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            List<Models.ViewModels.UserViewModel> users = PizzaAppDb
                .Users
                .Select(x => x.ToViewModel())
                .ToList();

            return View(users);
        }

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return View("NotFoundView");
            }

            User? user = PizzaAppDb.Users.FirstOrDefault(x => x.Id == id.Value);

            if (user == null)
            {
                return View("NotFoundView");
            }

            Models.ViewModels.UserViewModel viewModel = user.ToViewModel();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (string.IsNullOrEmpty(model.FirstName))
            {
                ViewBag.Error = "First name can not be empty";
                return View();
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                ViewBag.Error = "Last name can not be empty";
                return View();
            }
            if (string.IsNullOrEmpty(model.Phone))
            {
                ViewBag.Error = "Phone can not be empty";
                return View();
            }
            var user = new User(model.FirstName, model.LastName, model.Phone)
            {
                Id = PizzaAppDb.Users.Max(x => x.Id) + 1
            };
            PizzaAppDb.Users.Add(user);

            return RedirectToAction("Index");
        }
    }
}
