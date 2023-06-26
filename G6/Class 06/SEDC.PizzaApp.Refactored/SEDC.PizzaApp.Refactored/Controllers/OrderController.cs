using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Refactored.Services.Interfaces;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class OrderController : Controller
    {
        //Controller (presentation layer) needs business layer
        private IOrderService _orderService;

        //show all orders
        public IActionResult Index()
        {
            //background logic:
            //1. take all orders from db
            //2. decide which data will be sent to the client
            //3. create viewmodel, map
            //4. send list of viewmodels to the view and return view to the client

            //PRESENTATION LAYER DOES NOT COMMUNICATE DIRECTLY WITH DB!
            //PRESENTATION LAYER COMMUNICATES WITH BUSINESS LAYER (SERVICES)

            //call a service to get the orders
            //controller methods should be as simple as possible
            //they should get ready data


            //TODO
            _orderService.GetAllOrders();

            return View();
        }
    }
}
