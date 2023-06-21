namespace PizzaApp.Domain.Models
{
    using PizzaApp.Domain.Enums;

    //This is a helper/junction table/class for the many-to-many relationship
    public class PizzaOrder : BaseEntity
    {
        public Pizza Pizza { get; set; }

        public int PizzaId { get; set; }

        public Order Order { get; set; }

        public int OrderId { get; set; }

        public PizzaSizeEnum PizzaSize { get; set; }
    }
}
