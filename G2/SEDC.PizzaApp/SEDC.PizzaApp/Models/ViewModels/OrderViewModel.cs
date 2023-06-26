using SEDC.PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Pizza Name")]
        public string PizzaName { get; set; }

        [Display(Name = "User")]
        public string UserId { get; set; }

        [Display(Name = "Is Order Delivered")]
        public bool Delieverd { get; set; }

        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
    }
}
