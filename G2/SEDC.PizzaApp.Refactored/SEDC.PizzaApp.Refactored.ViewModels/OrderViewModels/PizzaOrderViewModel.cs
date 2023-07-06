using SEDC.PizzaApp.Refactored.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaApp.Refactored.ViewModels.OrderViewModels
{
    public class PizzaOrderViewModel
    {
        public int OrderId { get; set; }
        [Display(Name = "Pizza")]
        public int PizzaId { get; set; }
        [Display(Name = "Pizza Size")]
        public PizzaSize PizzaSize { get; set; }
    }
}
