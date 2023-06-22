using PizzaApp.Refactored._06.ViewModels;

namespace PizzaApp.Refactored._06.Services
{
    public interface IOrderService
    {
        List<OrderListViewModel> GetAllOrders();
    }
}
