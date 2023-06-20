using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class OrderMapper
    {
        //This method will be called in all places where we need to map from Order to OrderDetailsViewModel
        public static OrderDetailsViewModel ToOrderDetailsViewModel(Order orderDb)
        {
            return new OrderDetailsViewModel
            {
                PaymentMethod = orderDb.PaymentMethod,
                PizzaName = orderDb.Pizza.Name,
                Price = orderDb.Pizza.Price + 100,
                UserFullname = $"{orderDb.User.FirstName} {orderDb.User.LastName}",
                Delivered = orderDb.Delivered
            };
        }
    }
}
