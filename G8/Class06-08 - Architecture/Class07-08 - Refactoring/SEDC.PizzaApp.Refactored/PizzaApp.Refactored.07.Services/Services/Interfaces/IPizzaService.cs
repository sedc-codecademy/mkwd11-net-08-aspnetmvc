using PizzaApp.Refactored._07.ViewModels;

namespace PizzaApp.Refactored._07.Services
{
    public interface IPizzaService
    {
        List<PizzaViewModel> GetPizzasForDropdown();
        string GetPizzaOnPromotion();
    }
}
