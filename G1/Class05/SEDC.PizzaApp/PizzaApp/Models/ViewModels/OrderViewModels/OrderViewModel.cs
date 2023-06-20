using PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        [Display(Name="Pizza Name")]
        public string PizzaName { get; set; } = string.Empty;

        [Display(Name="User")]
        public int UserId { get; set; }

        [Display(Name = "Payment method")]
        public PaymentMethod PaymentMethod { get; set; }

        [Display(Name="Is order delivered")]
        public bool IsDelivered { get; set; }

        public int Id { get; set; } //We are going to need this for the editing part
    }
}
