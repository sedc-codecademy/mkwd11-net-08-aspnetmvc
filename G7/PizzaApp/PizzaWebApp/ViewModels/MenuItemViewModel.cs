using System.Globalization;

namespace ViewModels
{
    public class MenuItemViewModel
    {
        public int Id { get; set; }
        public PizzaViewModel Pizza { get; set; }
        public SizeViewModel Size { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Pizza.Name} ({Size.Name}) [{Price.ToString("C", CultureInfo.CreateSpecificCulture("mk-MK"))}]";
        }
    }
}
