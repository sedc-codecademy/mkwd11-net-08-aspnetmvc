using SEDC.PizzaApp.Web.Models.Enums;

namespace SEDC.PizzaApp.Web.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }

        public string By { get; set; } = string.Empty;

        public PaymentMethod PaymentMethod { get; set; }

        public IEnumerable<PizzaViewModel> Pizzas { get; set; } = new List<PizzaViewModel>();
    }
}
