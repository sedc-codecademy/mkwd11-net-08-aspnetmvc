using SEDC.PizzaApp.Refactored.Domain.Orders;


namespace SEDC.PizzaApp.Refactored.Domain.Users
{
    //all domain entities have Id, that is why they inherit from BaseEntity
    public class User : BaseEntity
    {
        //these properties reflect columns from tables
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        //1 User - Many Orders
        public List<Order> Orders { get; set; }
    }
}
