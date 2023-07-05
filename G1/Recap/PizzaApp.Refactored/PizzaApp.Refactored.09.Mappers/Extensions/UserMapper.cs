using PizzaApp.Refactored._09.Domain;
using PizzaApp.Refactored._09.ViewModels;

namespace PizzaApp.Refactored._09.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel MapToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}"
            };
        }
    }
}
