namespace SEDC.PizzaApp.Web.Models.ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool IsOnPromotion { get; set; }
    }
}
