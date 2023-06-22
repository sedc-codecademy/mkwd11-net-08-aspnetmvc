using PizzaApp.Refactored._07.Domain;
using PizzaApp.Refactored._07.ViewModels;

namespace PizzaApp.Refactored._07.Mappers
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
