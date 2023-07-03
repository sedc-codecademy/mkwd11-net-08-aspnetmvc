using System.ComponentModel.DataAnnotations;

namespace PizzaApp.ViewModels.PizzaViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }

        [Display(Name="Pizza name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Pizza promotion")]
        public bool IsOnPromotion { get; set; }

        [Display(Name = "Pizza price")]
        public int Price { get; set; }

        [Display(Name = "Pizza image")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
