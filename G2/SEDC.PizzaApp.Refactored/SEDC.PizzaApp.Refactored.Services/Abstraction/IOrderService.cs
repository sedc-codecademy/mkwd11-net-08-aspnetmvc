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
        void CreateOrder(OrderViewModel orderViewModel);
    }
}
