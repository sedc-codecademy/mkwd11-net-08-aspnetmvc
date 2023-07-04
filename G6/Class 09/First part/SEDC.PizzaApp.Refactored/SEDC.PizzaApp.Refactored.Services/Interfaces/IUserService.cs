using SEDC.PizzaApp.Refactored.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDropDownViewModel> GetUserForDropdown();
    }
}
