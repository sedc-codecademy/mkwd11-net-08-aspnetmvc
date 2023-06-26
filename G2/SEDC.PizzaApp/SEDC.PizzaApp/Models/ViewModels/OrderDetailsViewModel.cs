using SEDC.PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Pizza Name")]
        public string PizzaName { get; set; }

        public string UserFullName { get; set; }
        public int Price { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsDelivered { get; set; }
    }
}
