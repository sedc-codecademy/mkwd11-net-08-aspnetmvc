using SEDC.PizzaApp.Refactored.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Services.Abstraction
{
    public interface IOrderService
    {
        List<OrderListViewModel> GetAllOrders();
        OrderDetailsViewModel GetOrderDetails(int id);
        void CreateOrder(OrderViewModel orderViewModel);
        OrderViewModel GetOrderForEditing(int id);
        void EditOrder(OrderViewModel orderViewModel);
        void DeleteOrder(int id);
    }
}
