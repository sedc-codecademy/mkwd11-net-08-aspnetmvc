using SEDC.PizzaApp.Refactored.DataAccess.Implementations;
using SEDC.PizzaApp.Refactored.DataAccess.Interfaces;
using SEDC.PizzaApp.Refactored.Domain.Users;
using SEDC.PizzaApp.Refactored.Mappers.Users;
using SEDC.PizzaApp.Refactored.Services.Interfaces;
using SEDC.PizzaApp.Refactored.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Refactored.Services.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }
        public List<UserDropDownViewModel> GetUserForDropdown()
        {
            //get all users from db
            List<User> usersDb = _userRepository.GetAll();

            //map to dropdown viewmodels
            List<UserDropDownViewModel> userDropDownViewModels =
                usersDb.Select(x => UserMapper.ToUserDropDownViewModel(x)).ToList();

            return userDropDownViewModels;
        }
    }
}
