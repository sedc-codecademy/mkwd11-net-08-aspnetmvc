using SEDC.PizzaApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get;set; }
        [Display(Name="Pizza Name")] //we set the text taht will be shown in <label asp-for="PizzaName" ></label>
        public string PizzaName { get;set; }
        public string UserFullname { get;set; }
        public int Price { get;set; }
        public PaymentMethod PaymentMethod { get;set; }
        public bool Delivered { get;set; }
    }
}
