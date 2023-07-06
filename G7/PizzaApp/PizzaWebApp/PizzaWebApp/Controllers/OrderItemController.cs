using Business.Abstraction;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace PizzaWebApp.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IMenuService menuService, IOrderItemService orderItemService)
        {
            _menuService = menuService;
            _orderItemService = orderItemService;
        }

        public IActionResult CreateOrderItem(int id)
        {
            ViewBag.MenuItems = _menuService.GetMenuItemsSelectList();

            var orderItem = new OrderItemViewModel()
            {
                OrderId = id
            };

            return View(orderItem);
        }

        [HttpPost]
        public IActionResult Save(OrderItemViewModel model)
        {
            _orderItemService.Save(model);

            return RedirectToAction("Details", "Order", new { id = model.OrderId });
        }

        public IActionResult Delete(int id)
        {
            var orderId = _orderItemService.Delete(id);

            return RedirectToAction("Details", "Order", new { id = orderId });
        }
    }
}
