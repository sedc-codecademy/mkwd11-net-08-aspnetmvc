using SEDC.PizzaApp.Refactored.Domain.Models;
using SEDC.PizzaApp.Refactored.Services.Abstraction;
using SEDC.PizzaApp.Refactored.ViewModels.UserViewModels;
using SEDC.PizzaApp.Refactored.Mappers.Extensions;
using SEDC.PizzaApp.Refactored.DataAccess.Repositories.Abstraction;

namespace SEDC.PizzaApp.Refactored.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public List<UserViewModel> GetUsersForDropdown() 
        {
            List<User> usersDb = _userRepository.GetAll();
            return usersDb.Select(x => x.MapToUserViewModel()).ToList();
        }
    }
}
