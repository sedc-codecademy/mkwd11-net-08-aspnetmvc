namespace SEDC.PizzaApp.DomainModels
{
    public class MenuItem : BaseEntity
    {
        public Pizza Pizza { get; set; }
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
    }
}
