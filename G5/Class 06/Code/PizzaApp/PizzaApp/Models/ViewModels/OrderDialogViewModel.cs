using PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaApp.Models.ViewModels
{
    public class OrderDialogViewModel
    {
        [Display(Name ="Pizza name")]
        public string PizzaName { get; set; }

        [Display(Name = "User")]
        public int UserId { get; set; }

        [Display(Name = "Payment Method")]
        public PaymentMethodEnum PaymentMethod { get; set; }

        [Display(Name = "Is order delivered")]
        public bool IsDelivered { get; set; }   
        public  int Id { get; set; } // we need this for the Edit
    }
}
