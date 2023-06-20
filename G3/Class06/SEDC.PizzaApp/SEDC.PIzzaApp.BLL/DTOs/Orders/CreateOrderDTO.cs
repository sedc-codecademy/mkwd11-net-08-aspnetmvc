
using SEDC.PizzaApp.Data.Enums;

namespace SEDC.PIzzaApp.BLL.DTOs.Orders
{
    public class CreateOrderDTO
    {
        public int UserId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
