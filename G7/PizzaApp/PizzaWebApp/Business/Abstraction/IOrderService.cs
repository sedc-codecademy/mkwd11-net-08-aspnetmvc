using ViewModels;

namespace Business.Abstraction
{
    public interface IOrderService
    {
        List<OrderViewModel> GetAll();
        int Save(OrderViewModel model);
        OrderViewModel Details(int id);
        void Delete(int id);
    }
}
