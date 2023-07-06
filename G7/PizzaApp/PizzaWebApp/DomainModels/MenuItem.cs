using System.Globalization;

namespace DomainModels
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }

        public MenuItem()
        {

        }

        public MenuItem(int pizzaId, int sizeId, decimal price)
        {
            PizzaId = pizzaId;
            SizeId = sizeId;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Pizza.Name} ({Size.Name}) [{Price.ToString("C", CultureInfo.CreateSpecificCulture("mk-MK"))}]";
        }
    }
}
