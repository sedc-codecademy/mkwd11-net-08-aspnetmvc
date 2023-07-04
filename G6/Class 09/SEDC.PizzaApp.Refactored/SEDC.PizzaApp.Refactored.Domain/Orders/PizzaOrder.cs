using SEDC.PizzaApp.Refactored.Domain.Enums;
using SEDC.PizzaApp.Refactored.Domain.Pizzas;

namespace SEDC.PizzaApp.Refactored.Domain.Orders
{
    public class PizzaOrder : BaseEntity
    {
        //FK-s
        public int PizzaId { get; set; }
        //we should always add appropriate property (object) for the related record
        public Pizza Pizza { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int NumberOfPizzas { get; set; }
        public PizzaSize PizzaSize { get; set; }
    }
}
