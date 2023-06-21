namespace PizzaApp.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
