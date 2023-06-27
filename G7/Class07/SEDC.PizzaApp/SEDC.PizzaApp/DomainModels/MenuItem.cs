namespace SEDC.PizzaApp.DomainModels
{
    public class MenuItem
    {
        public int Id { get; set; }
        public Pizza Pizza { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }

        public MenuItem()
        {

        }

        public MenuItem(int id, Pizza pizza, Size size, decimal price)
        {
            Id = id;
            Pizza = pizza;
            Size = size;
            Price = price;
        }
    }
}
