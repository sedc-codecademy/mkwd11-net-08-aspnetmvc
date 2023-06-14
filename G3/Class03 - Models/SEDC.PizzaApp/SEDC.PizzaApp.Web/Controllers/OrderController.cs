using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Data;
using SEDC.PizzaApp.Web.Mapper;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            var viewModels = PizzaAppDb.Orders.Select(x => x.ToViewModel());
            return View(viewModels);
        }
    }
}
