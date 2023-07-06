using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;

namespace Business.Abstraction
{
    public interface ISizeService
    {
        List<SelectListItem> GetSizesSelectList();
        List<SizeViewModel> GetAll();
        SizeViewModel GetById(int id);
        void Save(SizeViewModel model);
        void Delete(int id);
    }
}
