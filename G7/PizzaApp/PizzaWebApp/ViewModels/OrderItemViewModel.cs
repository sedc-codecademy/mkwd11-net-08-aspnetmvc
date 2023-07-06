namespace ViewModels
{
    public class OrderItemViewModel
    {
        public int OrderId { get; set; }
        public int Id { get; set; }
        public MenuItemViewModel MenuItem { get; set; }
        public int Quantity { get; set; }
    }
}
