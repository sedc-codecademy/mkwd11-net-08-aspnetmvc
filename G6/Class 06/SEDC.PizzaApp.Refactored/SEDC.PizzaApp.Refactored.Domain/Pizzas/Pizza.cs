
using SEDC.PizzaApp.Refactored.Domain.Orders;

namespace SEDC.PizzaApp.Refactored.Domain.Pizzas
{
    public class Pizza : BaseEntity
    {
        //these properties reflect columns from tables
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsOnPromotion { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }
    }
}
