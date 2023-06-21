using SEDC.PizzaApp.Data.Models;
using SEDC.PIzzaApp.BLL.DTOs.Users;

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
    }
}
