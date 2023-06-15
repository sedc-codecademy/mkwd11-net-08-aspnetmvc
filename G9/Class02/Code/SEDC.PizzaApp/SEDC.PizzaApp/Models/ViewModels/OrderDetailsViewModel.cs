using SEDC.PizzaApp.Models.enums;

namespace SEDC.PizzaApp.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public PaymentMetod PaymentMetod { get; set; }
        public string PizzaName { get; set; }
        public string FullName { get; set; }
    }
}
