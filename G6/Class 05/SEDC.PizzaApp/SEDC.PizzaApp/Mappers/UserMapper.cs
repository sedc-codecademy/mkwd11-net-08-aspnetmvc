using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.ViewModels;

namespace SEDC.PizzaApp.Mappers
{
    public static class UserMapper
    {
        public static UserDropDownViewModel ToUserDropDownViewModel(User userDb)
        {
            return new UserDropDownViewModel
            {
                Id = userDb.Id,
                FullName = $"{userDb.FirstName} {userDb.LastName}"
            };
        }
    }
}
