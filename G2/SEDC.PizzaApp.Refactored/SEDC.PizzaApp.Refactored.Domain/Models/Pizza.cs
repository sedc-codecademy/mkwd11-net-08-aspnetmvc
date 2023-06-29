using SEDC.PizzaApp.Refactored.Domain.Enums;

namespace SEDC.PizzaApp.Refactored.Domain.Models
{
    public class Pizza : BaseEntity
    {
        public string Name { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public bool IsOnPromotion { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }
    }
}
