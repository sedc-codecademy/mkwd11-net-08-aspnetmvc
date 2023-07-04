namespace SEDC.PizzaApp.DomainModels
{
    public class OrderItem : BaseEntity
    {
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

        public OrderItem() : base()
        {

        }

        public OrderItem(int id, MenuItem menuItem, int quantity) : base(id)
        {
            MenuItem = menuItem;
            Quantity = quantity;
        }
    }
}
