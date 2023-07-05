using PizzaApp.Refactored._09.DataAccess;
using PizzaApp.Refactored._09.Domain;
using PizzaApp.Refactored._09.Mappers;
using PizzaApp.Refactored._09.ViewModels;

namespace PizzaApp.Refactored._09.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository) // Dependency Injection
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
