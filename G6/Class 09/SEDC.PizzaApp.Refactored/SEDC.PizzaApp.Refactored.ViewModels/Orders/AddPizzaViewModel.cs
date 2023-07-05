using SEDC.PizzaApp.Refactored.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.Refactored.ViewModels.Orders
{
    public class AddPizzaViewModel
    {
        [Display(Name = "Pizza")]
        public int PizzaId { get; set; }

        [Display(Name = "Size")]
        public PizzaSize PizzaSize { get; set; }

        [Display(Name = "Number of pizzas")]
        public int NumberOfPizzas { get; set; }
        //this property is needed to keep track for order id between requests (Get and Post)
        public int OrderId { get; set; }
    }
}
