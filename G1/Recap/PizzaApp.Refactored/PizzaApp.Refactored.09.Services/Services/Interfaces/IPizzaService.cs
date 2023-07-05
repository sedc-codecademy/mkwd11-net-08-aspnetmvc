using PizzaApp.Refactored._09.ViewModels;

namespace PizzaApp.Refactored._09.Services
{
    public interface IPizzaService
    {
        List<PizzaViewModel> GetPizzasForDropdown();
        string GetPizzaOnPromotion();
    }
}
