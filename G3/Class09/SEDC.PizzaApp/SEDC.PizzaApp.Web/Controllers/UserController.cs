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
            IEnumerable<UserDTO> users = userService.GetAll();
            return View(users);
        }

        public IActionResult Details(int id)
        {
            UserDTO user = userService.GetById(id);
            return View(user);
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

        [HttpPost]
        public IActionResult Delete(int id)
        {
            userService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            UpdateUserDTO user = userService.GetUpdateDtoById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Update(UpdateUserDTO userDTO)
        {
            var user = userService.Update(userDTO);
            return RedirectToAction("Details", new 
            { 
                Id = user.Id 
            });
        }

    }
}
