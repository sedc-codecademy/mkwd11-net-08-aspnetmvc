using PizzaApp.Refactored._07.Domain;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Refactored._07.ViewModels
{
    public class OrderDetailsViewModel
    {
        [Display(Name = "Payment Method")]
        public PaymentMethodEnum PaymentMethod { get; set; }
        [Display(Name = "Is Delivered")]
        public bool Delivered { get; set; }
        [Display(Name = "Order Location")]
        public string Location { get; set; }
        [Display(Name = "User")]
        public string UserFullName { get; set; }
        [Display(Name = "Pizzas")]
        public List<string> PizzaNames { get; set; }
        public int Id { get; set; }
    }
}
