using PizzaApp.Models.Domain;
using PizzaApp.Models.ViewModels.UserViewModels;

namespace PizzaApp.Models.Mappers
{
    public static class UserMapper
    {
        public static UserSelectViewModel MapToUserSelectViewModel(this User user)
        {
            return new UserSelectViewModel()
            {
                Id = user.Id,
                UserFullName = $"{user.FirstName} {user.LastName}"
            };
        }
    }
}
