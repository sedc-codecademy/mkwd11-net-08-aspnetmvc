using SEDC.PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.Models.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name="Pizza Name")]
        public string PizzaName { get; set; }
        [Display(Name = "User")]
        public int UserId { get; set; }
        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Is Order Delivered")]
        public bool Delivered { get; set; }

        public int Id { get; set; } //we need this for Edit
    }
}
