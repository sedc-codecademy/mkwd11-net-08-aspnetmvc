using ViewModels;

namespace Business.Abstraction
{
    public interface IOrderItemService
    {
        void Save(OrderItemViewModel model);
        int Delete(int id);
    }
}
