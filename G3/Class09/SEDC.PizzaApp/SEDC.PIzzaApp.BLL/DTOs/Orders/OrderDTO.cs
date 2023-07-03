
using SEDC.PizzaApp.Data.Enums;

namespace SEDC.PizzaApp.BLL.DTOs.Orders
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public int UserId { get; set; }

        public int PizzaCount { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
