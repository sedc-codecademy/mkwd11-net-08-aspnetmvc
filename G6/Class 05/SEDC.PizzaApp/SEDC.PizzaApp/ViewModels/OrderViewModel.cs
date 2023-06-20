using SEDC.PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        [Display(Name = "Pizza Name")]
        public string PizzaName { get; set; }

        [Display(Name = "User")]
        public int UserId { get; set; }

        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }

        [Display(Name = "Is order delivered")]
        public bool Delivered { get; set; }
    }
}
