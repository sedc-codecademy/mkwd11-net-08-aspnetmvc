//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using SEDC.PizzaApp.Web.Data;
//using SEDC.PizzaApp.Web.Mapper;

//namespace SEDC.PizzaApp.Web.Controllers.Api
//{
//    [Route("api/v1/[controller]")]
//    [ApiController]
//    public class PizzaController : ControllerBase
//    {
//        [HttpDelete("{id}")]//api/v1/pizza/1
//        public IActionResult Delete(int id)
//        {
//            var pizza = PizzaAppDb.Pizzas.FirstOrDefault(x => x.Id == id);

//            if (pizza == null)
//            {
//                return NotFound(); // 404
//            }
//            PizzaAppDb.Pizzas.Remove(pizza);

//            return Ok(pizza.ToDTO()); // 200
//        }
//    }
//}
