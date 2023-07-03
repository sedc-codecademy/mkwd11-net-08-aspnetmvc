using PizzaAppRefactored.Domain.Enums;


namespace PizzaAppRefactored.Domain.Models
{
    public class Order :  BaseEntity
    {
        public PaymentMethodEnum PaymentMethod { get; set; }    

        public bool IsDelivered { get; set; }   

        public string PizzaStore { get; set; }

        public User User { get; set; }  
        public int UserId { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; }

    }
}
