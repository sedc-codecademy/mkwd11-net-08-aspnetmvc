using DomainModels;
using Mappers;
using ViewModels;

namespace Mappers
{
    public static class OrderItemMapper
    {
        public static OrderItemViewModel ToViewModel(this OrderItem item)
        {
            return new OrderItemViewModel()
            {
                Id = item.Id,
                MenuItem = item.MenuItem.ToViewModel(),
                Quantity = item.Quantity
            };
        }
    }
}
