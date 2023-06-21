using SEDC.PizzaApp.Web.Models.Enums;

namespace SEDC.PizzaApp.Web.Models.ViewModels
{
    public class CreateOrderViewModel
    {
        public int UserId { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
