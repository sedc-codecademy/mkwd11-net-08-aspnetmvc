using SEDC.PizzaApp.Data.Models;
using SEDC.PizzaApp.BLL.DTOs.Users;

namespace SEDC.PizzaApp.Web.Mapper
{
    public static class UserMapper
    {
        public static UserDTO ToDTO(this User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Phone = user.Phone
            };
        }

        public static UpdateUserDTO ToUpdateDTO(this User user)
        {
            return new UpdateUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone
            };
        }
    }
}
