namespace SEDC.PizzaApp.DomainModels
{
    public class MenuItem : BaseEntity
    {
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }

        public MenuItem() : base()
        {

        }

        public MenuItem(int id, Pizza pizza, Size size, decimal price) : base(id)
        {
            Pizza = pizza;
            Size = size;
            Price = price;
        }

        public MenuItem(int id, int pizzaId, int sizeId, decimal price) : base(id)
        {
            PizzaId = pizzaId;
            SizeId = sizeId;
            Price = price;
        }
    }
}
