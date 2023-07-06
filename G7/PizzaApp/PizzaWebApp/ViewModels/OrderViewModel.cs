namespace ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Note { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemViewModel> Items { get; set; }

        public OrderViewModel()
        {
            Items = new List<OrderItemViewModel>();
        }
    }
}
