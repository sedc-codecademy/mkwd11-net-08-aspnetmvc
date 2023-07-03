using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.BLL.DTOs.Pizzas;
using SEDC.PizzaApp.BLL.Services;
using SEDC.UserApp.BLL.Services;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService pizzaService;
        private readonly IUserService userService;
        private readonly ILogger<PizzaController> logger;

        public PizzaController(IPizzaService pizzaService,IUserService userService, ILogger<PizzaController> logger)
        {
            this.pizzaService = pizzaService;
            this.userService = userService;
            this.logger = logger;
        }
        public IActionResult Index()
        {
            var pizzas = pizzaService.GetAll();
            int? loggedInUserId = this.HttpContext.Session.GetInt32("User");
            if (loggedInUserId.HasValue)
            {
                ViewBag.User = userService.GetById(loggedInUserId.Value);
            }
            return View(pizzas);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("NotFoundView");
            }
            var pizzaDto = pizzaService.GetById(id.Value);

            return View(pizzaDto);
        }


        [HttpPost("order/{id}/pizza/create")]
        public IActionResult Create(CreatePizzaDTO createPizza)
        {
            var result = pizzaService.Create(createPizza);
            return RedirectToAction("Index");
        }

        [HttpGet("order/{id}/pizza/create")]
        public IActionResult Create(int id)
        {
            return View(new CreatePizzaDTO
            {
                OrderId = id
            });
        }



        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                PizzaDTO? pizza = pizzaService.GetById(id);
                return View(pizza);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Pizza update failed");
                return View(""); // TODO
            }

        }

        [HttpPost]
        public IActionResult Update(PizzaDTO model)
        {
            var result = pizzaService.Update(model);  
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            pizzaService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
