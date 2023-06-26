using SEDC.PizzaApp.BLL.DTOs.Users;
using SEDC.PizzaApp.Data.Models;
using SEDC.PizzaApp.Data.Repositories;
using SEDC.PizzaApp.Web.Mapper;
using SEDC.UserApp.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.BLL.Services.Implementation
{
    public class UserService
        : IUserService
    {
        private readonly IRepository<User> repository;

        public UserService(IRepository<User> repository)
        {
            this.repository = repository;
        }
        public UserDTO Create(CreateUserDTO create)
        {
            //if (string.IsNullOrEmpty(create.FirstName))
            //{
            //    throw new Exception( "First name can not be empty");
            //}
            //if (string.IsNullOrEmpty(create.LastName))
            //{
            //    ViewBag.Error = "Last name can not be empty";
            //    return View();
            //}
            //if (string.IsNullOrEmpty(create.Phone))
            //{
            //    ViewBag.Error = "Phone can not be empty";
            //    return View();
            //}
            var user = new User(create.FirstName, create.LastName, create.Phone);
            repository.Save(user);
            return user.ToDTO();
            
        }

        public void Delete(int id)
        {
            var user = repository.GetById(id);
            if(user == null)
            {
                throw new Exception();
            }
            repository.Delete(user);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            IEnumerable<User>? user = repository.GetAll();
            return user.Select(x => x.ToDTO());
        }

        public UserDTO GetById(int id)
        {
            var user = repository.GetById(id);
            return user?.ToDTO() ?? throw new Exception(); // TODO
        }

        public UpdateUserDTO GetUpdateDtoById(int id)
        {
            var user = repository.GetById(id);
            return user?.ToUpdateDTO() ?? throw new Exception(); // TODO
        }

        public UserDTO Update(UpdateUserDTO userDTO)
        {
            var user = repository.GetById(userDTO.Id);

            if(user == null)
            {
                throw new Exception();
            }

            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Phone = userDTO.Phone;

            repository.Update(user);

            return user.ToDTO();
        }
    }
}
