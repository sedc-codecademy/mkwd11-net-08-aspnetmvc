using SEDC.PizzaApp.Refactored.ViewModels.Orders;

namespace SEDC.PizzaApp.Refactored.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderListViewModel> GetAllOrders();
        OrderDetailsViewModel GetOrderDetails(int id);

        void CreateOrder(CreateOrderViewModel model);

        void AddPizzaToOrder(AddPizzaViewModel model);
    }
}
