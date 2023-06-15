namespace PizzaApp.Models.ViewModels.PizzaViewModels
{
    public class PizzaDetailsViewModel
    {
        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        public bool IsOnPromotion { get; set; }

        public string? ImageUrl { get; set; }

        public List<string> Ingredients { get; set; } = new List<string>();

        public List<string> PizzaSizes { get; set; } = new List<string>();
    }
}
