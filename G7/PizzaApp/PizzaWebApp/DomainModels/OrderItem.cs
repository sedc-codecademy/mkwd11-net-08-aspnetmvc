namespace DomainModels
{
    public class OrderItem
    {
        public int Id { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public OrderItem()
        {

        }

        public OrderItem(MenuItem menuItem, int quantity)
        {
            MenuItem = menuItem;
            Quantity = quantity;
        }
    }
}
