using PizzaApp.Refactored._09.ViewModels;

namespace PizzaApp.Refactored._09.Services
{
    public interface IUserService
    {
        List<UserViewModel> GetUsersForDropdown();
    }
}
