namespace PizzaApp.Refactored._07.Domain
{
    public class Pizza : BaseEntity
    {
        public string Name { get; set; }
        public PizzaSizeEnum PizzaSize { get; set; }
        public bool IsOnPromotion { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }
    }
}
