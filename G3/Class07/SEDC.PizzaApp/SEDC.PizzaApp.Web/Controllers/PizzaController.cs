using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.BLL.DTOs.Pizzas;
using SEDC.PizzaApp.BLL.Services;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService pizzaService;
        private readonly ILogger<PizzaController> logger;

        public PizzaController(IPizzaService pizzaService, ILogger<PizzaController> logger)
        {
            this.pizzaService = pizzaService;
            this.logger = logger;
        }
        public IActionResult Index()
        {
            var pizzas = pizzaService.GetAll();
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
