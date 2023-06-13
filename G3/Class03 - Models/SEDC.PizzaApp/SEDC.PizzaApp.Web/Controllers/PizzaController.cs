using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Data;
using SEDC.PizzaApp.Web.Mapper;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            //var pizzas = PizzaAppDb.Pizzas.Select(x => new PizzaViewModel
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Price = x.Price,
            //    IsOnPromotion = x.IsOnPromotion

            //});
            List<PizzaViewModel> viewModels = PizzaAppDb.Pizzas.Select(x => x.ToViewModel()).ToList();
            return View(viewModels);
        }
    }
}
