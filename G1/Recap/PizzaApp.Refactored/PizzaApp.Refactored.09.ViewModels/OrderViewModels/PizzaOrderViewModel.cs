using PizzaApp.Refactored._09.Domain;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Refactored._09.ViewModels
{
    public class PizzaOrderViewModel
    {
        public int OrderId { get; set; }
        [Display(Name ="Pizza")]
        public int PizzaId { get; set; }
        [Display(Name = "Pizza Size")]
        public PizzaSizeEnum PizzaSize { get; set; }
    }
}
