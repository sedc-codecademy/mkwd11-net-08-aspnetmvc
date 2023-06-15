using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Models.Mapers
{
    public class OrderMaper
    {
        public static OrderDetailsViewModel OrderToViewModel(Order order) 
        
        {
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                PaymentMetod = order.PaymentMetod,
                FullName = $"{order.User.FirstName + " " + order.User.LastName }",
                PizzaName = order.Pizza.Name
                
            };
        }     
    }
}
