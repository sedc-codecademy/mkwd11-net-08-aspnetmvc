using PizzaApp.Refactored._09.ViewModels;

namespace PizzaApp.Refactored._09.Services
{
    public interface IOrderService
    {
        List<OrderListViewModel> GetAllOrders();
        OrderDetailsViewModel GetOrderDetails(int id);
        void CreateOrder(OrderViewModel orderViewModel);
        void AddPizzaToOrder(PizzaOrderViewModel pizzaOrderViewModel);
        OrderViewModel GetOrderForEditing(int id);
        void EditOrder(OrderViewModel orderViewModel);
        void DeleteOrder(int id);
    }
}
