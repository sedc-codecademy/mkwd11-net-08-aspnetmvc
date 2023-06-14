using PizzaApp.Models.Enums;

namespace PizzaApp.Models.ViewModels.OrderViewModels
{
    public class OrderListViewModel
    {
        public int Id { get; set; }

        public string PizzaName { get; set; } = string.Empty;

        public string UserFullName { get; set; } = string.Empty;

        public int Price { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
