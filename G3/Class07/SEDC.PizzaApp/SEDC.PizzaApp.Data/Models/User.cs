namespace SEDC.PizzaApp.Data.Models
{
    public class User
        : BaseEntity
    {
        public User(string firstName, string lastName, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;


        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}