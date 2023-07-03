

using SEDC.PizzaApp.Refactored.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.Refactored.ViewModels.Orders
{
    public class CreateOrderViewModel
    {
        [Display(Name = "Payment method")]
        public PaymentMethod PaymentMethod { get; set; }

        [Display(Name = "User")]
        public int UserId { get; set; }

        [Display(Name = "Is order delivered")]
        public bool IsDelivered { get; set; }
    }
}
