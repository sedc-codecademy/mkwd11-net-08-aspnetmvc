using SEDC.PizzaApp.Web.Models.Enums;

namespace SEDC.PizzaApp.Web.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public int UserId { get; set; }

        public int PizzaCount { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
