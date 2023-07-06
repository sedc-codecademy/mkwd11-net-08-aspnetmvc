using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;

namespace Business.Abstraction
{
    public interface IPizzaService
    {
        List<PizzaViewModel> GetAll();
        PizzaViewModel GetById(int id);
        void Save(PizzaViewModel model);
        void Delete(int id);
        List<SelectListItem> GetPizzasSelectList();
    }
}
