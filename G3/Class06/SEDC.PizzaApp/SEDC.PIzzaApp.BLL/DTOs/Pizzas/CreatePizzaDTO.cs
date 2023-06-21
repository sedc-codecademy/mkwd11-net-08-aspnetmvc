namespace SEDC.PIzzaApp.BLL.DTOs.Pizzas
{
    public class CreatePizzaDTO
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool IsOnPromotion { get; set; }

        public int OrderId { get; set; }
    }
}
