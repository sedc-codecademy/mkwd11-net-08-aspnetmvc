using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.BLL.DTOs.Users;
using SEDC.PizzaApp.Web.Mapper;
using SEDC.UserApp.BLL.Services;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Index()
        {
            List<Models.DTOs.UserDTO> users = PizzaAppDb
                .Users
                .Select(x => x.ToDTO())
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

            Models.DTOs.UserDTO DTO = user.ToDTO();
            return View(DTO);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserDTO model)
        {
            //try
            //{

            //}catch(ValidationException)
            //{

            //}
            //catch (NotFoundException)
            //{

            //}catch(Exception )
            var result = userService.Create(model);
            return RedirectToAction("Index");
        }
    }
}
