namespace PizzaApp.Refactored._09.Domain
{
    public class Pizza : BaseEntity
    {
        public string Name { get; set; }
        public bool IsOnPromotion { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }
    }
}
