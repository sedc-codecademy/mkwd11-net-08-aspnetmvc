using SEDC.PizzaApp.Refactored.Domain.Enums;

namespace SEDC.PizzaApp.Refactored.Domain.Models
{
    public class PizzaOrder : BaseEntity
    {
        public Pizza Pizza { get; set; }
        public int PizzaId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public PizzaSize PizzaSize { get; set; }
    }
}
