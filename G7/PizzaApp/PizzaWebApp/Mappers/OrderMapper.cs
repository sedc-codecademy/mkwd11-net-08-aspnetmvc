using DomainModels;
using Mappers;
using ViewModels;

namespace Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Address = order.Address,
                Name = order.Name,
                Items = order.OrderItems.Select(x => x.ToViewModel()).ToList(),
                Note = order.Note,
                PhoneNumber = order.PhoneNumber,
                TotalPrice = order.OrderItems == null ? 0 : order.OrderItems.Sum(x => x.Quantity * x.MenuItem.Price)
            };
        }
    }
}
