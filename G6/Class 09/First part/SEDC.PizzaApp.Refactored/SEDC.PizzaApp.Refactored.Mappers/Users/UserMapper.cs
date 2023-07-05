using SEDC.PizzaApp.Refactored.Domain.Users;
using SEDC.PizzaApp.Refactored.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Mappers.Users
{
    public static class UserMapper
    {
        public static UserDropDownViewModel ToUserDropDownViewModel(User user)
        {
            return new UserDropDownViewModel
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}"
            };
        }
    }
}
