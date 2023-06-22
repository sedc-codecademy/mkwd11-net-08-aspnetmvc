using SEDC.PizzaApp.BLL.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.UserApp.BLL.Services
{
    public interface IUserService
    {
        public IEnumerable<UserDTO> GetAll();

        public UserDTO GetById(int id);

        public UserDTO Update(UserDTO UserDTO);

        public UserDTO Create(CreateUserDTO create);

        public void Delete(int id);
    }
}
