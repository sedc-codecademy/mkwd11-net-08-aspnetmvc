namespace Models
{
    public class RestaurantViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public List<MenuItemViewModel> Menu { get; set; }
    }
}