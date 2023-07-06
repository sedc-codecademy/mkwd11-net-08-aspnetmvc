using SEDC.PizzaApp.ViewModels;

namespace SEDC.PizzaApp.Services.Abstraction
{
    public interface ISizeService
    {
        List<SizeViewModel> GetAll();
        SizeViewModel GetById(int id);
        void Save(SizeViewModel model);
        void Remove(int id);
        List<SizeViewModel> FilteredSizes(string filter);
    }
}
