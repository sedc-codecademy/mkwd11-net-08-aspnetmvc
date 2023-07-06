using SEDC.PizzaApp.Refactored.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Services.Abstraction
{
    public interface IUserService
    {
        List<UserViewModel> GetUsersForDropdown();
    }
}
