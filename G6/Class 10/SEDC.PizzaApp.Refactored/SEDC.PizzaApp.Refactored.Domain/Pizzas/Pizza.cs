
using SEDC.PizzaApp.Refactored.Domain.Orders;

namespace SEDC.PizzaApp.Refactored.Domain.Pizzas
{
    public class Pizza : BaseEntity
    {
        //these properties reflect columns from tables
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsOnPromotion { get; set; }
        //1-M, PizzaOrder is on the Many side
        public List<PizzaOrder> PizzaOrders { get; set; }
    }
}
