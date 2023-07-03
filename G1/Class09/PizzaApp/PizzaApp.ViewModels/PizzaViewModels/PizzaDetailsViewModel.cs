namespace PizzaApp.ViewModels.PizzaViewModels
{
    public class PizzaDetailsViewModel
    {
        public string Name { get; set; } = string.Empty;

        public bool IsOnPromotion { get; set; }

        public int Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public int NumberOfTimesOrdered { get; set; }
    }
}
