namespace PizzaApp.Services.Interfaces
{
    using PizzaApp.ViewModels.PizzaViewModels;

    public interface IPizzaService
    {
        Task<List<PizzaListViewModel>> GetPizzasForCards();
    }
}
