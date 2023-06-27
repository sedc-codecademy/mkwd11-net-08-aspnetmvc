namespace SEDC.PizzaApp.DomainModels
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Note { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalPrice => OrderItems == null ? 0 : OrderItems.Sum(x => x.Quantity * x.MenuItem.Price);

        public Order()
        {

        }

        public Order(int id, string address, string phoneNumber, string note, List<OrderItem> orderItems)
        {
            Id = id;
            Address = address;
            PhoneNumber = phoneNumber;
            Note = note;
            OrderItems = orderItems;
        }
    }
}
