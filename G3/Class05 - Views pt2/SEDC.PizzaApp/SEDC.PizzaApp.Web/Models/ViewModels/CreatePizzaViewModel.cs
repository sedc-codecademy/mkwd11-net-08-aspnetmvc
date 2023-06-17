namespace SEDC.PizzaApp.Web.Models.ViewModels
{
    public class CreatePizzaViewModel
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool IsOnPromotion { get; set; }

        public int OrderId { get; set; }
    }
}
