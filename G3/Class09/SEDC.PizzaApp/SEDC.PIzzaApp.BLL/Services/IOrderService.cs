using SEDC.PizzaApp.BLL.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.BLL.Services
{
    public interface IOrderService
    {
        public IEnumerable<OrderDTO> GetAll();

        public OrderDetailsDTO GetById(int id);

        public OrderDTO Update(OrderDTO orderDTO);

        public OrderDTO Create(CreateOrderDTO create);

        public void Delete(int id);
    }
}
