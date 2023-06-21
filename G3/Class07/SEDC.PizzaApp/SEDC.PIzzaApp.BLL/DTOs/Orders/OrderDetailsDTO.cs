using SEDC.PizzaApp.Data.Enums;
using SEDC.PizzaApp.BLL.DTOs.Pizzas;

namespace SEDC.PizzaApp.BLL.DTOs.Orders
{
    public class OrderDetailsDTO
    {
        public int OrderId { get; set; }

        public string By { get; set; } = string.Empty;

        public PaymentMethod PaymentMethod { get; set; }

        public IEnumerable<PizzaDTO> Pizzas { get; set; } = new List<PizzaDTO>();
    }
}
