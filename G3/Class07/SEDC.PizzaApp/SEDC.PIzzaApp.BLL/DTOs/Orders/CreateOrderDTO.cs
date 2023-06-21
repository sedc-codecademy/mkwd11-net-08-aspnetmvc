
using SEDC.PizzaApp.Data.Enums;

namespace SEDC.PizzaApp.BLL.DTOs.Orders
{
    public class CreateOrderDTO
    {
        public int UserId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
