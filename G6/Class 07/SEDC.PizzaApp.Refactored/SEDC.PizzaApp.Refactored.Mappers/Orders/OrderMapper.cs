using SEDC.PizzaApp.Refactored.Domain.Orders;
using SEDC.PizzaApp.Refactored.ViewModels.Orders;

namespace SEDC.PizzaApp.Refactored.Mappers.Orders
{
    public static class OrderMapper
    {
        //this is an extension method and it will behave as if it was part of the Order class
        public static OrderListViewModel ToOrderListViewModel(this Order order)
        {
            var price = CalculateOrderPrice(order);

            return new OrderListViewModel
            {
                Id = order.Id,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                TotalPrice = price
            };
        }

        //this is not an extension method!
        //we don't use this keyword
        //we must use OrderMapper class to call this method
        public static OrderDetailsViewModel ToOrderDetailsViewModel(Order order)
        {
            var price = CalculateOrderPrice(order);
            return new OrderDetailsViewModel
            {
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                TotalPrice = price,
                IsDelivered = order.IsDelivered,
                PaymentMethod = order.PaymentMethod.ToString(),
                PizzaNames = order.PizzaOrders.Select(x => x.Pizza.Name).ToList()
            };

        }

        private static int CalculateOrderPrice(Order order)
        {
            var price = 0;
            foreach (PizzaOrder pizzaOrder in order.PizzaOrders)
            {
                if (pizzaOrder.PizzaSize == Domain.Enums.PizzaSize.Family)
                {
                    price += (pizzaOrder.Pizza.Price + 100) * pizzaOrder.NumberOfPizzas;
                }
                else
                {
                    price += pizzaOrder.Pizza.Price * pizzaOrder.NumberOfPizzas;
                }
            }
            return price;
        }
    }
}
